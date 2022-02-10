using Consultas;
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
    // Summary:
    //     Form para ingresar ordenes de fabricacion terminadas.
    public partial class frmOrden : Form
    {
        private frmMENU MENU;
        public Productos Products;
        public OrdenDePedido Orden;
        public Balde ValdeAux;
        public bool IngresoProducto;
        public bool IngresoNuevoCliente;
        public List<string> Clientes;
        
        public frmOrden(Productos Produs, ulong NumeroOrdenAnterior)
        {
            InitializeComponent();
            Products = new Productos(Produs);
            Orden = new OrdenDePedido();
            Orden.SetNumero(NumeroOrdenAnterior);

            Orden.Products = new Productos();
            IngresoProducto = false;
            IngresoNuevoCliente = false;
        }
        public frmOrden(Productos Produs, OrdenDePedido Orden)
        {
            InitializeComponent();
            Products = new Productos(Produs);
            this.Orden = Orden;

            IngresoProducto = true;
            IngresoNuevoCliente = false;
            this.txtCliente.Text = Orden.GetCliente();
           // this.txtCliente.Enabled = false;
            this.txtNroOrden.Enabled = false;
            RefreshDTGV();
        }
        private void frmOrden_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false);

            dtgvOrden.MultiSelect = false;
            txtNroOrden.Text = Orden.GetNumero().ToString();
            CargarClientesBasedeDatos();
            txtNroOrden.Focus();
        }

        #region Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarValde();
            btnAgregar.Focus();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
            string tipo;
            foreach (DataGridViewRow row in dtgvOrden.SelectedRows)
            {
                id   = Convert.ToInt32 (dtgvOrden.Rows[row.Index].Cells[0].Value);
                tipo = Convert.ToString(dtgvOrden.Rows[row.Index].Cells[5].Value);
                EliminarProducto(tipo, id);
            }
            RefreshDTGV();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MENU.AlumantaIcon.Enabled = true;
            MENU.AlumantaIcon.Visible = true;
            MENU.panelForms.Visible = false;
            this.Dispose();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            timer1.Start();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string Consulta;
            Consulta = ValidacionesConfirmar();

            if (Consulta != "GOOD")
            {
                MENU.Info(true, 0, Consulta);
                btnConfirmar.Visible = false;
                
            }
            else
            {
                MENU.IngresarOrdenDePedido(Orden);
                MENU.Info(true, 1, $"Despachado {Orden.GetNumero()} a {Orden.GetCliente()}, ingresada con Exito !");
                MENU.dtgvProductos.MultiSelect = false;
                this.Dispose();
            }
        }
        #endregion

        #region Tablas
        private void RefreshDTGV ()
        {
            dtgvOrden.Rows.Clear();
            int n = 0;
            int nAnt = 0;
            bool Tinte = true ;
            
            foreach (Balde Aux in Orden.Products.baldes)
            {
                if (Aux.Get20() != 0)
                {
                    n = dtgvOrden.Rows.Add();
                    dtgvOrden.Rows[n].Cells[0].Value = Aux.GetID();
                    dtgvOrden.Rows[n].Cells[1].Value = Aux.Get20();
                    dtgvOrden.Rows[n].Cells[2].Value = Aux.GetNombre();
                    dtgvOrden.Rows[n].Cells[3].Value = "20 KG";
                    dtgvOrden.Rows[n].Cells[4].Value = Aux.GetColor();
                    dtgvOrden.Rows[n].Cells[5].Value = "20";
                    SetColoresDTGV(n, Tinte);
                }
                if (Aux.Get10() != 0)
                {
                    n = dtgvOrden.Rows.Add();
                    dtgvOrden.Rows[n].Cells[0].Value = Aux.GetID();
                    dtgvOrden.Rows[n].Cells[1].Value = Aux.Get10();
                    dtgvOrden.Rows[n].Cells[2].Value = Aux.GetNombre();
                    dtgvOrden.Rows[n].Cells[3].Value = "10 KG";
                    dtgvOrden.Rows[n].Cells[4].Value = Aux.GetColor();
                    dtgvOrden.Rows[n].Cells[5].Value = "10";
                    SetColoresDTGV(n, Tinte);
                }
                if (Aux.Get4() != 0)
                {
                    n = dtgvOrden.Rows.Add();
                    dtgvOrden.Rows[n].Cells[0].Value = Aux.GetID();
                    dtgvOrden.Rows[n].Cells[1].Value = Aux.Get4();
                    dtgvOrden.Rows[n].Cells[2].Value = Aux.GetNombre();
                    dtgvOrden.Rows[n].Cells[3].Value = " 4 KG";
                    dtgvOrden.Rows[n].Cells[4].Value = Aux.GetColor();
                    dtgvOrden.Rows[n].Cells[5].Value = "4";
                    SetColoresDTGV(n, Tinte);
                }
                if (Aux.Get1() != 0)
                {
                    n = dtgvOrden.Rows.Add();
                    dtgvOrden.Rows[n].Cells[0].Value = Aux.GetID();
                    dtgvOrden.Rows[n].Cells[1].Value = Aux.Get1();
                    dtgvOrden.Rows[n].Cells[2].Value = Aux.GetNombre();
                    dtgvOrden.Rows[n].Cells[3].Value = " 1 KG";
                    dtgvOrden.Rows[n].Cells[4].Value = Aux.GetColor();
                    dtgvOrden.Rows[n].Cells[5].Value = "1";
                    SetColoresDTGV(n, Tinte);
                }

                
                if ( n != nAnt ) Tinte = SwitchColor(Tinte);
                nAnt = n;
            }
            dtgvOrden.Refresh();
        }
        private void SetColoresDTGV ( int n , bool Tinte )
        {
            // Color de Letra  -  Columna 'Stock'
            Color ColorA  = System.Drawing.Color.Black;     
            
            // Color de Letra  -  Columna 'Productos' , 'Kgs' y 'Color' 
            Color ColorB  = System.Drawing.Color.FromArgb(0, 124, 204);
    
            // Color de Fondo  - Todas las Columnas , Alternando
            Color ColorD;

            if (Tinte)
            {
                ColorD = System.Drawing.Color.FromArgb(203, 255, 194);
            }
            else
            {
                ColorD = System.Drawing.Color.FromArgb(187, 235, 178);
            }

            string Letra = "Segoe UI ";
            string Letra2 = "Segoe UI Semibold";
            
            float Tamanio = 12.00F;
            Font Fuente1  = new Font(Letra, Tamanio, FontStyle.Bold);
            Font Fuente2  = new Font(Letra2, Tamanio);
           
            // Cant
            dtgvOrden.Rows[n].Cells[1].Style.ForeColor          = ColorA;
            dtgvOrden.Rows[n].Cells[1].Style.SelectionForeColor = ColorA;
            dtgvOrden.Rows[n].Cells[1].Style.SelectionBackColor = ColorD;
            dtgvOrden.Rows[n].Cells[1].Style.BackColor          = ColorD;
            dtgvOrden.Rows[n].Cells[1].Style.Font               = Fuente1;

            // Nombre
            dtgvOrden.Rows[n].Cells[2].Style.ForeColor          = ColorB;
            dtgvOrden.Rows[n].Cells[2].Style.SelectionForeColor = ColorB;
            dtgvOrden.Rows[n].Cells[2].Style.SelectionBackColor = ColorD;
            dtgvOrden.Rows[n].Cells[2].Style.BackColor          = ColorD;
            dtgvOrden.Rows[n].Cells[2].Style.Font               = Fuente2;

            // Kgs
            dtgvOrden.Rows[n].Cells[3].Style.ForeColor          = ColorB;
            dtgvOrden.Rows[n].Cells[3].Style.SelectionForeColor = ColorB;
            dtgvOrden.Rows[n].Cells[3].Style.SelectionBackColor = ColorD;
            dtgvOrden.Rows[n].Cells[3].Style.BackColor          = ColorD;
            dtgvOrden.Rows[n].Cells[3].Style.Font               = Fuente2;

            // Color
            dtgvOrden.Rows[n].Cells[4].Style.ForeColor          = ColorB;
            dtgvOrden.Rows[n].Cells[4].Style.SelectionForeColor = ColorB;
            dtgvOrden.Rows[n].Cells[4].Style.SelectionBackColor = ColorD;
            dtgvOrden.Rows[n].Cells[4].Style.BackColor          = ColorD;
            dtgvOrden.Rows[n].Cells[4].Style.Font               = Fuente2;

            // Header Filas
            dtgvOrden.Rows[n].HeaderCell.Style.BackColor = ColorD;
            
        }
        private bool SwitchColor(bool Color)
        {
            if (Color)
            {
                Color = false;
            }
            else
                Color = true;

            return Color;
        }
        #endregion
        
        #region Clientes   
        private void CargarClientesBasedeDatos()
        {
            MENU.DB.LeerClientes(ref Clientes);
            var sourceClientes = new AutoCompleteStringCollection();

            foreach(var cliente in Clientes)
            {
                sourceClientes.Add(cliente);
            }

            txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.AutoCompleteCustomSource = sourceClientes;
        }
        private bool ConsultaNuevoCliente()
        {
            // Ante el ingreso de un cliente hay que corroborar 2 cosas

            // 1) Si el cliente ya exite, todo tranca ( return true; )

            // 2) Si no exite en la DB, preguntar si el usuario quiere efectivamente agregarlo... en caso de NO agregarlo ( return false;)


            // 1
            foreach (var cliente in Clientes)
            {
                if  ( txtCliente.Text.ToUpper() == cliente.ToUpper())
                {
                    return true;
                }
            }

            // 2 
            var consultita = new ConsultaConDelegados
                (
                AgregarNuevoCliente,
                "Se ingreso un nombre de cliente NUEVO, " +
                "Esta seguro que no se ingreso anteriormente con otro nombre?",
                $"Cliente = {txtCliente.Text}"
                );
                consultita.ShowDialog();

            if (!IngresoNuevoCliente)
                return false;
           
            return true;
        }
        private void AgregarNuevoCliente(bool valor)
        {
            if (valor)
            {
                try
                {
                    MENU.DB.InsertarCliente(txtCliente.Text);
                    IngresoNuevoCliente = true;
                }
                catch (Exception e)
                {
                    MENU.Info(true, 0, $"ERROR nuevo cliente {e.Message}");
                    IngresoNuevoCliente = false;
                }
            }
            else
            {
                IngresoNuevoCliente = false;
            }
        }
        #endregion

        #region Estado De Orden
        private void SwitchLabel()
        {
            if (lblOrdenCompleta.Visible == true)
            {
                lblOrdenIncompleta.Visible = true;
                lblOrdenCompleta.Visible = false;
            }
            else
            {
                lblOrdenIncompleta.Visible = false;
                lblOrdenCompleta.Visible = true;
            }

        }
        private void lblOrdenIncompleta_Click(object sender, EventArgs e)
        {
            SwitchLabel();
        }
        private void lblOrdenCompleta_Click(object sender, EventArgs e)
        {
            SwitchLabel();
        }
        #endregion

        public void AgregarValde()
        {
            int id;
            int list_pos;
            Balde BaldeAux;
            subOrdenAGREGAR ADD;
            IngresoProducto = false;

            foreach (DataGridViewRow row in MENU.dtgvProductos.SelectedRows)
            {
                id = Convert.ToInt32(MENU.dtgvProductos.Rows[row.Index].Cells[7].Value);
                list_pos = Products.BuscarValdeByID(id);
                BaldeAux = new Balde(Products.baldes[list_pos]);


                ADD = new subOrdenAGREGAR(BaldeAux);
                AddOwnedForm(ADD);
                ADD.ShowDialog();
            }

            if (IngresoProducto)
            {
                RefreshDTGV();
                btnAgregar.Focus();
            }

            MENU.dtgvProductos.Focus();

        }
        private void EliminarProducto(string Tipo, int id)
        {
            if (Tipo == "20")
            {
                int pos = Orden.Products.BuscarValdeByID(id);
                Orden.Products.baldes[pos].SetBalde(20, 0);
            }
            if (Tipo == "10")
            {
                int pos = Orden.Products.BuscarValdeByID(id);
                Orden.Products.baldes[pos].SetBalde(10, 0);
            }
            if (Tipo == "4")
            {
                int pos = Orden.Products.BuscarValdeByID(id);
                Orden.Products.baldes[pos].SetBalde(4, 0);
            }
            if (Tipo == "1")
            {
                int pos = Orden.Products.BuscarValdeByID(id);
                Orden.Products.baldes[pos].SetBalde(1, 0);
            }
        }
        private string ValidacionesConfirmar()
        {
            if (Orden.Products.baldes.Count() == 0)
            {
                return "No se ingreso ningun producto a la orden !!";
            }

            if (Orden.GetNumero() != Convert.ToUInt32(txtNroOrden.Text))
            {
                Orden.SetNumero(Convert.ToUInt32(txtNroOrden.Text));
                MENU.DB.ActualizarContador(Convert.ToInt32(txtNroOrden.Text), "Orden");
                return "Numero de orden ERROR";
            }
            
            if (txtCliente.Text == "")
                return "No se ingreso el Cliente !! Ingreselo y confirme nuevamente.";

            if (ConsultaNuevoCliente() == false)
                return $"Ingreso de orden {Orden.GetNumero()} cancelado, escriba el cliente nuevamente.";

            
            return "GOOD";
        }

        // txts
        private void txtNroOrden_Leave(object sender, EventArgs e)
        {
            if (txtNroOrden.Text.Trim() == "")
                txtNroOrden.Text = Orden.GetNumero().ToString();
            if (!ulong.TryParse(txtNroOrden.Text, out ulong aux))
            {
                txtNroOrden.Text = Orden.GetNumero().ToString();
            }
            else
            {
                Orden.SetNumero(aux);
            }

        }
        private void txtCliente_Leave(object sender, EventArgs e)
        {
            var texto = txtCliente.Text.Trim();

            if (texto.Length <= 1)
            {
                txtCliente.Focus();
            }
            else
            {
                txtCliente.Text = char.ToUpper(texto[0]) + texto.Substring(1);
                Orden.SetCliente(texto);
            }
        }

        // Others.
        public void Info(bool Visibilidad, int Icon, string Informacion)
        {
            MENU.Info(Visibilidad, Icon, Informacion);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
            timer1.Stop();
        }
        public new void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);

            MENU.dtgvProductos.MultiSelect = false;
        }
    }
}
