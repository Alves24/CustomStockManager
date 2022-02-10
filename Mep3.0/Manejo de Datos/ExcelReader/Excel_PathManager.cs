using LibreriaPersonal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader
{
    public static class Excel_PathManager
    {
        public static List<string> GetPaths(List<string> ordersToDiscart)
        {
            var paths = GetFilePaths();
            
            paths = DiscartOrderNumbers(paths, ordersToDiscart);

            return paths;   
        }

        private static List<string> GetFilePaths()
        {
            List<string> AllFilePaths = new List<string>();
            string path = Rutas.DropboxOrdenes();  
            var LastFilePaths = new List<string>();
            
            // Obtengo las Direcciones ( Paths ) de las ordenes a partir de una fecha
            // "Ultimos 2 MESES"...
            DateTime FechaDeInicio = DateTime.Now;
            FechaDeInicio = FechaDeInicio.AddMonths(-2);

            if (Directory.Exists(path))
            {
                // Obtengo las direcciones de los archivos del dropbox
                AllFilePaths = Directory
                                   .EnumerateFiles(path) //<--- .NET 4.5
                                   .Where(file => file.ToLower().EndsWith("xlsx") && (File.GetLastWriteTime(file) > FechaDeInicio))
                                   .ToList();
            }
            return AllFilePaths;
        }

        private static List<string> DiscartOrderNumbers(List<string> ordersPaths, List<string> ordersToDiscart)
        {
            string dbFolder = Rutas.DropboxOrdenes();
            int Distance = dbFolder.Length + 1;
            var orderPaths2 = new List<string>();

            foreach (string path in ordersPaths)
            {
                // Me quedo con el numero de orden que figura en el nombre del archivo!
                string orderNumber = path.Substring(Distance, 4);
                
                string res = ordersToDiscart.FirstOrDefault(s => s == orderNumber);

                if (res == null)
                {
                    orderPaths2.Add(path);
                }
            }
            return orderPaths2;
        }
    }
}
