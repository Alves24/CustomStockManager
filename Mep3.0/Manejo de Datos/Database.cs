using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Mep3._0
{
    public class Database
    {
        private SQLiteConnection Conexion;
        private SQLiteCommand Comando;
        public Database()
        {
            string dbname = "DataBaseMEP.db";
            string path = "files/" + dbname;

            //  Antes: (Database en Desktop)
            //  string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + dbname ;

            Conexion = new SQLiteConnection("Data Source=" + path + ";Version=3;New=False;Compress=True;");
            Conexion.Open();
        }

        // MateriaPrima
        public string InsertarMateriaPrima(MateriaPrima mp)
        {
            int Consulta;
            string textcomando;
            string H = "','";
            string fin = "');";

            string Nombre = mp.Nombre;
            float Cantidad = mp.Stock;
            float CantxPack = mp.StockMinimo;
            int Infinito = mp.Infinito ? 1 : 0;
            int EsUnBalde = mp.EsUnBalde ? 1 : 0;

            textcomando = "INSERT INTO tblMATERIAPRIMA (Nombre,Cantidad,CantidadPorPaquete,Infinito,EsUnBalde) VALUES  ('" +
                        Nombre + H +
                        Cantidad + H +
                        CantxPack + H +
                        Infinito + H +
                        EsUnBalde + fin;

            try
            {
                Comando = new SQLiteCommand(textcomando, this.Conexion);
                Consulta = Comando.ExecuteNonQuery();
                if (Consulta < 1)
                    return "No se ha podido insertar el producto en la base de datos ";
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string LeerMateriaPrima(ref List<MateriaPrima> Tabla)
        {
            Tabla = new List<MateriaPrima>();
            MateriaPrima mp;

            int id;
            string nom;
            float cant;
            float cantxPack;
            bool Infinito;
            bool EsUnBalde;

            string Consulta = "SELECT * FROM tblMATERIAPRIMA";
            Comando = new SQLiteCommand(Consulta, Conexion);

            try
            {
                SQLiteDataReader datos = Comando.ExecuteReader();

                while (datos.Read())
                {
                    id = Convert.ToInt32(datos[0]);
                    nom = Convert.ToString(datos[1]);
                    cant = Convert.ToSingle(datos[2]);
                    cantxPack = Convert.ToSingle(datos[3]);
                    Infinito = Convert.ToInt32(datos[4]) == 1 ? true : false;
                    EsUnBalde = Convert.ToInt32(datos[5]) == 1 ? true : false;

                    mp = new MateriaPrima(id, nom, cant, cantxPack, Infinito, EsUnBalde);
                    Tabla.Add(mp);
                }
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string ActualizarMateriaPrima(MateriaPrima mp)
        {
            int ID = mp.id;
            string nombre = mp.Nombre;
            float cantidad = mp.Stock;
            float cantxPack = mp.StockMinimo;
            int infinito = mp.Infinito ? 1 : 0;
            int EsUnBalde = mp.EsUnBalde ? 1 : 0;

            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                           @"UPDATE tblMATERIAPRIMA SET
                            Nombre = @nom ,
                            Cantidad = @cant ,
                            CantidadPorPaquete = @cantx ,
                            Infinito = @inf ,
                            EsUnBalde = @balde
                            WHERE ID = @id ";

                    Comando.Parameters.Add(new SQLiteParameter("@nom", nombre));
                    Comando.Parameters.Add(new SQLiteParameter("@cant", cantidad));
                    Comando.Parameters.Add(new SQLiteParameter("@cantx", cantxPack));
                    Comando.Parameters.Add(new SQLiteParameter("@inf", infinito));
                    Comando.Parameters.Add(new SQLiteParameter("@balde", EsUnBalde));
                    Comando.Parameters.Add(new SQLiteParameter("@id", ID));

                    Comando.ExecuteNonQuery();
                }

                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string RestarMateriaPrima(MateriaPrima mp, float Cant, string motivo)
        {
            int id = mp.id;
            float cantidad = 0F;

            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                           @"SELECT (Cantidad) FROM tblMATERIAPRIMA  WHERE ID = '" + id.ToString() + "'; ";

                    SQLiteDataReader datos = Comando.ExecuteReader();

                    datos.Read();
                    cantidad = Convert.ToSingle(datos[0]);
                    cantidad -= Cant;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                       @"UPDATE tblMATERIAPRIMA SET Cantidad = @cant  WHERE ID = @id ";

                    Comando.Parameters.Add(new SQLiteParameter("@cant", cantidad));

                    Comando.Parameters.Add(new SQLiteParameter("@id", id));

                    Comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            // LOGER
            Logger.Material(mp, motivo, cantidad + Cant, cantidad);

            return "GOOD";
        }
        public string RestarMateriaPrima(int id, float Cant, string motivo)
        {
            float cantidad = 0F;

            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                           @"SELECT (Cantidad) FROM tblMATERIAPRIMA  WHERE ID = '" + id.ToString() + "'; ";

                    SQLiteDataReader datos = Comando.ExecuteReader();

                    datos.Read();
                    cantidad = Convert.ToInt32(datos[0]);
                    cantidad -= Cant;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                       @"UPDATE tblMATERIAPRIMA SET Cantidad = @cant  WHERE ID = @id ";

                    Comando.Parameters.Add(new SQLiteParameter("@cant", cantidad));

                    Comando.Parameters.Add(new SQLiteParameter("@id", id));

                    Comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            // LOGER TEMPORALL!!
            var ListaMp = new List<MateriaPrima>();
            LeerMateriaPrima(ref ListaMp);

            foreach (var mp in ListaMp)
            {
                if (mp.id == id)
                {
                    Logger.Material(mp, motivo, cantidad + Cant, cantidad);
                }
            }

            return "GOOD";
        }

        //Vacios
        public int[] LeerVacios(int idProducto)
        {
            var vacios = new int[4];

            return vacios;
        }
        public List<int[]> LeerVacios()
        {
            // Metodo que devuelve una Lista de arrays de enteros
            // Cada array es un tipo de Baldes vacios de 4 posiciones [ 20 , 10 , 4 , 1 ]

            // Estructura en database...
            // ID , IDproducto , Vaciox20id , Vaciox10id , Vaciox4id , Vaciox1id

            var vacios = new List<int[]>();

            string Consulta = $"SELECT * FROM tblVACIOS";
            Comando = new SQLiteCommand(Consulta, Conexion);

            return vacios;
        }
        public string InsertarVaciosDeProducto(int idProducto, int id20, int id10, int id4, int id1)
        {
            string textoComando =
                $"INSERT INTO tblVACIOS (IDproducto, Vaciox20id,Vaciox10id,Vaciox4id,Vaciox1id)" +
                $"VALUES ('{idProducto}','{id20}','{id10}','{id4}','{id1}')";

            try
            {
                Comando = new SQLiteCommand(textoComando, this.Conexion);
                int Consulta = Comando.ExecuteNonQuery();
                if (Consulta < 1)
                    return "No se ha podido insertar los Baldes VACIOS del producto !! hablarlo con Julian ";
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string RestarVacios(Balde Producto, bool[] Etiqueta, string motivo)
        {
            // Estructura en database...
            // ID , IDproducto , Vaciox20id , Vaciox10id , Vaciox4id , Vaciox1id

            // (Bool) Etiqueta
            // [0] 20x , [1] 10x , [2] 4x , [3] 1x

            var idVacios = new int[4];  // Almacena las id de los VACIOS en orden decendente ( 20kg , 10kg , 4kg , 1kg )
            var cantVaciosArestar = new int[4];  // Almacena las Cantidades de VACIOS a restar en el mismo orden que la de arriba.

            if (!Producto.FlagRecipe) return "Producto sin receta !!!";

            // 0) Cargo las cantidades a mi variable local
            cantVaciosArestar[0] = Producto.Get20();
            cantVaciosArestar[1] = Producto.Get10();
            cantVaciosArestar[2] = Producto.Get4();
            cantVaciosArestar[3] = Producto.Get1();

            // 1) Asigno las IDs de los Vacios asi re hardcodeado... por ahora se va a mantener asi un rato largo...
            //    Son las IDs de tblMATERIAPRIMA
            //  44 , 45 , 46 , 47 Etiquetas
            //  1  ,  2 ,  3 ,  4 Sin etiquetas
            if (!Etiqueta[0]) idVacios[0] = 1; else idVacios[0] = 44;
            if (!Etiqueta[1]) idVacios[1] = 2; else idVacios[1] = 45;
            if (!Etiqueta[2]) idVacios[2] = 3; else idVacios[2] = 46;
            if (!Etiqueta[3]) idVacios[3] = 4; else idVacios[3] = 47;

            // 2) Restar las cantidades de Baldes Vacios en tblMATERIAPRIMA
            int i = 0;
            string consultita = "GOOD";

            while (i < 4)
            {
                // Resto
                if (cantVaciosArestar[i] > 0)
                    consultita = RestarMateriaPrima(idVacios[i], cantVaciosArestar[i], motivo);
                // Chequeo
                if (consultita != "GOOD") return consultita;
                // Incremento 'i'
                i++;
            }

            // Todo bien, Listo !
            return "GOOD";
        }

        //Baldes
        public string InsertarBalde(string Nombre, string Color, double Peso, int x20, int x10, int x4, int x1, int IntReceta)
        {
            //| ID , Nombre , Color , Peso , x20 , x10 , x4 , x1 |

            int Cantidad;
            string H = "','";
            string fin = "');";
            string textcomando;
            int res = IntReceta;

            textcomando = "INSERT INTO tblPRODUCTOS (Nombre,Color,Peso,x20,x10,x4,x1,Receta) VALUES  ('" +
                           Nombre + H + Color + H + Peso + H + x20 + H + x10 + H + x4 + H + x1 + H + res + fin;

            try
            {
                Comando = new SQLiteCommand(textcomando, this.Conexion);
                Cantidad = Comando.ExecuteNonQuery();
                if (Cantidad < 1)
                    return "No se ha podido insertar el producto en la base de datos ";
                return "Nuevo producto agregado al Sistema";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public void LeerBaldes(ref List<Balde> Lista)
        {
            //| ID , Nombre , Color , Peso , x20 , x10 , x4 , x1 , Receta|
            Lista = new List<Balde>();
            Balde BaldeAux;

            string Consulta = "SELECT * FROM tblPRODUCTOS";
            Comando = new SQLiteCommand(Consulta, Conexion);

            SQLiteDataReader datos = Comando.ExecuteReader();

            while (datos.Read())
            {
                int ID = Convert.ToInt32(datos[0]);
                string Nombre = Convert.ToString(datos[1]);
                string Color = Convert.ToString(datos[2]);
                double Peso = Convert.ToDouble(datos[3]);
                int x20 = Convert.ToInt32(datos[4]);
                int x10 = Convert.ToInt32(datos[5]);
                int x4 = Convert.ToInt32(datos[6]);
                int x1 = Convert.ToInt32(datos[7]);
                int Res = Convert.ToInt32(datos[8]);

                BaldeAux = new Balde(ID, Nombre, Color, Peso, x20, x10, x4, x1, Res);
                Lista.Add(BaldeAux);
            }
        }
        public string ActualizarBalde(Balde Producto , string Motivo)
        {
            int ID = Producto.GetID();
            int x20 = Producto.Get20();
            int x10 = Producto.Get10();
            int x4 = Producto.Get4();
            int x1 = Producto.Get1();
            double peso = Producto.GetPeso();

            int Recipe = Producto.FlagRecipe ? 1 : 0;
            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                           @"UPDATE tblPRODUCTOS SET Peso = @pes , x20 = @X20 , x10 = @X10 , x4 = @X4 , x1 = @X1 ,Receta = @Res WHERE ID = @id ";
                    Comando.Parameters.Add(new SQLiteParameter("@X20", x20));
                    Comando.Parameters.Add(new SQLiteParameter("@X10", x10));
                    Comando.Parameters.Add(new SQLiteParameter("@X4", x4));
                    Comando.Parameters.Add(new SQLiteParameter("@X1", x1));
                    Comando.Parameters.Add(new SQLiteParameter("@id", ID));
                    Comando.Parameters.Add(new SQLiteParameter("@pes", peso));
                    Comando.Parameters.Add(new SQLiteParameter("@Res", Recipe));

                    Comando.ExecuteNonQuery();
                }

                if (Motivo == "Produccion") Motivo = $"Produccion INGRESADA -{Producto.numero_produccion}-";

                Logger.Producto(Producto, Motivo);

                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string ActualizarBaldes(List<Balde> Productos , string Motivo)
        {
            int ID, x20, x10, x4, x1;
            
            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    foreach (Balde Aux in Productos)
                    {
                        ID = Aux.GetID();
                        x20 = Aux.Get20();
                        x10 = Aux.Get10();
                        x4 = Aux.Get4();
                        x1 = Aux.Get1();
             

                        Comando.CommandText +=
                               @"UPDATE tblPRODUCTOS SET x20 = @X20 , x10 = @X10 , x4 = @X4 , x1 = @X1  WHERE ID = @id ;";
                        Comando.Parameters.Add(new SQLiteParameter("@X20", x20));
                        Comando.Parameters.Add(new SQLiteParameter("@X10", x10));
                        Comando.Parameters.Add(new SQLiteParameter("@X4", x4));
                        Comando.Parameters.Add(new SQLiteParameter("@X1", x1));
                        Comando.Parameters.Add(new SQLiteParameter("@id", ID));

                        Logger.Producto(Aux, Motivo);
                    }

                    Comando.ExecuteNonQuery();
                    

                    return "GOOD";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string FlagReceta(bool flag, int id_producto)
        {
            int Recipe = flag ? 1 : 0;
            int ID = id_producto;

            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                           @"UPDATE tblPRODUCTOS SET Receta = @Res WHERE ID = @id ";

                    Comando.Parameters.Add(new SQLiteParameter("@Res", Recipe));
                    Comando.Parameters.Add(new SQLiteParameter("@id", ID));

                    Comando.ExecuteNonQuery();
                }

                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Insertar Strings
        public string InsertarTipo(string Nombre)
        {
            int Cantidad;

            string textcomando;

            textcomando = "INSERT INTO tblTIPOS (Nombre) VALUES  ('" + Nombre + "');";

            try
            {
                Comando = new SQLiteCommand(textcomando, this.Conexion);
                Cantidad = Comando.ExecuteNonQuery();
                if (Cantidad < 1)
                    return "No se ha podido insertar el tipo en la base de datos ";
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string InsertarColor(string Color)
        {
            int Cantidad;

            string textcomando;

            textcomando = "INSERT INTO tblCOLOR (Color) VALUES  ('" + Color + "');";

            try
            {
                Comando = new SQLiteCommand(textcomando, this.Conexion);
                Cantidad = Comando.ExecuteNonQuery();
                if (Cantidad < 1)
                    return "No se ha podido insertar el color en la base de datos ";
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string InsertarCliente(string Cliente)
        {
            int Cantidad;

            string textcomando;

            textcomando = "INSERT INTO tblCLIENTES (Nombre) VALUES  ('" + Cliente + "');";

            try
            {
                Comando = new SQLiteCommand(textcomando, this.Conexion);
                Cantidad = Comando.ExecuteNonQuery();
                if (Cantidad < 1)
                    return "No se ha podido insertar el color en la base de datos ";
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string InsertarVendedor(string Vendedor)
        {
            int Cantidad;

            string textcomando;

            textcomando = "INSERT INTO tblVENDEDORES (Nombre) VALUES  ('" + Vendedor + "');";

            try
            {
                Comando = new SQLiteCommand(textcomando, this.Conexion);
                Cantidad = Comando.ExecuteNonQuery();
                if (Cantidad < 1)
                    return "No se ha podido insertar el color en la base de datos ";
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // Leer (Select)
        public void LeerTipos(ref List<string> Lista)
        {
            Lista = new List<string>();
            string Aux;

            string Consulta = "select * from tblTIPOS";
            Comando = new SQLiteCommand(Consulta, Conexion);

            SQLiteDataReader datos = Comando.ExecuteReader();

            while (datos.Read())
            {
                Aux = Convert.ToString(datos[1]);
                Lista.Add(Aux);
            }
        }
        public void LeerColores(ref List<string> Lista)
        {
            Lista = new List<string>();
            string Aux;

            string Consulta = "select * from tblCOLORES";
            Comando = new SQLiteCommand(Consulta, Conexion);

            SQLiteDataReader datos = Comando.ExecuteReader();

            while (datos.Read())
            {
                Aux = Convert.ToString(datos[1]);
                Lista.Add(Aux);
            }
        }
        public int LeerContadores(string ID)
        {
            string Consulta = "select * from tblCONTADORES ";

            Comando = new SQLiteCommand(Consulta, Conexion);
            SQLiteDataReader datos = Comando.ExecuteReader();

            while (datos.Read())
            {
                if (Convert.ToString(datos[0]) == ID)
                    return Convert.ToInt32(datos[1]);
            }
            return -1;
        }
        public void LeerClientes(ref List<string> Lista)
        {
            Lista = new List<string>();
            string Aux;

            string Consulta = "select * from tblCLIENTES";
            Comando = new SQLiteCommand(Consulta, Conexion);

            SQLiteDataReader datos = Comando.ExecuteReader();

            while (datos.Read())
            {
                Aux = Convert.ToString(datos[1]);
                Lista.Add(Aux);
            }
        }
        public void LeerVendedores(ref List<string> Lista)
        {
            Lista = new List<string>();
            string Aux;

            string Consulta = "select * from tblVENDEDORES";
            Comando = new SQLiteCommand(Consulta, Conexion);

            SQLiteDataReader datos = Comando.ExecuteReader();

            while (datos.Read())
            {
                Aux = Convert.ToString(datos[1]);
                Lista.Add(Aux);
            }
        }
        public void LeerStringTable(ref Hashtable Lista, string Tabla)
        {
            Lista = new Hashtable();
            int id;
            string Aux;

            string Consulta = "select * from " + Tabla;
            Comando = new SQLiteCommand(Consulta, Conexion);

            SQLiteDataReader datos = Comando.ExecuteReader();

            while (datos.Read())
            {
                id = Convert.ToInt32(datos[0]);
                Aux = Convert.ToString(datos[1]);
                Lista.Add(id, Aux);
            }
        }

        // DELETE
        public string Borrar(int ID, string Tabla)
        {
            string Consulta = "DELETE FROM " + Tabla + " WHERE ID=" + ID + ";";
            Comando = new SQLiteCommand(Consulta, Conexion);
            try
            {
                SQLiteDataReader datos = Comando.ExecuteReader();
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // UPDATE
        public string ActualizarContador(int Num, string ContadorID)
        {
            try
            {
                using (Comando = new SQLiteCommand(Conexion))
                {
                    Comando.CommandText =
                           @"UPDATE tblCONTADORES SET Num = @NUM      WHERE ID = @ID";

                    Comando.Parameters.Add(new SQLiteParameter("@NUM", Num));
                    Comando.Parameters.Add(new SQLiteParameter("@ID", ContadorID));
                    Comando.ExecuteNonQuery();
                }
                return "GOOD";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //CLOSE
        public void Close()
        {
            Conexion.Close();
        }

        public static class Tablas
        {
            public static string MateriaPrima = "tblMATERIAPRIMA";
            public static string Productos = "tblPRODUCTOS";
            public static string Vacios = "tblVACIOS";
        }
    }
}