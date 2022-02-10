using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Files
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using Mep3._0;
using LibreriaPersonal;


namespace ManejoDatos
{
    public static class ReSerializador
    {
       
        public static string Ordenes(List<OrdenDePedido> ordenDePedidos)
        {
            string Ruta = Rutas.Ordenes();
            string RutaAux = Rutas.Ordenes("Aux");
            string RutaBackup = Rutas.Ordenes("Backup");
            try
            {
                // Abro el archivo
                Stream Archivo = new FileStream(RutaAux, FileMode.Create, FileAccess.Write);
                BinaryFormatter Formateador = new BinaryFormatter();

                // Serializo
                foreach (OrdenDePedido aux in ordenDePedidos)
                {
                    Formateador.Serialize(Archivo, aux);
                }
                // Cierro el archivo
                Archivo.Close();

                // Reemplazo el archivo viejo por el nuevo
                File.Replace(RutaAux, Ruta, RutaBackup);


                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Producciones(List<Balde> producciones)
        {
            string Ruta = Rutas.Producciones();
            string RutaAux = Rutas.Producciones("Aux");
            string RutaBackup = Rutas.Producciones("Backup");
            try
            {
                // Abro el archivo
                Stream Archivo = new FileStream(RutaAux, FileMode.Create, FileAccess.Write);
                BinaryFormatter Formateador = new BinaryFormatter();

                // Serializo
                foreach (Balde aux in producciones)
                {
                    Formateador.Serialize(Archivo, aux);
                }
                // Cierro el archivo
                Archivo.Close();

                // Reemplazo el archivo viejo por el nuevo
                File.Replace(RutaAux, Ruta, RutaBackup);


                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
