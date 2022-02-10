using System;
using System.Collections;
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
    public partial class frmVerMasRegistros : Form
    {
        private frmMENU MENU;
        private Hashtable Lista;
        private string Tabla;
        

        public frmVerMasRegistros()
        {
            InitializeComponent();
        }
       

        //LOAD
        private void frmBorrar_Load(object sender, EventArgs e)
        {
            dtgv.ColumnHeadersVisible = false;

            MENU = Owner as frmMENU;
           
            MENU.Info(false);

            Inicializar();
            SetCeldasDTGV();
        }

        // REFRESH DTGV
        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDTGV();
        }


        private void Inicializar ()
        {
            cbx.Items.Add("Clientes");
            cbx.Items.Add("Vendedores");
            cbx.Items.Add("Nombres de Productos");
            cbx.Items.Add("Colores");


            cbx.Text = "Clientes";
        }
        private void RefreshDTGV()
        {
            Lista = new Hashtable();

            btnConfirmar.Visible = false;

            if (cbx.Text == "Clientes")
            {
                Tabla = "tblCLIENTES";
            }
            if (cbx.Text == "Vendedores")
            {
                Tabla = "tblVENDEDORES";
            }
            if (cbx.Text == "Nombres de Productos")
            {
                Tabla = "tblTIPOS";
            }
            if (cbx.Text == "Colores")
            {
                Tabla = "tblCOLORES";
            }

            MENU.DB.LeerStringTable(ref Lista, Tabla);

            int n;
            dtgv.Rows.Clear();

            foreach (DictionaryEntry item in Lista)
            {
                n = dtgv.Rows.Add();

                dtgv.Rows[n].Cells[0].Value = item.Key.ToString();
                dtgv.Rows[n].Cells[1].Value = item.Value;
            }

            dtgv.Sort(dtgv.Columns[1], ListSortDirection.Ascending);
            dtgv.Refresh();
        }
        private void SetCeldasDTGV()
        {
            //DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();

            string Fuente = "Segoe UI";
            float Tamanio = 12.00F;
            dtgv.AlternatingRowsDefaultCellStyle.Font = new Font(Fuente, Tamanio, FontStyle.Regular);
            dtgv.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgv.DefaultCellStyle.Font = new Font(Fuente, Tamanio, FontStyle.Regular);
            dtgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            timer1.Start();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id;
            
            foreach (DataGridViewRow row in dtgv.SelectedRows)
            {
                id = Convert.ToInt32(dtgv.Rows[row.Index].Cells[0].Value);
                MENU.DB.Borrar(id, Tabla);       
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
            timer1.Stop();
        }
    }
}
