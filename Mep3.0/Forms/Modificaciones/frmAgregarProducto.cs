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
 
    public partial class frmAgregarProducto : Form
    {
        private frmMENU MENU;

        private int x20, x10, x4, x1;
        private string Nombre, Color;
        private double Peso;
        private List<string> Nombres;
        private List<string> Colores;
        public bool Aniadir;

        public frmAgregarProducto()
        {
            InitializeComponent();
        }
        private void fNuevoProducto_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false);

            Nombres = new List<string>();
            Colores = new List<string>();

            CargarTXTs();
        }

        //Botones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string Consulta = Validaciones();

            if (Consulta != "GOOD")
            {
                MENU.Info(true, 0, Consulta);
                return;
            }

            // Agrego el Producto , TODO OK !

            VerSiHayNuevosDatos();
            string Respuesta = MENU.DB.InsertarBalde(Nombre, Color.ToUpper(), Peso, x20, x10, x4, x1, 0);
            MENU.Info(true, 1, Respuesta);
            MENU.RefreshData();       
            LimpiarTXT();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MENU.Info(false, 0, "");
            MENU.AlumantaIcon.Enabled = true;
            MENU.AlumantaIcon.Visible = true;
            MENU.panelForms.Visible = false;
            this.Dispose();
        }
       

         
        private void CargarTXTs()
        {
            Nombres = new List<string>();
            Colores = new List<string>();  

            var NombreSource   = new AutoCompleteStringCollection();
            var ColorSource    = new AutoCompleteStringCollection();

            MENU.DB.LeerTipos(ref Nombres);
            MENU.DB.LeerColores(ref Colores);
            
            for (int i = 0; i < Nombres.Count(); i++)
            {
                NombreSource.Add(Nombres[i]);
            }
            for (int i = 0; i < Colores.Count(); i++)
            {
                ColorSource.Add(Colores[i]);
            }
            
            txtNombre.AutoCompleteCustomSource = NombreSource;
            txtColor.AutoCompleteCustomSource = ColorSource;
           
        }
        private void LimpiarTXT()
        {
            txt20.Text = "";
            txt10.Text = "";
            txt4.Text = "";
            txt1.Text = "";
        }

        // VALIDACIONES
        private string Validaciones ()
        {
            string Consulta;

            Consulta = VerificarTXT();
            if (Consulta != "GOOD") return Consulta;


            
            return "GOOD";
        }
        private string VerificarTXT()
        {
            // Verificacion de campos vacios y campos numericos fallidos >:)
            txtNombre.Text.Trim();
            txtColor.Text.Trim();
            txtPeso.Text.Trim();
            txt20.Text.Trim();
            txt10.Text.Trim();
            txt4.Text.Trim();
            txt1.Text.Trim();

            if (txtNombre.Text == "")
            {
                return "El campo 'Nombre' esta vacio !";
            }
            if (txtColor.Text == "")
            {
                return "El campo 'Color' esta vacio !";
            }
            if (txtPeso.Text == "")
            {
                return "El campo 'Peso' esta vacio !";
            }

            if (txt20.Text == "") { txt20.Text = "0"; }
            if (txt10.Text == "") { txt10.Text = "0"; }
            if (txt4.Text  == "") { txt4.Text  = "0"; }
            if (txt1.Text  == "") { txt1.Text  = "0"; }

            if (txt20.Text == "X") txt20.Text = "-999";
            if (txt10.Text == "X") txt10.Text = "-999";
            if (txt4.Text  == "X") txt4.Text  = "-999";
            if (txt1.Text  == "X") txt1.Text  = "-999";

            if (txt20.Text == "x") txt20.Text = "-999";
            if (txt10.Text == "x") txt10.Text = "-999";
            if (txt4.Text  == "x") txt4.Text  = "-999";
            if (txt1.Text  == "x") txt1.Text  = "-999";
            
            if (!int.TryParse(txt20.Text, out x20) )
            {
                return "El campo '20Kgs' es invalido !";
            }

            if (!int.TryParse(txt10.Text, out x10))
            {
                return "El campo '10Kgs' es invalido !";
            }

            if (!int.TryParse(txt4.Text, out x4))
            {
                return "El campo '4Kgs' es invalido !";
            }

            if (!int.TryParse(txt1.Text, out x1))
            {
                return "El campo '1Kg' es invalido !";
            }

            if (!double.TryParse(txtPeso.Text, out Peso))
            {
                return "El campo 'PesoxKg' es invalido !";
            }

            return "GOOD";
        }
        private void VerSiHayNuevosDatos()
        {
            bool nuevosdatos = false;

            if(!BuscarNombre())
            {
                MENU.DB.InsertarTipo(this.Nombre);
                nuevosdatos = true;
            }

            if(!BuscarColor())
            {
                MENU.DB.InsertarColor(this.Color);
                nuevosdatos = true;
            }

            if (nuevosdatos)
                CargarTXTs();
        }
        
        
        private bool BuscarNombre()
        {
            string aux = txtNombre.Text;

            for (int i = 0; i<Nombres.Count; i++)
            {
                if (Nombres[i].ToUpper() == aux.ToUpper())
                {
                    this.Nombre = Nombres[i];
                    return true;
                }
            }

            this.Nombre = aux;
            return false;
        }
        private bool BuscarColor()
        {
            string aux = txtColor.Text;

            for (int i = 0; i < Colores.Count; i++)
            {
                if (Colores[i].ToUpper() == aux.ToUpper())
                {
                    this.Color = Colores[i];
                    return true;
                }
            }

            this.Color = aux;
            return false;
        }




    }
}
