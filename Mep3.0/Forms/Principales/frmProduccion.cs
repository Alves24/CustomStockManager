using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;


namespace Mep3._0
{
    public partial class frmProduccion : Form
    {
        private frmMENU MENU;
        private Balde TheBalde;
        private int numero_produccion;
        private double TotalKgs;
        
        public frmProduccion(Balde ValdeElejido)
        {
            InitializeComponent();
            this.TheBalde = new Balde(ValdeElejido);
        }
        private void frmProduccion_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false, 0, "");

            DateTime date = DateTime.Now;
            txtDia.Text = date.Day.ToString();
            txtMes.Text = date.Month.ToString();
            txtAnio.Text = date.Year.ToString();

            numero_produccion = MENU.DB.LeerContadores("Produccion");
            lblNum.Text = numero_produccion.ToString();
            lblProduccionNombre.Text = TheBalde.GetNombre();
            lblProduccionColor.Text = TheBalde.GetColor();
            
            ValidarEquis();

            txt20.Focus();
        }

        // Botones
        private void btnProdOK_Click(object sender, EventArgs e)
        {
            btnProdConfirmado.Visible = true;
            timer1.Start();
        }
        private void btnProdCancel_Click(object sender, EventArgs e)
        {
            if (btnProdCancel.Text != "Salir")
            {
                MENU.Info(true, 0, "Produccion Cancelada");
            }
            Volver();
        }
        private void btnProdConfirmado_Click(object sender, EventArgs e)
        {
            int x20 = 0, x10 = 0, x4 = 0, x1 = 0;
            int dia, mes = 0 , anio = 0;
            bool good = true;

            txt20.Text.Trim();
            txt10.Text.Trim();
            txt4.Text.Trim();
            txt1.Text.Trim();

            if (txt20.Text == "") { txt20.Text = "0"; }
            if (txt10.Text == "") { txt10.Text = "0"; }
            if (txt4.Text == "") { txt4.Text = "0"; }
            if (txt1.Text == "") { txt1.Text = "0"; }

            if (txt20.Text == "X") txt20.Text = "0";
            if (txt10.Text == "X") txt10.Text = "0";
            if (txt4.Text == "X") txt4.Text = "0";
            if (txt1.Text == "X") txt1.Text = "0";

            // Validacion 1 - Kilogramos Totales
            if (TotalKgs < 400 || TotalKgs > 1250)
            {
                MENU.Info(true, 0, "Los Kilogramos totales de la produccion no corresponden, intentalo otra vez");
                good = false;
            }
            
            // Validacion 2 - Pifio una tecla ? Produccion
            if (!int.TryParse(txt20.Text, out x20) || !int.TryParse(txt10.Text, out x10) || !int.TryParse(txt4.Text, out x4) || !int.TryParse(txt1.Text, out x1))
            {
                MENU.Info(true, 0, " Hubo un error , intentalo otra vez");
                good = false;
            }

            // Validacion 3 - Pifio una tecla ? Fecha
            if (!int.TryParse(txtDia.Text, out dia) || !int.TryParse(txtMes.Text, out mes) || !int.TryParse(txtAnio.Text, out anio))
            {
                MENU.Info(true, 0, " Hubo un error , intentalo otra vez");
                good = false;
            }

            var date = DateTime.Now;
            new DateTime(anio, mes, dia, date.Hour, date.Minute, date.Second);
            TheBalde.Fecha = date;

            // Resolucion

            if (good)
            {
                IngresarProducion(x20, x10, x4, x1);
            }
            else
            {
                btnProdConfirmado.Visible = false;
                ValidarEquis();
            }
            
        }

        private void IngresarProducion (int x20 , int x10 , int x4 , int x1)
        {
            var Etiquetas = new bool[4];
            TheBalde.Produccion(x20, x10, x4, x1, numero_produccion);

            if (MENU.DB.ActualizarBalde(TheBalde , "Produccion") == "GOOD")
            {
                // 1 - Actualizo Contador de produccion
                MENU.DB.ActualizarContador(numero_produccion + 1 , "Produccion");

                // 2 - Aca ya uso el "TheBalde" como registro de PRODUCCION y RECETA
                TheBalde.SetBaldes(x20, x10, x4, x1);

                // 3 - Seteo los Baldes Con o Sin Etiqueta [TEMPORAL] !!!
                Etiquetas[0] = lbl20Con.Visible ? true : false;
                Etiquetas[1] = lbl10Con.Visible ? true : false;
                Etiquetas[2] = lbl4Con.Visible  ? true : false;
                Etiquetas[3] = lbl1Con.Visible  ? true : false;

                
                // Registro y Log.. uwu
                MENU.Produccion(TheBalde , Etiquetas);

                // Registro de produccion Terminado (Y)
                MENU.Info(true, 1, "Produccion Registrada");
                Disablear();
                Volver();
            }
            else
            {
                TheBalde.SetBaldes(0,0,0,0);
                MENU.Info(true, 0, "Falla en el sistema, Reintente ingresar la produccion");
            }
        }
        private void Volver()
        {
            MENU.AlumantaIcon.Enabled = true;
            MENU.AlumantaIcon.Visible = true;
            MENU.panelForms.Visible = false;
            this.Dispose();
        }
        private void Disablear()
        {
            txt20.Enabled = false;
            txt10.Enabled = false;
            txt4.Enabled = false;
            txt1.Enabled = false;
            btnProdConfirmado.Enabled = false;
            btnProdOK.Enabled = false;
            btnProdCancel.Text = "Salir";

        }
        private void ValidarEquis()
        {

            if (TheBalde.Get20() == -999)
            {
                txt20.Text = "X";
                txt20.Enabled = false;
            }
            else txt20.Text = "";

            if (TheBalde.Get10() == -999)
            {
                txt10.Text = "X";
                txt10.Enabled = false;
            }
            else txt10.Text = "";

            if (TheBalde.Get4() == -999)
            {
                txt4.Text = "X";
                txt4.Enabled = false;
            }
            else txt4.Text = "";

            if (TheBalde.Get1() == -999)
            {
                txt1.Text = "X";
                txt1.Enabled = false;
            }
            else txt1.Text = "";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnProdConfirmado.Visible = false;
            timer1.Stop();                  
        }
        private void txt20_TextChanged(object sender, EventArgs e)
        {
            Calcular_TotalKgs();
        }
        private void txt10_TextChanged(object sender, EventArgs e)
        {
            Calcular_TotalKgs();
        }
        private void txt4_TextChanged(object sender, EventArgs e)
        {
            Calcular_TotalKgs();
        }
        private void txt1_TextChanged(object sender, EventArgs e)
        {
            Calcular_TotalKgs();
        }
        private void Calcular_TotalKgs()
        {
            double total = 0;
            double pesoProducto = TheBalde.GetPeso();
            int cantidad;

            if (int.TryParse(txt20.Text, out cantidad))
                total += cantidad * pesoProducto * 20;
            if (int.TryParse(txt10.Text, out cantidad))
                total += cantidad * pesoProducto * 10;
            if (int.TryParse(txt4.Text, out cantidad))
                total += cantidad * pesoProducto * 4;
            if (int.TryParse(txt1.Text, out cantidad))
                total += cantidad * pesoProducto * 1;

            TotalKgs = total;
            lblTotal.Text = Math.Truncate(total).ToString() + " Kgs";
        }

        // Labels
        private void lbl20Sin_Click(object sender, EventArgs e)
        {
            lbl20Con.Visible = true;
            lbl20Sin.Visible = false;
        }
        private void lbl10Sin_Click(object sender, EventArgs e)
        {
            lbl10Con.Visible = true;
            lbl10Sin.Visible = false;
        }
        private void lbl4Sin_Click(object sender, EventArgs e)
        {
            lbl4Con.Visible = true;
            lbl4Sin.Visible = false;
        }
        private void lbl1Sin_Click(object sender, EventArgs e)
        {
            lbl1Con.Visible = true;
            lbl1Sin.Visible = false;
        }

        private void lbl20Con_Click(object sender, EventArgs e)
        {
            lbl20Con.Visible = false;
            lbl20Sin.Visible = true;
        }
        private void lbl10Con_Click(object sender, EventArgs e)
        {
            lbl10Con.Visible = false;
            lbl10Sin.Visible = true;
        }
        private void lbl4Con_Click(object sender, EventArgs e)
        {
            lbl4Con.Visible = false;
            lbl4Sin.Visible = true;
        }
        private void lbl1Con_Click(object sender, EventArgs e)
        {
            lbl1Con.Visible = false;
            lbl1Sin.Visible = true;
        }
    }
}
