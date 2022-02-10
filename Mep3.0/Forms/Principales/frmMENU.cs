using LibreriaPersonal;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExcelReader;

namespace Mep3._0
{
    public partial class frmMENU : Form, IForm
    {
        public DTGVdata datos;
        public Productos Products;
        public Database DB;
        public List<MateriaPrima> mp;
        public List<OrdenDePedido> OrdenesDropBox;

        public frmMENU()
        {
            InitializeComponent();
        }
        private void MENU_Load(object sender, EventArgs e)
        {
            DB = new Database();
            datos = new DTGVdata(DB.LeerContadores("Produccion"));
            Products = new Productos();
            OrdenesDropBox = new List<OrdenDePedido>();

            KeyPreview = true;
            RefreshData();

            this.Size = new Size(1376, 744);
            this.WindowState = FormWindowState.Maximized;

            dtgvProductos.RowHeadersWidth = 42;
            dtgvMateriaPrima.RowHeadersWidth = 42;
        }

        #region ||||FORMs||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        private void CreadorDeForm(Form frm)
        {
            panelForms.Visible = true;
            if (this.panelForms.Controls.Count > 0)
                this.panelForms.Controls.RemoveAt(0);

            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.Size = new Size(715, 614);   // TAMANIO DEL PANEL

            this.panelForms.Controls.Add(frm);
            this.panelForms.Tag = frm;
            frm.Show();
        }
        // Orden
        private void CrearOrdenDePedido(object sender, EventArgs e)
        {
            ulong Numero_de_Orden = Convert.ToUInt32(DB.LeerContadores("Orden").ToString());

            frmOrden VentanaOrden = new frmOrden(Products, Numero_de_Orden);
            AddOwnedForm(VentanaOrden);
            CreadorDeForm(VentanaOrden);
        }
        public void IngresarOrdenDePedido(OrdenDePedido Orden)
        {
            int pos;

            //   1 RESTO ORDEN
            for (int i = 0; i < Orden.Products.baldes.Count; i++)
            {
                // Busco el indice del Producto de la Orden en el STOCK
                pos = Products.BuscarValdeByID(Orden.Products.baldes[i].GetID());

                // Le resto el Balde de la Orden al respectivo Balde del Stock (misma ID)
                Products.baldes[pos].Restar(Orden.Products.baldes[i]);

                // Actualizo el Balde en la DataBase
                DB.ActualizarBalde(Products.baldes[pos], $" Ingreso de orden {Orden.GetNumero()}");
            }
            RefreshData();

            //  2 AUMENTO NRO ORDEN
            DB.ActualizarContador((int)Orden.GetNumero() + 1, "Orden");

            //  3 SERIALIZO ORDEN
            Orden.Serializar();
        }
        public void Excel_VerOrdenes(object sender, EventArgs e)
        {
            Excel_frmVerOrdenes ventana;

            if (OrdenesDropBox.Count > 0)
            {
                ventana = new Excel_frmVerOrdenes(OrdenesDropBox);
            }
            else
            {
                ventana = new Excel_frmVerOrdenes(Excel_Orders.Get(Products));
            }

            AddOwnedForm(ventana);
            CreadorDeForm(ventana);
        }
        public void Excel_EditarOrden(OrdenDePedido Orden)
        {
            frmOrden VentanaOrden = new frmOrden(Products, Orden);
            AddOwnedForm(VentanaOrden);
            CreadorDeForm(VentanaOrden);
        }
       
        // Produccion
        private void btnProduccion_Click(object sender, EventArgs e)
        {
            frmProduccion VentanaProduccion = new frmProduccion(datos.Balde);
            AddOwnedForm(VentanaProduccion);
            CreadorDeForm(VentanaProduccion);
        }
        public void Produccion(Balde TheBalde, bool[] Etiquetas)
        {
            if (TheBalde.FlagRecipe)
            {
                string motivo = $"Produccion INGRESADA [{TheBalde.numero_produccion}] | [{TheBalde.GetNombreCompleto()}]";

                // Resto MATERIA PRIMA de la produccion !!
                foreach (MateriaPrima Mp in TheBalde.Recipe)
                {
                    if (Mp.Infinito != true)
                    {
                        DB.RestarMateriaPrima(Mp, Mp.Stock, motivo);
                    }
                }
                // Restar los baldes VACIOS
                DB.RestarVacios(TheBalde, Etiquetas, motivo);
            }
            else
            {
                // SIN receta...
                frmConsulta formConsulta = new frmConsulta("El producto producido no posee receta.\n" +
                                                            "No se restara ninguna materia prima ni baldes vacios del stock.");
                formConsulta.ShowDialog();
            }

            // Serializo PRODUCCION
            string consulta = TheBalde.Serializar();
            VerConsulta(consulta);

            RefreshData();
        }
        
        // Nuevos Productos
        private void NuevoProducto_Click(object sender, EventArgs e)
        {
            frmAgregarProducto Ventana = new frmAgregarProducto();
            AddOwnedForm(Ventana);
            CreadorDeForm(Ventana);
        }
       
        // Modificar Productos
        private void ModDatosdeProductos_Click(object sender, EventArgs e)
        {
            frmModificarProductos VentanaModProductos = new frmModificarProductos(datos.Balde);
            AddOwnedForm(VentanaModProductos);
            CreadorDeForm(VentanaModProductos);
        }
        private void ModNumeroDeProduccion_Click(object sender, EventArgs e)
        {
            frmCambiarNroProduccion VentanaNroProduccion = new frmCambiarNroProduccion();
            AddOwnedForm(VentanaNroProduccion);
            VentanaNroProduccion.Show();
        }
        private void BorrarProducto_Click(object sender, EventArgs e)
        {
            string msj1 = "Esta seguro que quiere eliminar del sistema a : ";
            string msj2 = "";
            int id = 0;
            Type type = null;

            // Me fijo el tipo que quiero borrar
            if (datos.ultProducto == "BALDE")
            {
                type = typeof(Balde);
                msj2 = datos.Balde.GetNombreCompleto();
                id = datos.Balde.GetID();
            }
            if (datos.ultProducto == "MP")
            {
                type = typeof(MateriaPrima);
                msj2 = datos.Mp.Nombre;
                id = datos.Mp.id;
            }

            // Checkeo que sea una materia prima permitida de borrar
            if (type == typeof(MateriaPrima) && id <= 5)
            {
                Info(true, 0, "No se puede borrar la materia prima seleccionada.");
                type = null;
            }

            // Muestro Form Consulta
            if (type != null)
            {
                frmConsulta Form = new frmConsulta(msj1, msj2, id, type);
                Form.Show(this);
            }
        }
        private void BorrarReceta_Click(object sender, EventArgs e)
        {
            Type type = typeof(List<MateriaPrima>);
            string msj1 = "Esta seguro que quiere eliminar la receta de: ";
            string msj2 = datos.Balde.GetNombreCompleto();
            int id = datos.Balde.GetID();

            frmConsulta Form = new frmConsulta(msj1, msj2, id, type);
            Form.Show(this);
        }
        private void BorrarMenu_Click(object sender, EventArgs e)
        {
            frmVerMasRegistros Ventana = new frmVerMasRegistros();
            AddOwnedForm(Ventana);
            CreadorDeForm(Ventana);
        }

        // Materia Prima
        private void NuevaMP_Click(object sender, EventArgs e)
        {
            form_addORmod_MP Ventana = new form_addORmod_MP();
            AddOwnedForm(Ventana);
            Ventana.ShowDialog();
        }
        private void ModReceta_Click(object sender, EventArgs e)
        {
            frmModificarRecetas Ventana = new frmModificarRecetas(datos.Balde);
            AddOwnedForm(Ventana);
            CreadorDeForm(Ventana);
        }
        public int BuscarMateriaPrima(int id)
        {
            int i = 0;
            foreach (MateriaPrima aux in mp)
            {
                if (aux.id == id)
                { return i; }

                i++;
            }
            return -1;
        }
        public bool ExistenciaMateriaPrima(string Nombre)
        {
            foreach (MateriaPrima aux in mp)
            {
                if (aux.Nombre == Nombre)
                { return true; }
            }
            return false;
        }
        private void Modificar_MP_Click(object sender, EventArgs e)
        {
            if (datos.Mp != null)
            {
                int row = dtgvMateriaPrima.CurrentRow.Index;

                form_addORmod_MP Ventana = new form_addORmod_MP(datos.Mp);
                AddOwnedForm(Ventana);
                Ventana.ShowDialog();

                dtgvMateriaprima_CambiarSelector(++row);
            }
        }
        private void btnAgregarStockMP_Click(object sender, EventArgs e)
        {
            AgregarStockMP ventana = new AgregarStockMP(datos.Mp);
            AddOwnedForm(ventana);
            ventana.ShowDialog();
        }

        // Ver Datita
        private void ProduccionesIngresadas_Click(object sender, EventArgs e)
        {
        }
        private void OrdenesIngresadas_Click(object sender, EventArgs e)
        {
            frmVerRegistros ventana = new frmVerRegistros(Deserializador.Ordenes());
            AddOwnedForm(ventana);
            CreadorDeForm(ventana);
        }
        #endregion ||||FORMs||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        #region ||||DATA||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        // Data Grid >>
        public void RefreshData()
        {
            RefreshProductos();

            RefreshMatPrima();

            MostrarDTGVproductos();

            btnProduccion.Text = "Produccion  " + DB.LeerContadores("Produccion");
        }
        public void RefreshProductos()
        {
            DB.LeerBaldes(ref Products.baldes);

            dtgvProductos.Rows.Clear();
            int n;

            foreach (Balde aux in Products.baldes)
            {
                n = dtgvProductos.Rows.Add();

                dtgvProductos.Rows[n].Cells[0].Value = aux.GetNombreCompleto();
                dtgvProductos.Rows[n].Cells[1].Value = aux.GetNombre();
                dtgvProductos.Rows[n].Cells[2].Value = aux.GetColor();
                dtgvProductos.Rows[n].Cells[3].Value = aux.Get20();
                dtgvProductos.Rows[n].Cells[4].Value = aux.Get10();
                dtgvProductos.Rows[n].Cells[5].Value = aux.Get4();
                dtgvProductos.Rows[n].Cells[6].Value = aux.Get1();
                dtgvProductos.Rows[n].Cells[7].Value = aux.GetID();
                dtgvProductos.Rows[n].Cells[8].Value = aux.FlagRecipe.ToString();
            }

            // ORDENO TABLA
            dtgvProductos.Sort(dtgvProductos.Columns[7], ListSortDirection.Ascending);

            // COLOREO
            this.SetColorProductos();

            //Updateo BALDE y POSICION actual del dtgv
            dtgvProductos.Rows[0].Cells[0].Selected = true;
            int row = dtgvProductos.CurrentRow.Index;
            int id = Convert.ToInt32(dtgvProductos.Rows[row].Cells[7].Value);
            int list_pos = Products.BuscarValdeByID(id);

            datos.SetValde(Products.baldes[list_pos], list_pos);

            dtgvProductos.Refresh();
        }
        public void RefreshMatPrima()
        {
            DB.LeerMateriaPrima(ref mp);
            List<MateriaPrima> mp_Ordenada = new List<MateriaPrima>();
            mp_Ordenada.AddRange(FilasOrdenadasMP());

            dtgvMateriaPrima.Rows.Clear();

            int n;
            foreach (MateriaPrima mpAux in mp_Ordenada)
            {
                n = dtgvMateriaPrima.Rows.Add();

                dtgvMateriaPrima.Rows[n].Cells[0].Value = mpAux.id;
                dtgvMateriaPrima.Rows[n].Cells[1].Value = mpAux.Nombre;
                dtgvMateriaPrima.Rows[n].Cells[2].Value = String.Format("{0:0.#}", mpAux.Stock);
                dtgvMateriaPrima.Rows[n].Cells[3].Value = mpAux.StockMinimo;
                dtgvMateriaPrima.Rows[n].Cells[4].Value = mpAux.Infinito;
                dtgvMateriaPrima.Rows[n].Cells[5].Value = mpAux.EsUnBalde;
            }

            SetColorMP();
            dtgvMateriaPrima.Refresh();
        }
        private void SetColorProductos()
        {
            Color ColorNoRecipe = System.Drawing.Color.OrangeRed;
            Color Colorx = System.Drawing.Color.IndianRed;
            Color ColorBaldes = System.Drawing.Color.FromArgb(0, 124, 204);
            Color FondoAlt = System.Drawing.Color.FromArgb(209, 209, 209);

            string Letra = "Segoe UI ";
            string Letra2 = "Segoe UI Semibold";
            float Tamanio = 12.00F;
            Font Fuente1 = new Font(Letra2, Tamanio);
            Font Fuente2 = new Font(Letra, Tamanio, FontStyle.Regular);

            int n;
            bool Alternatecolor = false;
            string nombre = dtgvProductos.Rows[0].Cells[1].Value.ToString();
            string nombreant = nombre;

            foreach (DataGridViewRow row in dtgvProductos.Rows)
            {
                n = row.Index;
                nombre = dtgvProductos.Rows[n].Cells[1].Value.ToString(); // Nombre (incompleto)

                dtgvProductos.Rows[n].Cells[3].Style.ForeColor = ColorBaldes; // 20
                dtgvProductos.Rows[n].Cells[4].Style.ForeColor = ColorBaldes; // 10
                dtgvProductos.Rows[n].Cells[5].Style.ForeColor = ColorBaldes; // 4
                dtgvProductos.Rows[n].Cells[6].Style.ForeColor = ColorBaldes; // 1
                dtgvProductos.Rows[n].Cells[0].Style.Font = Fuente2;

                // -- BALDES SIN RECETA --
                if (dtgvProductos.Rows[n].Cells[8].Value.ToString() != "True")
                {
                    dtgvProductos.Rows[n].Cells[0].Style.ForeColor = ColorNoRecipe;
                }

                // -- SWITCH BACK COLOR --
                if (nombre != nombreant)
                {
                    Alternatecolor = Alternatecolor ? false : true;
                }
                if (Alternatecolor)
                {
                    dtgvProductos.Rows[n].Cells[0].Style.BackColor = FondoAlt; // Names
                    dtgvProductos.Rows[n].Cells[3].Style.BackColor = FondoAlt; // 20
                    dtgvProductos.Rows[n].Cells[4].Style.BackColor = FondoAlt; // 10
                    dtgvProductos.Rows[n].Cells[5].Style.BackColor = FondoAlt; // 4
                    dtgvProductos.Rows[n].Cells[6].Style.BackColor = FondoAlt; // 1
                }
                nombreant = nombre;

                // -- BALDES EN "0" o "NEGATIVOS" --
                // Desde 3 hasta 6 son las columnas
                // donde van la cantidad de Baldes...
                for (int i = 3; i <= 6; i++)
                {
                    // Baldes en 0
                    if (dtgvProductos.Rows[n].Cells[i].Value.ToString() == "0")
                    {
                        if (Alternatecolor)
                        {
                            dtgvProductos.Rows[n].Cells[i].Style.ForeColor = FondoAlt;
                            dtgvProductos.Rows[n].Cells[i].Style.SelectionForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            dtgvProductos.Rows[n].Cells[i].Style.ForeColor = System.Drawing.Color.WhiteSmoke;
                            dtgvProductos.Rows[n].Cells[i].Style.SelectionForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        // Negativos ( menores a 0 )
                        if (int.Parse(dtgvProductos.Rows[n].Cells[i].Value.ToString()) < 0)
                        {
                            dtgvProductos.Rows[n].Cells[i].Style.ForeColor = System.Drawing.Color.Red;
                            dtgvProductos.Rows[n].Cells[i].Style.SelectionForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
        private void SetColorMP()
        {
            // Dtgv. Position !
            // 0 id   1 Nombre   2 stock    3 stockmin   4 infinito   5 esunbalde

            Color ColorNombre = System.Drawing.Color.Black;
            Color ColorCant = System.Drawing.Color.Black;
            Color ColorTapas = System.Drawing.Color.FromArgb(0, 50, 168);
            Color ColorStockMINIMO = System.Drawing.Color.FromArgb(240, 175, 170);
            Color ColorAlterativeCell = System.Drawing.Color.FromArgb(209, 209, 209);

            string Letra = "Segoe UI ";
            string Letra2 = "Segoe UI ";
            float Tamanio = 12.00F;
            Font Fuente1 = new Font(Letra2, Tamanio);
            Font Fuente2 = new Font(Letra, Tamanio, FontStyle.Regular);

            bool EsUnBalde;
            int n;

            foreach (DataGridViewRow row in dtgvMateriaPrima.Rows)
            {
                n = row.Index;
                dtgvMateriaPrima.Rows[n].Cells[2].Style.ForeColor = ColorCant;
                dtgvMateriaPrima.Rows[n].Cells[1].Style.ForeColor = ColorNombre;
                dtgvMateriaPrima.Rows[n].Cells[2].Style.Font = Fuente1;
                dtgvMateriaPrima.Rows[n].Cells[1].Style.Font = Fuente2;

                // Es un fucking Balde ?? le cambio el color
                EsUnBalde = Convert.ToBoolean(dtgvMateriaPrima.Rows[n].Cells[5].Value);
                if (EsUnBalde)
                {
                    dtgvMateriaPrima.Rows[n].Cells[1].Style.ForeColor = ColorTapas;
                    dtgvMateriaPrima.Rows[n].Cells[2].Style.ForeColor = ColorTapas;
                }

                // Es infinito ??? solo el agua
                if (Convert.ToBoolean(dtgvMateriaPrima.Rows[n].Cells[4].Value))
                {
                    dtgvMateriaPrima.Rows[n].Cells[2].Value = "∞";
                }

                // Alternative Cell
                if (n % 2 == 0 && !EsUnBalde)
                {
                    dtgvMateriaPrima.Rows[n].Cells[2].Style.BackColor = ColorAlterativeCell;
                    dtgvMateriaPrima.Rows[n].Cells[1].Style.BackColor = ColorAlterativeCell;
                }

                // Stock minimo ??? hay que reponer papa
                float.TryParse(dtgvMateriaPrima.Rows[n].Cells[2].Value.ToString(), out float stock);
                float.TryParse(dtgvMateriaPrima.Rows[n].Cells[3].Value.ToString(), out float stockmin);
                if (stock < stockmin)
                {
                    dtgvMateriaPrima.Rows[n].Cells[2].Style.BackColor = ColorStockMINIMO;
                }

                stock = 0;
                stockmin = 0;

                //dtgvMateriaPrima.Rows[n].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private List<MateriaPrima> FilasOrdenadasMP()
        {
            List<MateriaPrima> BaldesVacios = new List<MateriaPrima>();
            List<MateriaPrima> MatPrima = new List<MateriaPrima>();
            List<MateriaPrima> MateriaPrima_Ordenada = new List<MateriaPrima>();

            foreach (MateriaPrima aux in mp)
            {
                if (aux.EsUnBalde)
                {
                    BaldesVacios.Add(aux);
                }
                else
                {
                    MatPrima.Add(aux);
                }
            }

            MatPrima.Sort();
            MateriaPrima_Ordenada.AddRange(BaldesVacios);
            MateriaPrima_Ordenada.AddRange(MatPrima);

            return MateriaPrima_Ordenada;
        }
        private void dtgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (btnProduccion.Enabled == false)
            {
                btnProduccion.Enabled = true;
                btnOrden.Enabled = true;
                BarraMenu.Enabled = true;
            }
            else
            {
                int row = dtgvProductos.CurrentRow.Index;
                int id = Convert.ToInt32(dtgvProductos.Rows[row].Cells[7].Value);
                int list_pos = Products.BuscarValdeByID(id);

                if (list_pos >= 0)
                {
                    //Updateo VALDE y POSICION actual del dtgv
                    datos.SetValde(Products.baldes[list_pos], list_pos);
                }

                // TESTING !

                // PARA VER EL CONTADOR DE FILAS DEL DTGV Y EL INDICE DE LAS SELECCIONADAS

                /*
                string IndexDTGV = "Count: " + dtgvProductos.Rows.Count.ToString() + " Index: " + row.ToString();
                Info(true, 1, IndexDTGV);
                */
            }
        }
        private void dtgvMateriaPrima_SelectionChanged(object sender, EventArgs e)
        {
            int row = dtgvMateriaPrima.CurrentRow.Index;
            int id = Convert.ToInt32(dtgvMateriaPrima.Rows[row].Cells[0].Value);
            int list_pos = BuscarMateriaPrima(id);

            if (list_pos >= 0)
            {
                datos.SetMp(mp[list_pos], list_pos);
            }
            //MessageBox.Show(mp[list_pos].mostrar());
        }
        public void dtgvProductos_CambiarSelector(int row)
        {
            int id = Convert.ToInt32(dtgvProductos.Rows[row].Cells[7].Value);
            int list_pos = Products.BuscarValdeByID(id);

            if (list_pos >= 0)
            {
                //Updateo VALDE y POSICION actual del dtgv
                dtgvProductos.Rows[row].Cells[0].Selected = true;
                datos.SetValde(Products.baldes[list_pos], list_pos);
            }
        }
        public void dtgvMateriaprima_CambiarSelector(int row)
        {
            if (row < dtgvMateriaPrima.Rows.Count)
            {
                int id = Convert.ToInt32(dtgvMateriaPrima.Rows[row].Cells[0].Value);

                int list_pos = BuscarMateriaPrima(id);

                if (list_pos >= 0)
                {
                    dtgvMateriaPrima.Rows[row].Cells[1].Selected = true;
                    datos.SetMp(mp[list_pos], list_pos);
                }
            }
        }

        // Icons
        private void iconValdeOFF_Click(object sender, EventArgs e)
        {
            MostrarDTGVproductos();
        }
        private void iconMateriaPrimaOFF_Click(object sender, EventArgs e)
        {
            MostrarDTGVmp();
        }
        public void MostrarDTGVmp()
        {
            iconMateriaPrimaON.Visible = true;
            iconValdeOFF.Visible = true;
            iconMateriaPrimaOFF.Visible = false;
            iconValdeON.Visible = false;

            dtgvMateriaPrima.Visible = true;
            dtgvProductos.Visible = false;
            dtgvMateriaPrima.CurrentCell.Selected = false;

            btnAgregarStockMP.Visible = true;
            btnOrden.Visible = false;
            btnProduccion.Visible = false;
        }
        public void MostrarDTGVproductos()
        {
            iconValdeON.Visible = true;
            iconMateriaPrimaOFF.Visible = true;
            iconValdeOFF.Visible = false;
            iconMateriaPrimaON.Visible = false;

            dtgvMateriaPrima.Visible = false;
            dtgvProductos.Visible = true;
            dtgvProductos.CurrentCell.Selected = false;

            btnAgregarStockMP.Visible = false;
            btnOrden.Visible = true;
            btnProduccion.Visible = true;
        }

        // IFORMS
        public void Info(bool Visibilidad, int Icon, string Informacion)
        {
            lblINFO.Text = Informacion;
            iconINFObad.Visible = false;
            iconINFOgood.Visible = false;
            lblINFO.Visible = false;

            // Icon 1 GOOD
            // Icon 0 BAD

            if (Visibilidad)
            {
                lblINFO.Visible = true;
                if (Icon == 1)
                { iconINFOgood.Visible = true; }
                else { iconINFObad.Visible = true; }
            }

            TimerInfo.Start();
        }
        public void Info(bool Visibilidad)
        {
            lblINFO.Visible = Visibilidad;
            iconINFObad.Visible = Visibilidad;
            iconINFOgood.Visible = Visibilidad;
            TimerInfo.Start();
        }
        public void Borrar(int id, Type type)
        {
            if (type == typeof(MateriaPrima))
            {
                DB.Borrar(id, "tblMATERIAPRIMA");
                RefreshMatPrima();
            }
            if (type == typeof(Balde))
            {
                DB.Borrar(id, "tblPRODUCTOS");
                RefreshData();
            }
            if (type == typeof(List<MateriaPrima>))
            {
                DB.FlagReceta(false, id);
                RefreshData();
            }
        }
        
        // Otros
        public void VerConsulta(List<OrdenDePedido> Lista_de_Ordenes)
        {
            frmConsulta consulta;

            foreach (OrdenDePedido aux in Lista_de_Ordenes)
            {
                consulta = new frmConsulta(aux.mostrardatos());
                consulta.Show();
            }
        }
        public void VerConsulta(string Consulta)
        {
            if (Consulta != "GOOD")
            {
                frmConsulta Ventana = new frmConsulta(Consulta);
                Ventana.ShowDialog();
            }
        }
        public void MostrarFondoAlumanta()
        {
            AlumantaIcon.Enabled = true;
            AlumantaIcon.Visible = true;
            panelForms.Visible = false;
        }
        private void frmMENU_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
        private void TimerInfo_Tick(object sender, EventArgs e)
        {
            Info(false);
            TimerInfo.Stop();
        }
        #endregion ||||DATA||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        #region ||||Informes||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        private void InformeDelMes_Click(object sender, EventArgs e)
        {
            //htmlGenerator.Make_InformeDelMes();
            //Info(true, 1, "Hecho!");
        }
        private void InformeDelMesAnterior_Click(object sender, EventArgs e)
        {
            //htmlGenerator.Make_InformeDelMesAnterior();
            //Info(true, 1, "Hecho!");

            /* List<OrdenDePedido> List = new List<OrdenDePedido>(Deserializador.Deserializar_OrdenesDelMesAnterior());

             foreach (OrdenDePedido Aux in List)
             {
                 MessageBox.Show(Aux.mostrardatos());
             }*/
        }
        private void MenuDesplazable_Ver_produccionesIngresadas_Click(object sender, EventArgs e)
        {
            frmVerRegistros ventana = new frmVerRegistros(Deserializador.Producciones());
            AddOwnedForm(ventana);
            CreadorDeForm(ventana);
        }
        private void StockActual_Click(object sender, EventArgs e)
        {
            var Materiales = new List<MateriaPrima>(FilasOrdenadasMP());

            htmlGenerator.Make_StockActual(Materiales, this.Products.baldes, DB.LeerContadores("Produccion") - 1);

            Info(true, 1, "Informe de stock realizado con exito !");
        }
      
        #endregion ||||Informes||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        /* - Registro de teclas - */
        private void frmMENU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                if (dtgvMateriaPrima.Visible == true)
                {
                    int row = dtgvMateriaPrima.CurrentRow.Index;

                    form_addORmod_MP Ventana = new form_addORmod_MP(datos.Mp);
                    AddOwnedForm(Ventana);
                    Ventana.ShowDialog();

                    dtgvMateriaprima_CambiarSelector(++row);
                }
            }
            if (e.KeyCode == Keys.A)
            {
                foreach (frmOrden aux in panelForms.Controls.OfType<frmOrden>())
                {
                    if (aux.txtNroOrden.Focused) break;
                    if (aux.txtCliente.Focused) break;

                    aux.AgregarValde();
                }
            }
            if (e.KeyCode == Keys.R)
            {
                if (dtgvMateriaPrima.Visible && !dtgvProductos.Visible)
                {
                    btnAgregarStockMP_Click(null, null);
                }
            }

        }
    }
}