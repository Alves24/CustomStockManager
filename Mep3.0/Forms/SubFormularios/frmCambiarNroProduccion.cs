using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mep3._0
{
    public partial class frmCambiarNroProduccion : Form
    {
        private frmMENU MENU;
        private int NuevoNumero;
        
        public frmCambiarNroProduccion()
        {
            InitializeComponent();
        }

        //Load
        private void frmCambiarNroProduccion_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false, 0, "");
        }

        //Aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            txtNum.Text.Trim();

            string Consulta;
            Consulta = CheckTxt();


            if (Consulta != "GOOD")
                MessageBox.Show(Consulta, " ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MENU.DB.ActualizarContador(NuevoNumero, "Produccion");
                MENU.Info(true, 1, "Numero de la Proxima produccion cambiado a "+ txtNum.Text);
           
                this.Dispose();
            }

        }

        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // CHEQUEOS
        private string CheckTxt ()
        {

            if (txtNum.Text == "rutapdf")
            {
                btnrutaPDF.Visible = true;

                txtNum.Location = new Point(12, 158);
                txtNum.Size = new Size(374, 33);
                return "x";
            }


            if (!int.TryParse(txtNum.Text, out NuevoNumero))
            { 
                return "Se ingreso mal el numero, intente de nuevo"; 
            }


            return "GOOD";
        }

        private void rutaPDF_Click(object sender, EventArgs e)
        {

        }
    }
}
