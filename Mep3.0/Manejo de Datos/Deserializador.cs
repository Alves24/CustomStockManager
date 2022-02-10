
using LibreriaPersonal;
using Mep3._0.Entidades.Especificas;
using System;
using System.Collections.Generic;
using System.IO;

// Files
using System.Runtime.Serialization.Formatters.Binary;

namespace Mep3._0
{
    public static class Deserializador
    {
        
        public static List<ReposicionDeStock> ReposicionesDeStock( int Ultimas = 0)
        {
            // Metodo ejemplo... Replicar 

            // FUNCIONAMENTO
            // Al parecer funciona como una COLA, lo primero que leo del archivo es lo primero que se ingreso !

            // RestarAnios en 0 quiere decir que va a tomar los datos de este anio..

            BinaryFormatter Formateador = new BinaryFormatter();
            Stream Archivo;

            var FilePath = Rutas.IngresoMateriaPrima();
            var Lista = new List<ReposicionDeStock>();
            ReposicionDeStock Aux;

            try
            {
                if (File.Exists(FilePath))
                {
                    Archivo = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

                    Aux = new ReposicionDeStock((ReposicionDeStock)Formateador.Deserialize(Archivo));
                    Lista.Add(Aux);

                    while (Archivo.Position != Archivo.Length)
                    {
                        Aux = new ReposicionDeStock((ReposicionDeStock)Formateador.Deserialize(Archivo));
                        Lista.Add(Aux);
                    }
                    Archivo.Close();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message, $"Deserializador.ResposicionesDeStock");
            }

            if (Ultimas > 0) Lista = DevolverUltimosObj(Lista, Ultimas);

            return Lista;
        }

        public static List<OrdenDePedido> Ordenes(int Ultimas = 0)
        {
            var Ruta = Rutas.Ordenes();
            var Lista = new List<OrdenDePedido>();
            OrdenDePedido OrdenAux;

            try
            {
                BinaryFormatter Formateador = new BinaryFormatter();

                if (File.Exists(Ruta))
                {
                    Stream Archivo = new FileStream(Ruta, FileMode.Open, FileAccess.Read);

                    OrdenAux = new OrdenDePedido((OrdenDePedido)Formateador.Deserialize(Archivo));
                    Lista.Add(OrdenAux);

                    while (Archivo.Position != Archivo.Length)
                    {
                        OrdenAux = new OrdenDePedido((OrdenDePedido)Formateador.Deserialize(Archivo));
                        Lista.Add(OrdenAux);
                    }

                    Archivo.Close();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message, $"Deserializador.OrdenesDePedido");
            }

            if (Ultimas > 0) Lista = DevolverUltimosObj(Lista, Ultimas);


            return Lista;
        }

        public static List<Balde> Producciones()
        {
            var Ruta = Rutas.Producciones();
            var Lista = new List<Balde>();
            Balde Produccion;


            try
            {
                BinaryFormatter Formateador = new BinaryFormatter();

                if (File.Exists(Ruta))
                {
                    Stream Archivo = new FileStream(Ruta, FileMode.Open, FileAccess.Read);

                    Produccion = new Balde((Balde)Formateador.Deserialize(Archivo));
                    Lista.Add(Produccion);

                    while (Archivo.Position != Archivo.Length)
                    {
                        Produccion = new Balde((Balde)Formateador.Deserialize(Archivo));
                        Lista.Add(Produccion);
                    }

                    Archivo.Close();
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message, $"Deserializador.Producciones");
            }

            return Lista;
        }


        private static List<T> DevolverUltimosObj<T> (List<T> Lista, int cant)
        {
            var nLista = new List<T>();
            var tamanio = Lista.Count;

            if(tamanio > cant)
            {
                for(int i = 0; i < cant; i++)
                {
                    nLista.Add(Lista[tamanio - 1 - i]);
                }
                return nLista;
            }
            else
            {
                return Lista;
            }
            
        }

    }
}