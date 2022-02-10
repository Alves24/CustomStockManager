using Mep3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExcelReader
{
    public static class Excel_Orders
    {
        public static List<OrdenDePedido> Get(Productos productos)
        {
            var ordersToDiscart = GetOrdersToDiscart();
            var orders = Excel_Reader.GetOrdenes_NoID(ordersToDiscart);

            for(var i = 0; i < orders.Count; i++)
            {
                ReplaceWith_dbProducts(orders[i] , productos);
                CheckDuplicateProducts(orders[i]);
            }

            return orders;
        }

        private static void CheckDuplicateProducts(OrdenDePedido order)
        {
            // En la ultima version de GDO las regalias se colocan al final del listado de productos.
            // Esto segure cambie en el futuro cuando pueda instalar esta version en COA y asi poder leer
            //      los productos desde la hoja sin valorisar.
            // Entonces, leo el ultimo producto de la orden y veo si esta repetido...
            // Si lo esta los junto y elimino el ultimo.

            var count = order.Products.baldes.Count;
            var lastProduct = order.Products.baldes[ count - 1];

            for (int i = 0; i < count - 1; i++)
            {
                if(lastProduct.GetID() == order.Products.baldes[i].GetID())
                {
                    order.Products.baldes[i].
                        Sumar(lastProduct.Get20(), lastProduct.Get10(), lastProduct.Get4(), lastProduct.Get1());

                    order.Products.baldes.RemoveAt(count - 1);
                    break;
                }
            }
        }

        private static void ReplaceWith_dbProducts(OrdenDePedido order , Productos productos)
        {
            for (int i = 0; i < order.Products.baldes.Count; i++)
            {
                var auxId = productos.BuscarBaldeByNombre(order.Products.baldes[i].GetNombreCompleto());
                var auxQ = new int[]
                {
                    order.Products.baldes[i].Get20(),
                    order.Products.baldes[i].Get10(),
                    order.Products.baldes[i].Get4(),
                    order.Products.baldes[i].Get1()
                };
                    
                order.Products.baldes[i] = new Balde(productos.baldes[auxId]);
                order.Products.baldes[i].SetBaldes(auxQ[0], auxQ[1], auxQ[2], auxQ[3]);
            } 
        }

        private static List<string> GetOrdersToDiscart()
        {
            var orders = Deserializador.Ordenes(100);
            var ordersToDiscart = new List<string>();

            
            foreach (var order in orders)
            {
                ordersToDiscart.Add(order.GetNumero().ToString());
            }
            

            return ordersToDiscart;
        }
    }
}
