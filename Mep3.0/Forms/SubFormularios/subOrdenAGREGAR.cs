
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
    public partial class subOrdenAGREGAR : Form
    {
        private int x20, x10, x4, x1;
        private frmOrden ORDEN;
        private Balde TheValde;


        public subOrdenAGREGAR(Balde TheValde)
        {
            InitializeComponent();
            this.TheValde = TheValde;
        }
        private void frmOrdenAgregarProducto_Load(object sender, EventArgs e)
        {
            ORDEN = Owner as frmOrden;
            ORDEN.Info(false, 0, "");

            this.Size = new Size(321, 476);
            this.KeyPreview = true;
            Inicializar();
            txt20.Focus();
        }

        // Aniadir
        private void btnAniadir_Click(object sender, EventArgs e)
        {
            string Consulta;
            Consulta = VerificarNumeroDeValdes();
            
            if (Consulta != "GOOD") 
            { 
                ORDEN.Info(true, 0, Consulta);
                Inicializar();
                txt20.Focus();
            }
            else
            {
                int id = TheValde.GetID();
                int posList = ORDEN.Orden.Products.BuscarValdeByID( id );
                if ( posList == -1) 
                {
                    // NO existe en la Lista de la ORDEN 
                    // AGREGO :
                    TheValde.Modificar(x20, x10, x4, x1);
                    ORDEN.Orden.Products.baldes.Add( TheValde );
                }
                else
                {
                    // Ya Existe 
                    // SUMO :
                    ORDEN.Orden.Products.baldes[posList].Sumar(x20, x10, x4, x1);
                }

                ORDEN.IngresoProducto = true;
                ORDEN.Info(false, 0, "");
                this.Dispose();
            }

        }

        

        // Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ORDEN.Info(false, 0, "");
            this.Dispose();
        }

        // Keypress
        private void subOrdenAGREGAR_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAniadir_Click(null, null);
            }
        }
        private void Inicializar()
        {
            lblNombre.Text = TheValde.GetNombre();
            lblColor.Text  = TheValde.GetColor();
            txt20.Text = "";
            txt10.Text = "";
            txt4.Text  = "";
            txt1.Text  = "";
            txt20.Enabled = true;
            txt10.Enabled = true;
            txt4.Enabled  = true;
            txt1.Enabled  = true;

            if (TheValde.Get20() == -999)
            {
                txt20.Text = "X";
                txt20.Enabled = false;
            }
            if (TheValde.Get10() == -999)
            {
                txt10.Text = "X";
                txt10.Enabled = false;
            }
            if (TheValde.Get4() == -999)
            {
                txt4.Text  = "X";
                txt4.Enabled  = false;
            }
            if (TheValde.Get1() == -999 )
            {
                txt1.Text  = "X";
                txt1.Enabled  = false;
            }
            txt20.Focus();
        }
        private string VerificarNumeroDeValdes()
        {
            txt20.Text.Trim();
            txt10.Text.Trim();
            txt4.Text.Trim();
            txt1.Text.Trim();

            if (txt20.Text == "") txt20.Text = "0";
            if (txt10.Text == "") txt10.Text = "0";
            if (txt4.Text  == "") txt4.Text  = "0";
            if (txt1.Text  == "") txt1.Text  = "0";

            if (txt20.Text == "X") txt20.Text = "0";
            if (txt10.Text == "X") txt10.Text = "0";
            if (txt4.Text  == "X") txt4.Text  = "0";
            if (txt1.Text  == "X") txt1.Text  = "0";

            if (!int.TryParse(txt20.Text, out x20) || !int.TryParse(txt10.Text, out x10) || !int.TryParse(txt4.Text, out x4) || !int.TryParse(txt1.Text, out x1))
            {
                return " Se ingreso mal algun numero , intente de nuevo ";
            }
            else return "GOOD";
        }
    }
}
