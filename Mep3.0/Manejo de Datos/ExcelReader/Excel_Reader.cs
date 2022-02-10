
using LibreriaPersonal;
using Mep3._0;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader
{
    public static class Excel_Reader
    {
        public static List<OrdenDePedido> GetOrdenes_NoID(List<string> ordersToDiscart)
        {
            var paths = Excel_PathManager.GetPaths(ordersToDiscart);
            var orderList = new List<OrdenDePedido>();

            foreach (var path in paths)
            {
                orderList.Add(ReadExcel(path));
            }

            return orderList;
        }

        private static OrdenDePedido ReadExcel(string path)
        {
            OrdenDePedido orden;
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelFile = new ExcelPackage(file))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet sheet = excelFile.Workbook.Worksheets[0];

                var fecha = sheet.Cells["A5"].Value == null ?
                            sheet.Cells["A6"].Value.ToString() : sheet.Cells["A5"].Value.ToString();

                var numero = ulong.Parse(sheet.Cells["I7"].Value.ToString());
                var cliente = sheet.Cells["B7"].Value == null? 
                              sheet.Cells["B8"].Value.ToString() : sheet.Cells["B7"].Value.ToString();
                var productos = ReadProducts(sheet , cliente);

                orden = new OrdenDePedido(cliente, "", numero);
                orden.Products.baldes = productos;
                orden.Fecha = Fechas.InverseFormat(fecha);
            }

            return orden;
        }

        private static List<Balde> ReadProducts(ExcelWorksheet sheet, string cliente) 
        {
            var products = new List<Balde>();

            string nombre = "";
            var color = "";
            var cantidad = new Dictionary<string,int>(); // Key: KG - Value: Cantidad
            bool maxima = CheckMaximaClient(cliente);

            for (int i = 20; i < 47; i++)
            {
                if (sheet.Cells[$"A{i}"].Value != null)
                {
                    nombre = sheet.Cells[$"B{i}"].Value.ToString();
                    color = (sheet.Cells[$"F{i}"].Value.ToString());
                    cantidad.Add(sheet.Cells[$"D{i}"].Value.ToString().Trim(),int.Parse(sheet.Cells[$"A{i}"].Value.ToString()));
                }
                else
                { 
                    if (cantidad.Count == 0 && i != 20) break;
    
                    products.Add(Excel_ProductsInterpretation.Single(cantidad, nombre, color, maxima));
                        
                    nombre = "";
                    color = "";
                    cantidad = new Dictionary<string, int>();
                }
            }
            return products;
        }

        private static bool CheckMaximaClient(string cliente)
        {
            switch (cliente.ToUpper())
            {
                case "DIEGO BOVEDA": return true;
                case "BOVEDA DIEGO": return true;
                case "DANIEL HERNANDEZ": return true;
                case "DH": return true;
                case "D.H.": return true;
                case "CARDOZO JUAN PABLO": return true;
                case "JUAN PABLO CARDOZO": return true;
                default:
                    return false;
            }
        }
    }
}
 