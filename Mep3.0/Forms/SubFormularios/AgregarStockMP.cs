
using Mep3._0.Entidades.Especificas;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mep3._0
{
    public partial class AgregarStockMP : Form
    {
        MateriaPrima mp;
        frmMENU MENU;
        float Stock;
        float StockAnterior;

        // Constructor y Loader
        public AgregarStockMP(MateriaPrima mp)
        {            
            InitializeComponent();
            this.mp = new MateriaPrima(mp);
            StockAnterior = mp.Stock;

        }
        private void subform_AgregarStockMP_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false, 0, "");

            this.Size = new Size(489, 367);

            Inicializar();
        }




        // Buttons
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Consulta;
            Consulta = ValidarTXTs();

            if (Consulta != "GOOD")
            {
                MENU.Info(true, 0, Consulta);
                Inicializar();
            }
            else
            {
                Agregar_alStock();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        // Functions
        private void Agregar_alStock()
        {
            // Actualizo el stock del Material en la DataBase !
            mp.Stock += Stock;
            if (MENU.DB.ActualizarMateriaPrima(mp) != "GOOD")
                MENU.Info(true, 0, "No se pudo agregar el stock por una Falla en el sistema, Reintente");


            // Serializo el ingreso de stock...
            var ingresoMP = new ReposicionDeStock(mp, Stock);
            ingresoMP.Serializar();


            // LoggEntry...
            Logger.Material(mp, "REPOSICION DE STOCK", StockAnterior, mp.Stock);


            // End.
            MENU.RefreshMatPrima();
            MENU.MostrarDTGVmp();
            MENU.Info(true, 1, Stock.ToString() + " kgs. Agregados a " + mp.Nombre);
            this.Dispose();
        }
        private void Inicializar()
        {
            KeyPreview = true;
            Stock = 0;
            lblNombre.Text = mp.Nombre;
            txtStock.Text = "";
            txtStock.Focus();
        }
        private string ValidarTXTs()
        {
            string txt = txtStock.Text.Trim();
            
            txt = txt.Replace(",", ".");

            if (txt == "")
            {
                return "Campo vacio ! , ingrese los Kgs";
            }

            if (!float.TryParse(txt, out Stock))
            {
                return "Hubo un error , intentalo otra vez";
            }
            
         
            return "GOOD";

        }

        private void AgregarStockMP_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnAgregar_Click(null, null);
            }
        }
    }
}
