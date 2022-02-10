using System;
using System.Windows.Forms;

namespace Mep3._0
{
    public partial class form_addORmod_MP : Form
    {
        private frmMENU MENU;
        private float Stock;
        private float StockMinimo;
        private float StockAnterior;
        private string Nombre;
        private MateriaPrima mp;

        private void form_Agregar_MP_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false, 0, "");
            MENU.MostrarDTGVmp();
            KeyPreview = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // Agregando una MP
        public form_addORmod_MP() // Agregando MP
        {
            InitializeComponent();
            InicializarADD();
            btnModificarMP.Enabled = false;
            btnModificarMP.Visible = false;

            txtNombre.Focus();
        }

        private void InicializarADD()
        {
            this.Text = "Agregando una materia prima";
            txtNombre.Text = "";
            txtStockActual.Text = "";
            txtStockMinimo.Text = "";
            cbxEsUnBalde.Checked = false;
            cbxInfinito.Checked = false;
            Stock = 0;

            txtStockActual.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Consulta = ValidarTXTs();

            if (Consulta != "GOOD")
                MENU.Info(true, 0, Consulta);
            else
            {
                MateriaPrima Mp = new MateriaPrima(Nombre, Stock, StockMinimo, cbxInfinito.Checked, cbxEsUnBalde.Checked);
                if (MENU.DB.InsertarMateriaPrima(Mp) == "GOOD")
                {
                    MENU.Info(true, 1, "Nueva Materia prima agregada !");
                    MENU.RefreshMatPrima();
                    InicializarADD();
                }
                else
                    MENU.Info(true, 0, "No se pudo agregar devido a una falla en el sistema , intente nuevamente");
            }
        }

        // Modificando una MP
        public form_addORmod_MP(MateriaPrima mp) // Modificando MP
        {
            InitializeComponent();
            this.Text = " Modificando datos de " + mp.Nombre;
            this.mp = new MateriaPrima(mp);
            this.StockAnterior = mp.Stock;

            InicializarMOD();
            btnAgregar.Enabled = false;
            btnAgregar.Visible = false;

            txtStockActual.Focus();
        }

        private void InicializarMOD()
        {
            this.Text = "Modificando datos de " + mp.Nombre;
            txtNombre.Text = mp.Nombre;
            txtStockActual.Text = mp.Stock.ToString();
            txtStockMinimo.Text = mp.StockMinimo.ToString();
            cbxInfinito.Checked = mp.Infinito ? true : false;
            cbxEsUnBalde.Checked = mp.EsUnBalde ? true : false;

            txtStockActual.Focus();
        }

        private void TerminarMOD()
        {
            this.Dispose();
        }

        private void btnModificarMP_Click(object sender, EventArgs e)
        {
            string Consulta = ValidarTXTs();

            if (Consulta != "GOOD")
                MENU.Info(true, 0, Consulta);
            else
            {
                mp.Stock = Stock;
                mp.StockMinimo = StockMinimo;
                mp.Nombre = Nombre;
                mp.EsUnBalde = cbxEsUnBalde.Checked;
                mp.Infinito = cbxInfinito.Checked;

                if (MENU.DB.ActualizarMateriaPrima(mp) == "GOOD")
                {
                    MENU.Info(true, 1, "Modificacion realizada !");
                    MENU.RefreshMatPrima();
                    Logger.Material(mp, "MODIFICACION MANUAL", StockAnterior, Stock);
                    TerminarMOD();
                }
                else
                    MENU.Info(true, 0, "No se pudo agregar devido a una falla en el sistema , intente nuevamente");
            }
        }

        // FUNCIONES PURAS
        private string ValidarTXTs()
        {
            txtNombre.Text.Trim();
            txtStockActual.Text.Trim();
            txtStockMinimo.Text.Trim();

            txtNombre.Text = txtNombre.Text.Replace(",", ".");
            txtStockActual.Text = txtStockActual.Text.Replace(",", ".");
            txtStockMinimo.Text = txtStockMinimo.Text.Replace(",", ".");

            if (txtNombre.Text == "")
                return "Campo 'Nombre' Vacio.";
            Nombre = txtNombre.Text;

            if (txtStockMinimo.Text == "") txtStockMinimo.Text = "0";
            if (txtStockActual.Text == "") txtStockActual.Text = "0";

            if (!float.TryParse(txtStockActual.Text, out Stock))
                return "Campo 'Stock Actual' es un capo numerico";
            if (!float.TryParse(txtStockMinimo.Text, out StockMinimo))
                return "Campo 'Stock Minimo' es un capo numerico";

            if (btnAgregar.Enabled)
            {
                if (MENU.ExistenciaMateriaPrima(Nombre))
                    return "Ya existe una materia prima con el mismo nombre !";
            }

            return "GOOD";
        }

        private void form_addORmod_MP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnAgregar.Enabled && btnAgregar.Visible)
                {
                    btnAgregar_Click(null, null);
                }
                else
                if (btnModificarMP.Enabled && btnModificarMP.Visible)
                {
                    btnModificarMP_Click(null, null);
                }
            }
        }
    }
}