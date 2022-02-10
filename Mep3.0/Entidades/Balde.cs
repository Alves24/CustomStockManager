using LibreriaPersonal;
using System;
using System.Collections.Generic;
using System.IO;

// Files
using System.Runtime.Serialization.Formatters.Binary;

namespace Mep3._0
{
    [Serializable]
    public class Balde
    {
        private int ID;
        private string Nombre;
        private string Color;
        private double Peso;
        private int x20;
        private int x10;
        private int x4;
        private int x1;

        public bool FlagRecipe;
        public List<MateriaPrima> Recipe;
        public DateTime Fecha;
        public int numero_produccion;
        public string ErrorMessage;

        // Constructores
        public Balde(Balde X)
        {
            this.ID = X.GetID();
            this.Nombre = X.GetNombre();
            this.Color = X.GetColor();
            this.Peso = X.GetPeso();
            this.x20 = X.Get20();
            this.x10 = X.Get10();
            this.x4 = X.Get4();
            this.x1 = X.Get1();

            this.FlagRecipe = X.Recipe == null ? false : true;

            if (this.FlagRecipe == true)
            {
                this.Recipe = new List<MateriaPrima>();
                this.Recipe.AddRange(X.Recipe);
            }

            this.numero_produccion = X.numero_produccion;
            this.Fecha = X.Fecha;
        }

        public Balde(int ID, string Nom, string Colorsito, double Pesoo, int x20, int x10, int x4, int x1, int IntRecipe)
        {
            this.ID = ID;
            this.Nombre = Nom;
            this.Color = Colorsito;
            this.Peso = Pesoo;
            this.x20 = x20;
            this.x10 = x10;
            this.x4 = x4;
            this.x1 = x1;
            this.ErrorMessage = "";

            this.FlagRecipe = IntRecipe == 1 ? true : false;

            if (this.FlagRecipe)
            {
                this.Recipe = new List<MateriaPrima>();
                DeserializarReceta();
            }

            if (Recipe == null)
            {
                FlagRecipe = false;
            }

            // Inicializo estas variables de alguna manera x
            numero_produccion = 0;
            Fecha = new DateTime(1000, 1, 1);
        }

        // Funciones
        public void AddRecipe(List<MateriaPrima> Lista)
        {
            this.FlagRecipe = true;
        }

        public void Modificar(double Peso, int x20, int x10, int x4, int x1)
        {
            this.x20 = x20;
            this.x10 = x10;
            this.x4 = x4;
            this.x1 = x1;
            this.Peso = Peso;
        }

        public void Modificar(int x20, int x10, int x4, int x1)
        {
            this.x20 = x20;
            this.x10 = x10;
            this.x4 = x4;
            this.x1 = x1;
        }

        public void Sumar(int x20, int x10, int x4, int x1)
        {
            if (x20 != -999)
                this.x20 += x20;
            if (x10 != -999)
                this.x10 += x10;
            if (x4 != -999)
                this.x4 += x4;
            if (x1 != -999)
                this.x1 += x1;
        }

        public void Restar(Balde Orden)
        {
            if (Orden.Get20() != -999)
                x20 -= Orden.Get20();
            if (Orden.Get10() != -999)
                x10 -= Orden.Get10();
            if (Orden.Get4() != -999)
                x4 -= Orden.Get4();
            if (Orden.Get1() != -999)
                x1 -= Orden.Get1();
        }

        public void Produccion(int x20, int x10, int x4, int x1, int numero_produccion)
        {
            if (x20 != -999)
                this.x20 += x20;
            if (x10 != -999)
                this.x10 += x10;
            if (x4 != -999)
                this.x4 += x4;
            if (x1 != -999)
                this.x1 += x1;

            Fecha = DateTime.Now;
            this.numero_produccion = numero_produccion;
        }

        //Serializacion
        public string Serializar()
        {
            Fecha = DateTime.Now;
            string Ruta = Rutas.Producciones();
            try
            {
                BinaryFormatter Formateador = new BinaryFormatter();

                Stream File = new FileStream(Ruta, FileMode.Append, FileAccess.Write);

                Formateador.Serialize(File, this);

                File.Close();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "GOOD";
        }

        public string SerializarReceta(List<MateriaPrima> Rec)
        {
            string NombreArchivo = this.Nombre + this.Color + this.ID.ToString();
            string Ruta = Rutas.Recetas(NombreArchivo);
            try
            {
                BinaryFormatter Formateador = new BinaryFormatter();

                Stream File = new FileStream(Ruta, FileMode.Create, FileAccess.Write);
                File.Position = 0;

                foreach (MateriaPrima aux in Rec)
                {
                    Formateador.Serialize(File, aux);
                }

                File.Close();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "GOOD";
        }

        private void DeserializarReceta()
        {
            string NombreArchivo = this.Nombre + this.Color + this.ID.ToString();
            string Ruta = Rutas.Recetas(NombreArchivo);
            this.Recipe = new List<MateriaPrima>();
            MateriaPrima aux;

            try
            {
                BinaryFormatter Formateador = new BinaryFormatter();

                Stream File = new FileStream(Ruta, FileMode.Open, FileAccess.Read);

                int i = Convert.ToInt32(File.Position);
                File.Position = 0;
                while (File.Position != File.Length)
                {
                    aux = new MateriaPrima((MateriaPrima)Formateador.Deserialize(File));
                    Recipe.Add(aux);
                }

                File.Close();
            }
            catch (Exception e)
            {
                Recipe = new List<MateriaPrima>();
                Recipe.Add(new MateriaPrima(e.Message, 0, 0, false, false));
            }
        }

        // Mostrar
        public string Mostrar()
        {
            string cad = " ";

            cad += this.ID + " - " + this.Nombre + " --- " + this.Color;
            cad += ":   [20KG] =" + this.x20;
            cad += ":   [10KG] =" + this.x10;
            cad += ":   [4KG] =" + this.x4;
            cad += ":   [1KG] =" + this.x1;

            return cad;
        }

        public string MostrarNombre()
        {
            string cad = this.ID.ToString() + " - "
                       + this.Nombre + " - "
                       + this.Color;

            return cad;
        }

        public string MostrarSinVacios()
        {
            string cad = "";

            cad += this.Nombre + " --- " + this.Color + "       ";

            if (this.x20 > 0)
                cad += this.x20 + "(20KG)   ";
            if (this.x10 > 0)
                cad += this.x10 + "(10KG)   ";
            if (this.x4 > 0)
                cad += this.x4 + "(4KG)   ";
            if (this.x1 > 0)
                cad += this.x1 + "(1KG)   ";

            return cad;
        }

        public string MostrarProduccion()
        {
            // Funcion solo para testing
            string cad = "";

            cad += MostrarSinVacios();
            cad += "   Numero_Produccion: " + this.numero_produccion;
            cad += "   Fecha:" + this.Fecha;

            return cad;
        }

        #region PROPIEDADES
        public int GetID()
        { return this.ID; }

        public string GetNombreCompleto()
        {
            return this.Nombre + " " + this.Color;
        }

        public string GetNombre()
        { return this.Nombre; }

        public string GetColor()
        { return this.Color; }

        public double GetPeso()
        { return this.Peso; }

        public int Get20()
        { return this.x20; }

        public int Get10()
        { return this.x10; }

        public int Get4()
        { return this.x4; }

        public int Get1()
        { return this.x1; }

        public void SetBalde(int Cual, int Valor)
        {
            if (Cual == 20) this.x20 = Valor;
            if (Cual == 10) this.x10 = Valor;
            if (Cual == 4) this.x4 = Valor;
            if (Cual == 1) this.x1 = Valor;
        }

        public void SetBaldes(int x20, int x10, int x4, int x1)
        {
            this.x20 = x20;
            this.x10 = x10;
            this.x4 = x4;
            this.x1 = x1;
        }

        public override string ToString() => GetNombreCompleto() + "  [" +
                                              Get20().ToString() + "|" +
                                              Get10().ToString() + "|" +
                                               Get4().ToString() + "|" +
                                               Get1().ToString() + "]  ";

        #endregion PROPIEDADES
    }
}