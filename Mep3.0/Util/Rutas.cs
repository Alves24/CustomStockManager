using System;
using System.Collections.Generic;
using System.IO;

namespace LibreriaPersonal
{
    public static class Rutas
    {
        public static string Ordenes(string PalabraAdicional = "")
        {
            string Nombre = "Ordenes";
            string ext = ".dat";
            string Ruta = "files/";

            Ruta += Nombre;
            Ruta += PalabraAdicional;
            Ruta += ext;

            return Ruta;
        }
        public static string Producciones(string PalabraAdicional = "")
        {
            string Nombre = "Producciones";
            string ext = ".dat";
            string Ruta = "files/";

            Ruta += Nombre;
            Ruta += PalabraAdicional;
            Ruta += ext;

            return Ruta;
        }
        public static string IngresoMateriaPrima()
        {
            string Nombre = "ReposicionesDeStock";
            string ext = ".dat";
            string Ruta = "files/";
            
            Ruta += Nombre;
            Ruta += ext;

            return Ruta;
        }
        public static string Recetas(string NombreArchivo) => $"files/recipes/{NombreArchivo}.dat";
        public static string DropboxInformesStock() => @"C:\Users\julia\Dropbox\Informes MEP";
        public static string DropboxBackUp() => @"C:\Users\julia\Dropbox\Personal\Pc mep\BackUp";
        public static string DropboxOrdenes() => @"C:\Users\julia\Dropbox\Pedidos MEP";

        // sin uso
        public static string Custom(string NombreArchivo, string FolderName)
        {
            string ext = ".dat";
            string Ruta = FolderName + "/";
            Ruta += NombreArchivo + ext;
            return Ruta;
        }
    }
}