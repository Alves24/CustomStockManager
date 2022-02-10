using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultas
{
    public partial class ConsultaConDelegados : Form
    {
        // Declaracion de delegado !
        public delegate void Delegado (bool value);
        public Delegado Respuesta;

        // Constructores
        public ConsultaConDelegados( Delegado Respuesta , string Mensaje1 , string Mensaje2 )
        {
            InitializeComponent();

            this.Respuesta = new Delegado(Respuesta);

            this.lblMensaje1.Text = Mensaje1;
            this.lblMensaje2.Text = Mensaje2;
            
        }
        
        // Botones
        private void btnSI_Click(object sender, EventArgs e)
        {
            Respuesta(true);
            this.Dispose();
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            Respuesta(false);
            this.Dispose();
        }

        // Metodos
    }
}
