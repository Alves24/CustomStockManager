using Mep3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader
{
    public static class Excel_ProductsInterpretation
    {   
        public static Balde Single (Dictionary<string,int> cantidad, string nombre, string color, bool maxima)
        {
            //Interpreto nombres y colores
            nombre = nombre.Trim();
            switch (nombre)
            {
                case "Membrana en Pasta":
                    {
                        if (maxima) nombre = "Membrana (Maxima)";
                        break;
                    }
                case "Latex Pro":
                    {
                        nombre = "Latex Pro 01";
                        break;
                    }
                case "Latex Eco":
                    {
                        nombre = "Latex Pro 01 ECO";
                        break;
                    }
                case "Latex MicroFiltrado":
                    {
                        nombre = "Latex Pro 01 MICRO";
                        break;
                    }
                case "Block 07":
                    {
                        color = "TRANSPARENTE";
                        break;
                    }
                case "Pintura Acrilica":
                    {
                        if (color == "GRIS HIELO")
                        {
                            nombre = "Acrilico Elastomerico x 23";
                        }
                        else
                        {
                            nombre = "Membrana en Pasta";
                        }
                        break;
                    }   
                case "Frentes y Muros":
                    {
                        nombre = "Frentes y Muros F365";
                        break;
                    }
               default:
                    break;
            }
            if (color == "BEIGE") color = "WENGUE";

            // Interpreto las cantidades/KG
            cantidad = FormatCantidad(cantidad);
            
            return new Balde(1, nombre, color, 0d, 
                cantidad["x 20"], cantidad["x 10"], cantidad["x 4"], cantidad["x 1"], 0); // !!! NO ID - NO RECIPE !!!
        }

        public static List<Balde> CheckProductDuplication(List<Balde> productos)
        {
            var newList = new List<Balde>();

            return null;
        }

        private static Dictionary<string, int> FormatCantidad(Dictionary<string, int> cantidad)
        {
            if (!cantidad.ContainsKey("x 20")) cantidad.Add("x 20", 0);
            if (!cantidad.ContainsKey("x 10")) cantidad.Add("x 10", 0);
            if (!cantidad.ContainsKey("x 4")) cantidad.Add("x 4", 0);
            if (!cantidad.ContainsKey("x 1")) cantidad.Add("x 1", 0);
            return cantidad;    
        }
    }
}
