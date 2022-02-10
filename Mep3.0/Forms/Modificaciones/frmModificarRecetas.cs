
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
    public partial class frmModificarRecetas : Form
    {
        public List<MateriaPrima> Receta;
        private Balde TheBalde;
        private frmMENU MENU;
        public float KgsTotal;

        public frmModificarRecetas(Balde TheBalde )
        {
            InitializeComponent();
            this.TheBalde = new Balde(TheBalde);
        }
        private void form_ModificarRecetas_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            MENU.Info(false);
            MENU.MostrarDTGVmp();
            MENU.dtgvMateriaPrima.MultiSelect = false;
            Receta = new List<MateriaPrima>();
            KgsTotal = 0;

            lblProducto.Text = TheBalde.GetNombreCompleto();

            SetCeldasDTGV();
            btnAgregar.Focus();

            if (TheBalde.FlagRecipe)
            {
                Receta.AddRange(TheBalde.Recipe);
                foreach ( MateriaPrima aux in Receta)
                {
                    KgsTotal += aux.Stock;
                } 
            }

            RefreshDTGV();
        }



        //   Botones

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            AgregarMp();
            btnAgregar.Focus();
        }
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int pos;

            foreach (DataGridViewRow row in dtgvReceta.SelectedRows)
            {
                pos = int.Parse(dtgvReceta.Rows[row.Index].Cells[3].Value.ToString());

                if (pos >= 0 && Receta.Count > 0)
                {
                    KgsTotal -= Receta[pos].Stock;
                    Receta.RemoveAt(pos);
                }
            }
            RefreshDTGV();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
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
            }
            else
            {
                
                // Serializo Receta
                TheBalde.SerializarReceta(Receta);
               
                // Actualizo Flag
                if (TheBalde.FlagRecipe == false)
                    Consulta = MENU.DB.FlagReceta(true, TheBalde.GetID());

                if (Consulta != "GOOD")
                    MENU.Info(true, 0, Consulta);
                else
                    MENU.Info(true, 1, "Receta agregada con exito!");



                End();
            }
        }
        
        


        //   Funciones
        private void AgregarMp ()
        {
            int id;
            int list_pos;
            MateriaPrima mpAux;
            AgregarMpReceta ADD;

            foreach (DataGridViewRow row in MENU.dtgvMateriaPrima.SelectedRows)
            {
                id = Convert.ToInt32(MENU.dtgvMateriaPrima.Rows[row.Index].Cells[0].Value);
                list_pos = MENU.BuscarMateriaPrima(id);
                mpAux = new MateriaPrima(MENU.mp[list_pos]);

                if (id > 4)
                {
                    ADD = new AgregarMpReceta(mpAux);
                    AddOwnedForm(ADD);
                    ADD.ShowDialog();
                }
            }


            RefreshDTGV();
        }

        private void SetCeldasDTGV()
        {
            //DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();

            string Fuente = "Segoe UI";
            float Tamanio = 12.00F;
            dtgvReceta.AlternatingRowsDefaultCellStyle.Font = new Font(Fuente, Tamanio, FontStyle.Regular);
            dtgvReceta.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgvReceta.DefaultCellStyle.Font = new Font(Fuente, Tamanio, FontStyle.Regular);
            dtgvReceta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void RefreshDTGV()
        {
            // Id / Kgs / Ingredientes
            dtgvReceta.Rows.Clear();
            int n;
            int i = 0;
            bool Tinte;

            lblTotal.Text = String.Format("{0:0.0}", KgsTotal) + " Kgs";
            if (Receta != null)

                foreach (MateriaPrima Aux in Receta)
                {
                    n = dtgvReceta.Rows.Add();
                    dtgvReceta.Rows[n].Cells[0].Value = Aux.id;
                    dtgvReceta.Rows[n].Cells[1].Value = Aux.Stock;
                    dtgvReceta.Rows[n].Cells[2].Value = Aux.Nombre;
                    dtgvReceta.Rows[n].Cells[3].Value = i; // list pos

                    Tinte = i % 2 == 0 ? true : false;
                    SetColoresDTGV(i,Tinte);
                    i++;
                }

           dtgvReceta.Refresh();
        }
        private void SetColoresDTGV(int n, bool Tinte)
        {
            // Color de Letra  -  Columna 'Stock'
            Color ColorA = System.Drawing.Color.Black;

            // Color de Letra  -  Columna 'Productos' , 'Kgs' y 'Color' 
            Color ColorB = System.Drawing.Color.FromArgb(0, 124, 204);

            // Color de Fondo  - Todas las Columnas , Alternando
            Color ColorD;

            if (Tinte)
            {
                ColorD = System.Drawing.Color.WhiteSmoke;
            }
            else
            {
                ColorD = System.Drawing.Color.FromArgb(227, 227, 227);
            }

            string Letra = "Segoe UI ";
            string Letra2 = "Segoe UI ";

            float Tamanio = 12.00F;
            Font Fuente1 = new Font(Letra, Tamanio, FontStyle.Bold);
            Font Fuente2 = new Font(Letra2, Tamanio, FontStyle.Regular);

            // Cant
            dtgvReceta.Rows[n].Cells[1].Style.ForeColor = ColorA;
            dtgvReceta.Rows[n].Cells[1].Style.SelectionForeColor = ColorA;
            dtgvReceta.Rows[n].Cells[1].Style.SelectionBackColor = ColorD;
            dtgvReceta.Rows[n].Cells[1].Style.BackColor = ColorD;
            dtgvReceta.Rows[n].Cells[1].Style.Font = Fuente1;

            // Nombre
            dtgvReceta.Rows[n].Cells[2].Style.ForeColor = ColorB;
            dtgvReceta.Rows[n].Cells[2].Style.SelectionForeColor = ColorB;
            dtgvReceta.Rows[n].Cells[2].Style.SelectionBackColor = ColorD;
            dtgvReceta.Rows[n].Cells[2].Style.BackColor = ColorD;
            dtgvReceta.Rows[n].Cells[2].Style.Font = Fuente2;

            // Header
            dtgvReceta.Rows[n].HeaderCell.Style.BackColor = ColorD;
        }

        private string ValidacionesConfirmar()
        {
            if (Receta.Count() == 0)
            {
                return "Receta vacia! Agrege los ingredientes";
            }

            if (KgsTotal < 900 )
            {
                return "Kilogramos totales de la receta muy bajos! Verifique";
            }

            if (KgsTotal > 1500 )
            {
                return "Kilogramos totales de la receta muy altos! Verifique";
            }

            return "GOOD";
        }

        

        public int BuscarMPenReceta ( int id)
        {
            int i = 0;
            foreach (MateriaPrima aux in Receta)
            {
                if (aux.id == id)
                    return i;
                i++;
            }
            return -1;
        }
        

        public void Info(bool Visiblilidad, int Icon, string Message)
        {
            MENU.Info(Visiblilidad, Icon, Message);
        }
        public void Info(bool Visiblilidad)
        {
            MENU.Info(Visiblilidad);
        }
        private void End()
        {
            MENU.dtgvMateriaPrima.MultiSelect = false;
            btnAgregar.Enabled = false;
            btnConfirmar.Enabled = false;
            btnEliminar.Enabled = false;
            btnIngresar.Enabled = false;
            MENU.RefreshData();
        }
        private new void Dispose()
        {
            MENU.AlumantaIcon.Enabled = true;
            MENU.AlumantaIcon.Visible = true;
            MENU.panelForms.Visible = false;
            MENU.dtgvMateriaPrima.MultiSelect = false;
            MENU.MostrarDTGVproductos();
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
            timer1.Stop();

        }

        private void btnEliminarReceta_Click(object sender, EventArgs e)
        {

        }
    }

}
