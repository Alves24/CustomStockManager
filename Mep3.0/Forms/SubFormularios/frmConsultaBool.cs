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
    public partial class frmConsultaBool : Form
    {
        Action<bool> action;

        public frmConsultaBool( Action<bool> action , string Mensaje1 , string Mensaje2 )
        {
            InitializeComponent();

            this.action = action;
            this.lblMensaje1.Text = Mensaje1;
            this.lblMensaje2.Text = Mensaje2;

            this.ShowDialog();
        }
        
        private void btnSI_Click(object sender, EventArgs e)
        {
            action(true);
            this.Dispose();
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            action(false);
            this.Dispose();
        }
    }
}
