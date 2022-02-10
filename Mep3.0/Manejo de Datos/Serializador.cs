using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Mep3._0.Manejo_de_Datos
{
    public static class Serializador
    { 
        public static string Write<T>(T Objeto , string FilePath)
        {
            try
            {
                Stream Archivo = new FileStream(FilePath, FileMode.Append, FileAccess.Write);

                new BinaryFormatter().Serialize(Archivo, Objeto);

                Archivo.Close();
            }
            catch (Exception e) { return e.Message; }
          
            return "GOOD";
        }
    }
}
