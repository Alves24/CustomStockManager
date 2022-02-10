using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mep3._0
{
    public interface IForm
    {
        /*
         26/05/20 No me acuerdo como funcionaba esto...

         03/02/22 Horriblemente usada la interfaz alves del pasado!
        */
        void Borrar(int id, Type type);
        void Info(bool Visibilidad, int Icon, string Informacion);
        void Info(bool Visibilidad);
    }
}
