
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
    public partial class frmModificarProductos : Form
    {
        //-------------------
        //? Variables
        //-------------------
        Balde TheValde;
        private frmMENU MENU;
        private int x20, x10, x4, x1;
        private double Peso;
        private int row;

  
        // Contructor
        public frmModificarProductos(Balde ValdeElejido)
        {
            InitializeComponent();
            TheValde = new Balde(ValdeElejido); 
        }

        // Load
        private void frmModificarProductos_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false, 0, "");

            Enablear();

            txtNombre.Text = TheValde.GetNombreCompleto();

            txtPeso.Text = TheValde.GetPeso().ToString();
            txt20.Text = TheValde.Get20().ToString();
            txt10.Text = TheValde.Get10().ToString();
            txt4.Text = TheValde.Get4().ToString();
            txt1.Text = TheValde.Get1().ToString();

            if (txt20.Text == "-999") { txt20.Text = "X"; }
            if (txt10.Text == "-999") { txt10.Text = "X"; }
            if (txt4.Text  == "-999") { txt4.Text  = "X"; }
            if (txt1.Text  == "-999") { txt1.Text  = "X"; }

        }

        // Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = true;
            TheValde = new Balde(MENU.datos.Balde);

            Enablear();

            txtNombre.Text = TheValde.GetNombreCompleto();
            txtPeso.Text = TheValde.GetPeso().ToString();
            txt20.Text = TheValde.Get20().ToString();
            txt10.Text = TheValde.Get10().ToString();
            txt4.Text = TheValde.Get4().ToString();
            txt1.Text = TheValde.Get1().ToString();

            if (txt20.Text == "-999") { txt20.Text = "X"; }
            if (txt10.Text == "-999") { txt10.Text = "X"; }
            if (txt4.Text  == "-999") { txt4.Text  = "X"; }
            if (txt1.Text  == "-999") { txt1.Text  = "X"; }

            txt20.Focus();
        }

        // Modificar
        private void btnModificar_Click_1(object sender, EventArgs e)
        {

            string Consulta = VerificarNumeroDeValdes();
            if (Consulta != "GOOD")
            {
                MENU.Info(true, 0, Consulta);
            }
            else
            {
                Guardar_Estado_DTGV(); // *1 Esto es
                TheValde.Modificar(Peso, x20, x10, x4, x1); 

                
                MENU.DB.ActualizarBalde(TheValde, "Modificacion Manual");
                MENU.RefreshData();

                Marcar_SiguienteProducto(); // *1 Para esto
                Ingresado();
                
            }

        }

        // Salir
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MENU.Info(false, 0, "");
            MENU.AlumantaIcon.Enabled = true;
            MENU.AlumantaIcon.Visible = true;
            MENU.panelForms.Visible = false;
            this.Dispose();
        }

        // Done
        private void Ingresado()
        {

            txtNombre.Text = "";
            txt20.Text = "";
            txt10.Text = "";
            txt4.Text = "";
            txt1.Text = "";
            txt20.Enabled = false;
            txt10.Enabled = false;
            txt4.Enabled = false;
            txt1.Enabled = false;


            txtPeso.Enabled = false;
            btnModificar.Enabled = false;
            MENU.Info(true, 1, TheValde.GetNombreCompleto() + " Modificado con exito ");
        }
        private void Enablear()
        {
            txt20.Enabled = true;
            txt10.Enabled = true;
            txt4.Enabled = true;
            txt1.Enabled = true;
            txtPeso.Enabled = true;
            btnModificar.Enabled = true;
        }
        private void Guardar_Estado_DTGV()
        {
            this.row = MENU.dtgvProductos.CurrentRow.Index;
        }
        private void Marcar_SiguienteProducto()
        {
            if (this.row + 1 != MENU.dtgvProductos.Rows.Count)
                this.row++;

            MENU.dtgvProductos_CambiarSelector(row);
        }

        // Validaciones
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

            if (txt20.Text == "x") txt20.Text = "-999";
            if (txt10.Text == "x") txt10.Text = "-999";
            if (txt4.Text  == "x") txt4.Text  = "-999";
            if (txt1.Text  == "x") txt1.Text  = "-999";

            if (txt20.Text == "X") txt20.Text = "-999";
            if (txt10.Text == "X") txt10.Text = "-999";
            if (txt4.Text  == "X") txt4.Text  = "-999";
            if (txt1.Text  == "X") txt1.Text  = "-999";

            if (!double.TryParse(txtPeso.Text, out Peso) || !int.TryParse(txt20.Text, out x20) || !int.TryParse(txt10.Text, out x10) || !int.TryParse(txt4.Text, out x4) || !int.TryParse(txt1.Text, out x1))
            {
                return " Se ingreso mal algun campo numerico , Verifique ";
            }
            else return "GOOD";
        }
    }
}

