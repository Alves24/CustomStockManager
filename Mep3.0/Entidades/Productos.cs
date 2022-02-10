using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mep3._0
{
    [Serializable]
    public class Productos
    {
        public List<Balde> baldes;
        

        public Productos()
        {
            baldes = new List<Balde>();
        }

        public Productos( Productos Products)
        {
            baldes = new List<Balde>(Products.baldes);
        }

        public int BuscarValdeByID(int ID)
        {
            int i = 0;
            foreach (Balde ValdeAux in this.baldes)
            {
                if (ID == ValdeAux.GetID()) { return i; }
                i++;
            }
            return -1;
        }

        public int BuscarBaldeByNombre(string NombreCompleto)
        {
            int i = 0;
            foreach (Balde BaldeAux in this.baldes)
            {
                if (NombreCompleto == baldes[i].GetNombreCompleto()) { return i; }
                i++;
            }
            return -1;
        }

        public void RestaPostOrden ( Productos Stock )
        {
            // Recibo el Stock del Sistema (Stock), En la variable ORDEN generada (this.Valdes)
            // Creo variables Auxiliares para asignarles la resta de STOCK - ORDEN 
            // Modifico la ORDEN (this.Valdes) , Con las Restas
            // Actualizo Stock en DB mandandole la nueva Orden
            int pos;
            int x20, x10, x4, x1;
            for (int i = 0; i < baldes.Count; i++)
            {
                pos = Stock.BuscarValdeByID(baldes[i].GetID());
                x20 = Stock.baldes[pos].Get20() - baldes[i].Get20();
                x10 = Stock.baldes[pos].Get10() - baldes[i].Get10();
                x4  = Stock.baldes[pos].Get4()  - baldes[i].Get4();
                x1  = Stock.baldes[pos].Get1()  - baldes[i].Get1();

                this.baldes[i].Modificar(x20, x10, x4, x1);
            }
        }

    }
}
