
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mep3._0
{
    public class DTGVdata
    {
        public Balde Balde;
        public int valdePos;

        public MateriaPrima Mp;
        public int mpPos;

        public string ultProducto;
        public int Contador_Produccion;

        public DTGVdata(int Contador_Produccion)
        {
            this.Contador_Produccion = Contador_Produccion;
        }
        
        public void SetValde(Balde TheValde, int valdePos)
        {
            this.Balde = new Balde(TheValde);
            this.valdePos = valdePos;
            ultProducto = "BALDE";
        }
        public void SetMp (MateriaPrima Mp , int mpPos)
        {
            this.Mp = new MateriaPrima(Mp);
            this.mpPos = mpPos;
            ultProducto = "MP";
        }
        
    }
}
