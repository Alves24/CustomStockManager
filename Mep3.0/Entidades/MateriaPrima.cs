using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mep3._0

{
    [Serializable]
    public class MateriaPrima : IComparable 
    {
        public int    id     { get; }
        public string Nombre { get; set; }

        public float  Stock  { get; set; }
        public float  StockMinimo { get; set; }
        public bool   EsUnBalde { get; set; }
        public bool   Infinito  { get; set; }


        public MateriaPrima(string Nombre, float Cantidad, float StockMinimo , bool Infinito , bool EsUnBalde)
        {
            this.Nombre = Nombre;
            this.Stock = Cantidad;
            this.Infinito = Infinito;
            this.StockMinimo = StockMinimo;
            this.EsUnBalde = EsUnBalde;
        }
        public MateriaPrima(int id , string Nombre, float Cantidad , float StockMinimo , bool Infinito , bool EsUnBalde)
        {
            this.id = id;
            this.Nombre = Nombre;
            this.Stock = Cantidad;
            this.Infinito = Infinito;
            this.Stock = Cantidad;
            this.StockMinimo = StockMinimo;
            this.EsUnBalde = EsUnBalde;
        }
        public MateriaPrima(MateriaPrima Mp)
        {
            this.id = Mp.id;
            this.Nombre = Mp.Nombre;
            this.Stock = Mp.Stock;
            this.Infinito = Mp.Infinito;
            this.Stock = Mp.Stock;
            this.StockMinimo = Mp.StockMinimo;
            this.EsUnBalde = Mp.EsUnBalde;
        }


        public int CompareTo(object obj)
        {
            MateriaPrima mpToCompare = obj as MateriaPrima;
            if (string.Compare(mpToCompare.Nombre , this.Nombre) == -1 )
            {
                return 1;
            }
            if (string.Compare(mpToCompare.Nombre, this.Nombre) == 1)
            {
                return -1;
            }

            // Equivalentes
            return 0;
        }
        public string mostrar()
        {
            string cad = this.id.ToString() + " - "
                       + this.Nombre + " - Stock: " 
                       + this.Stock.ToString();
            return cad;
        }
        
        public void RestarCant (int Valor)
        {
            this.Stock -= Valor;
        }


        public override string ToString()
        {
            return $"{this.Nombre}    ID.{this.id}   STOCK.{this.Stock}";
        }
    }
}
