using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaPersonal;
using Mep3;
using Mep3._0.Manejo_de_Datos;

namespace Mep3._0.Entidades.Especificas
{
    [Serializable]
    public class ReposicionDeStock : MateriaPrima
    {
        public DateTime Fecha { get; set; }
        public double CantidadIngreso;
        public double CantidadTotalAnterior;
        public double CantidadTotalPosterior;

        public ReposicionDeStock(MateriaPrima Mp , double CantidadIngreso) : base(Mp)
        {
            this.Fecha = DateTime.Now;
            this.CantidadIngreso = CantidadIngreso;
            this.CantidadTotalAnterior = Mp.Stock - CantidadIngreso;
            this.CantidadTotalPosterior = Mp.Stock;
            
            // 'MP' ya viene con la Cantidad de stock ingresada y sumada en la misma
            // Por eso a CantidadTotalAnterior le resto CantidadIngreso...
        }
        public ReposicionDeStock(ReposicionDeStock x) : base(x.id, x.Nombre, x.Stock, x.StockMinimo, x.Infinito, x.EsUnBalde)
        {
            this.Fecha = x.Fecha;
            this.CantidadIngreso = x.CantidadIngreso;
            this.CantidadTotalAnterior = x.CantidadTotalAnterior;
            this.CantidadTotalPosterior = x.CantidadTotalPosterior;
        }
        public void Serializar()
        {
            var FilePath = Rutas.IngresoMateriaPrima();
            Serializador.Write<ReposicionDeStock>(this, FilePath);
        }
        public override string ToString()
        {
            return base.ToString() + $"CANTIDADREPOSICION{CantidadIngreso}";
        }
    }
}
