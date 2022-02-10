using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consultas;
using ManejoDatos;
using LibreriaPersonal;
using Consultas;
using Tipos;

namespace Mep3._0
{
    public partial class Excel_frmVerOrdenes: Form
    {
        private List<OrdenDePedido> Ordenes;
        private frmMENU MENU;
        private bool DatagridListo = false;
        private int indiceList;

        public Excel_frmVerOrdenes(List<OrdenDePedido> Ordenes)
        {
            InitializeComponent();
            this.Ordenes = new List<OrdenDePedido>(Ordenes);
            
            this.lblTituloTablaDetalle.Text = "";
            this.lblClienteNombre.Text = "";

            RefreshDtgvLista();
        }

        private void frmMOD_Ordenes_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
        }
        
        private void RefreshDtgvLista()
        {
            if (Ordenes.Count < 0) return;

            int n;
            int i = 0;
            dtgvLista.Rows.Clear();

            foreach (OrdenDePedido orden in this.Ordenes)
            {
                n = dtgvLista.Rows.Add();
                dtgvLista.Rows[n].Cells[0].Value = orden.GetNumero();
                dtgvLista.Rows[n].Cells[1].Value = Fechas.Formato_Mes_Dia(orden.Fecha);
                dtgvLista.Rows[n].Cells[2].Value = i;
                ColorearTablaLista(n);
                i++;
            }
            dtgvLista.Sort(dtgvLista.Columns[0], ListSortDirection.Descending);

            if (dtgvLista.RowCount > 0)
            {
                dtgvLista.CurrentCell.Selected = false;
                DatagridListo = true;
            }
        }
        private void RellenarDtgvDetalle()
        {
            int n;
            dtgvDetalle.Rows.Clear();

            if (Ordenes.Count > indiceList && Ordenes[indiceList]?.Products?.baldes != null)
            {
                foreach (Balde Producto in Ordenes[indiceList].Products.baldes)
                {
                    string NombreCompleto = "   " + Producto.GetNombreCompleto();
                    //x20
                    if (Producto.Get20() > 0)
                    {
                        n = dtgvDetalle.Rows.Add();
                        dtgvDetalle.Rows[n].Cells[0].Value = Producto.Get20();
                        dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x20";
                        ColorearTablaDetalle(n);
                    }
                    //x10
                    if (Producto.Get10() > 0)
                    {
                        n = dtgvDetalle.Rows.Add();
                        dtgvDetalle.Rows[n].Cells[0].Value = Producto.Get10();
                        dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x10";
                        ColorearTablaDetalle(n);
                    }
                    //x4
                    if (Producto.Get4() > 0)
                    {
                        n = dtgvDetalle.Rows.Add();
                        dtgvDetalle.Rows[n].Cells[0].Value = Producto.Get4();
                        dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x4";
                        ColorearTablaDetalle(n);
                    }
                    //x1
                    if (Producto.Get1() > 0)
                    {
                        n = dtgvDetalle.Rows.Add();
                        dtgvDetalle.Rows[n].Cells[0].Value = Producto.Get1();
                        dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x1";
                        ColorearTablaDetalle(n);
                    }
                }

                // Cliente
                this.lblClienteNombre.Text = Ordenes[indiceList].GetCliente();
            }
        }

        private void ColorearTablaLista(int n)
        {
            // Color de Letra  -  FECHA
            Color ColorA = System.Drawing.Color.Gray;

            // Color de Letra  -  NUMERO
            Color ColorB = System.Drawing.Color.FromArgb(0, 124, 204);

            // Color de Fondo  - Todas las Columnas , Alternando
            Color ColorD;

            if (n % 2 == 0)
            {
                ColorD = System.Drawing.Color.WhiteSmoke;
            }
            else
            {
                ColorD = System.Drawing.Color.FromArgb(227, 227, 227);
            }

            string Letra = "Segoe UI ";
            string Letra2 = "Segoe UI Semibold";

            float Tamanio = 12.00F;
            Font Fuente1 = new Font(Letra, Tamanio, FontStyle.Bold);
            Font Fuente2 = new Font(Letra2, Tamanio);

            // Fecha
            dtgvLista.Rows[n].Cells[1].Style.ForeColor = ColorA;
            dtgvLista.Rows[n].Cells[1].Style.SelectionForeColor = Color.White;       // Antes era ColorA
            dtgvLista.Rows[n].Cells[1].Style.SelectionBackColor = Color.Green; //Antes era ColorD
            dtgvLista.Rows[n].Cells[1].Style.BackColor = ColorD;
            dtgvLista.Rows[n].Cells[1].Style.Font = Fuente1;
            dtgvLista.Rows[n].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Numero
            dtgvLista.Rows[n].Cells[0].Style.ForeColor = ColorB;
            dtgvLista.Rows[n].Cells[0].Style.SelectionForeColor = Color.White;
            dtgvLista.Rows[n].Cells[0].Style.SelectionBackColor = Color.Green;
            dtgvLista.Rows[n].Cells[0].Style.BackColor = ColorD;
            dtgvLista.Rows[n].Cells[0].Style.Font = Fuente1;
            dtgvLista.Rows[n].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Header Filas
            dtgvLista.Rows[n].HeaderCell.Style.BackColor = ColorD;

        }
        private void ColorearTablaDetalle(int n)
        {
            // Color de Letra  -  FECHA
            Color ColorA = System.Drawing.Color.DimGray;

            // Color de Letra  -  NUMERO
            Color ColorB = System.Drawing.Color.FromArgb(0, 124, 204);

            // Color de Fondo  - Todas las Columnas , Alternando
            Color ColorD;

            if (n % 2 == 0)
            {
                ColorD = System.Drawing.Color.WhiteSmoke;
            }
            else
            {
                ColorD = System.Drawing.Color.FromArgb(227, 227, 227);
            }

            string Letra = "Segoe UI ";

            float Tamanio = 12.00F;
            Font Fuente1 = new Font(Letra, Tamanio, FontStyle.Bold);
      

            // Cantidad
            dtgvDetalle.Rows[n].Cells[1].Style.ForeColor = ColorA;
            dtgvDetalle.Rows[n].Cells[1].Style.SelectionForeColor = ColorA;
            dtgvDetalle.Rows[n].Cells[1].Style.SelectionBackColor = ColorD; 
            dtgvDetalle.Rows[n].Cells[1].Style.BackColor = ColorD;
            dtgvDetalle.Rows[n].Cells[1].Style.Font = Fuente1;
            dtgvDetalle.Rows[n].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Producto
            dtgvDetalle.Rows[n].Cells[0].Style.ForeColor = ColorB;
            dtgvDetalle.Rows[n].Cells[0].Style.SelectionForeColor = ColorB;
            dtgvDetalle.Rows[n].Cells[0].Style.SelectionBackColor = ColorD;
            dtgvDetalle.Rows[n].Cells[0].Style.BackColor = ColorD;
            dtgvDetalle.Rows[n].Cells[0].Style.Font = Fuente1;
            dtgvDetalle.Rows[n].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

           
        }

        private void dtgvLista_SelectionChange(object sender, EventArgs e)
        {
            int row = dtgvLista.CurrentRow.Index;
            indiceList = Convert.ToInt32(dtgvLista.Rows[row].Cells[2].Value);
            

            if (indiceList >= 0 && DatagridListo)
            {
                RellenarDtgvDetalle();
            }
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (indiceList >= 0 && DatagridListo)
            {
                MENU.Excel_EditarOrden(Ordenes[indiceList]);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (indiceList >= 0 && DatagridListo)
            {
                string msg1 = "Esta seguro que quiere anular:";
                string msg2 = $"Orden {Ordenes[indiceList].GetNumero()} - {Ordenes[indiceList].GetCliente()}";
                
                Action<bool> action = respuesta =>
                {
                    if (respuesta)
                    {
                        new OrdenDePedido("ANULADA", "", Ordenes[indiceList].GetNumero()).Serializar();

                        Ordenes.RemoveAt(indiceList);
                        RefreshDtgvLista();
                    }
                };

                var form = new frmConsultaBool(action, msg1, msg2);
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            MENU.OrdenesDropBox = new List<OrdenDePedido>();
            MENU.Excel_VerOrdenes(null, null);
        }
    }
}
