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
using Tipos;


namespace Mep3._0
{
    public partial class frmVerRegistros : Form
    {
        private List<OrdenDePedido> Ordenes;
        private List<Balde> Producciones;
        private TiposClasses Tipo;  // Para saber si son Ordenes o Producciones
        private int indiceList;     // Mismo indice para los 2 tipos (List<Balde> o List<OrdenDePedido>)
        private frmMENU MENU;
        private bool DatagridListo = false;
        private bool flagDevolverMateriales = false;


        public frmVerRegistros(List<OrdenDePedido> Ordenes)
        {
            InitializeComponent();
            this.Ordenes = new List<OrdenDePedido>(Ordenes);
            this.title.Text = "Ordenes ingresadas";
            this.Tipo = TiposClasses.Orden;
            this.lblTituloTablaDetalle.Text = "";
            this.lblClienteNombre.Text = "";

            if (Ordenes.Count > 0)
                RefreshDtgvLista();
        }
        public frmVerRegistros(List<Balde> Producciones)
        {
            InitializeComponent();
            this.Producciones = new List<Balde>(Producciones);
            this.title.Text = "Producciones ingresadas";
            this.Tipo = TiposClasses.Produccion;
            this.lblCliente.Visible = false;
            this.lblClienteNombre.Visible = false;


            if (Producciones.Count > 0)
                RefreshDtgvLista();

        }
        private void frmMOD_Ordenes_Load(object sender, EventArgs e)
        {
            MENU = Owner as frmMENU;
            this.lblHora.Text = "";
        }
        
        private void RefreshDtgvLista()
        {
            int n;
            int i = 0;
            dtgvLista.Rows.Clear();

            // -- ORDENES -- 
            if (this.Tipo == TiposClasses.Orden)
            {
                foreach (OrdenDePedido aux in this.Ordenes)
                {
                    n = dtgvLista.Rows.Add();
                    dtgvLista.Rows[n].Cells[0].Value = aux.GetNumero();
                    dtgvLista.Rows[n].Cells[1].Value = Fechas.Formato_Mes_Dia(aux.Fecha);
                    dtgvLista.Rows[n].Cells[2].Value = i;
                    ColorearTablaLista(n);
                    i++;
                }
                dtgvLista.Sort(dtgvLista.Columns[0], ListSortDirection.Descending);
            }

            //  -- PRODUCCIONES -- 
            if (this.Tipo == TiposClasses.Produccion)
            {
                foreach (Balde aux in this.Producciones)
                {
                    n = dtgvLista.Rows.Add();
                    dtgvLista.Rows[n].Cells[0].Value = aux.numero_produccion;
                    dtgvLista.Rows[n].Cells[1].Value = Fechas.Formato_Mes_Dia( aux.Fecha );
                    dtgvLista.Rows[n].Cells[2].Value = i;
                    ColorearTablaLista(n);
                    i++;
                }
                dtgvLista.Sort(dtgvLista.Columns[0], ListSortDirection.Descending);
            }


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

            // --  ORDENES  --
            if (this.Tipo == TiposClasses.Orden && Ordenes.Count > indiceList && Ordenes[indiceList]?.Products?.baldes != null)
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
                // Hora
                this.lblHora.Text = Ordenes[indiceList].Fecha.ToString("t");

            }
           
            // --  PRODUCCIONES  -- 
            if (TiposClasses.Produccion == Tipo && Producciones.Count > indiceList && Producciones[indiceList] != null)
            {
                string NombreCompleto = "   " + Producciones[indiceList].GetNombreCompleto();
                
                // x20
                if (Producciones[indiceList].Get20() > 0)
                {
                    n = dtgvDetalle.Rows.Add();
                    dtgvDetalle.Rows[n].Cells[0].Value = Producciones[indiceList].Get20();
                    dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x20";
                    ColorearTablaDetalle(n);
                }
                // x10
                if (Producciones[indiceList].Get10() > 0)
                {
                    n = dtgvDetalle.Rows.Add();
                    dtgvDetalle.Rows[n].Cells[0].Value = Producciones[indiceList].Get10();
                    dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x10";
                    ColorearTablaDetalle(n);
                }
                // x4
                if (Producciones[indiceList].Get4() > 0)
                {
                    n = dtgvDetalle.Rows.Add();
                    dtgvDetalle.Rows[n].Cells[0].Value = Producciones[indiceList].Get4();
                    dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x4";
                    ColorearTablaDetalle(n);
                }
                // x1
                if (Producciones[indiceList].Get1() > 0)
                {
                    n = dtgvDetalle.Rows.Add();
                    dtgvDetalle.Rows[n].Cells[0].Value = Producciones[indiceList].Get1();
                    dtgvDetalle.Rows[n].Cells[1].Value = NombreCompleto + " x1";
                    ColorearTablaDetalle(n);
                }

                // Hora
                this.lblHora.Text = Producciones[indiceList].Fecha.ToString("t");
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

        private void dtgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            // dtgvLista_SelectionChange deveria ser.. Pero bueno quedo asi
            int row = dtgvLista.CurrentRow.Index;
            indiceList = Convert.ToInt32(dtgvLista.Rows[row].Cells[2].Value);
            
            /*
            if (TiposClasses.Ordenes == this.Tipo)
                indiceList = Buscar.ordenPorId(Ordenes, id);

            if (TiposClasses.Producciones == this.Tipo)
                indiceList = Buscar.ordenPorId(Producciones, id);
            */

            if (indiceList >= 0 && DatagridListo)
            {
                RellenarDtgvDetalle();
            }
        }

        // Eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgvLista.RowCount <= 0)
            {
                return;
            }

            int row = dtgvLista.CurrentRow.Index;
            indiceList = Convert.ToInt32(dtgvLista.Rows[row].Cells[2].Value);
           

            if (indiceList >= 0)
            {
                if (Tipo == TiposClasses.Orden)
                {
                    string mensaje1 = "Esta seguro que quiere eliminar la orden";
                    string mensaje2 = "numero --> " + Ordenes[indiceList].GetNumero().ToString();
                    ConsultaConDelegados ventana = new ConsultaConDelegados(ResEliminar, mensaje1, mensaje2);
                    ventana.ShowDialog();
                }
                
                if(Tipo == TiposClasses.Produccion)
                {
                    string mensaje1 = "Esta seguro que quiere eliminar la produccion";
                    string mensaje2 = "numero --> " + Producciones[indiceList].numero_produccion.ToString();
                    ConsultaConDelegados ventana = new ConsultaConDelegados(ResEliminar, mensaje1, mensaje2);
                    ventana.ShowDialog();
                }
            }

        }
        private void ResEliminar (bool Eliminar)
        {
            if (Eliminar == true)
            {

                var Ventana = new ConsultaConDelegados(ResDevolverMateriales, "Desea restablecer los materiales ?", "");
                Ventana.ShowDialog();

                if (Tipo == TiposClasses.Orden)
                {
                    // Me guardo el numero para notificar unicamente que se elimino 
                    ulong numOrden = Ordenes[indiceList].GetNumero();


                    // Resto materiales
                    if (flagDevolverMateriales) DevolverMateriales();


                    // Elimino
                    Ordenes.RemoveAt(indiceList);
                    ReSerializador.Ordenes(Ordenes);


                    MENU.Info(true, 1, $"Orden {numOrden} eliminada con exito");
                }

                if (Tipo == TiposClasses.Produccion)
                {
                    // Me guardo el numero para notificar unicamente que se elimino
                    int numProduccion = Producciones[indiceList].numero_produccion;


                    // RESTO baldes del stock y SUMO los materiales usados
                    if (flagDevolverMateriales) DevolverMateriales();


                    // Elimino  
                    Producciones.RemoveAt(indiceList);
                    ReSerializador.Producciones(Producciones);


                    MENU.Info(true, 1, $"Produccion {numProduccion} eliminada con exito");
                }

               
                

                // Refresco DTGV
                RefreshDtgvLista();
            }
            
        }
        
        // Devolver Materiales / Productos
        private void ResDevolverMateriales (bool Devolver)
        {
            flagDevolverMateriales = Devolver ? true : false;
        }
        private void DevolverMateriales()
        {
            int pos;
            string motivo;
            // Devolver Productos o Materiales al Stock !

            // ORDEN
            if ( Tipo == TiposClasses.Orden )
            {
                foreach (var a in Ordenes[indiceList].Products.baldes)
                {
                    // Busco el indice del Producto de la Orden en el STOCK
                    pos = MENU.Products.BuscarValdeByID(a.GetID());

                    // Le sumo el Balde de la Orden al respectivo Balde del Stock (misma ID)
                    MENU.Products.baldes[pos].Sumar(a.Get20(), a.Get10(), a.Get4(), a.Get1());

                    // Actualizo el Balde en la DataBase
                    MENU.DB.ActualizarBalde(MENU.Products.baldes[pos]
                                            , $"  Orden   {Ordenes[indiceList].GetNumero()}" +
                                              $", Cliente {Ordenes[indiceList].GetCliente()} Eliminada");
                }

                MENU.RefreshProductos();
            }


            // PRODUCCION
            if (Tipo == TiposClasses.Produccion)
            {
                
                pos = MENU.Products.BuscarValdeByID(Producciones[indiceList].GetID());
                motivo = $"Produccion ELIMINADA !!! [{MENU.Products.baldes[pos].numero_produccion}] | [{MENU.Products.baldes[pos].GetNombreCompleto()}]";

                if (pos >= 0  && MENU.Products.baldes[pos].FlagRecipe)
                {
                    // Devuelvo la materia prima usada
                    foreach (var material in MENU.Products.baldes[pos].Recipe)
                    {
                        if (material.Infinito == false)
                        {
                           
                            MENU.DB.RestarMateriaPrima(material, -(material.Stock) , motivo);
                        }
                    }

                    // Resto los baldes producidos al stock
                    MENU.Products.baldes[pos].Restar(Producciones[indiceList]);
                    MENU.DB.ActualizarBalde(MENU.Products.baldes[pos] , $" Produccion {Producciones[indiceList].numero_produccion} Eliminada");
                }

                MENU.RefreshData();
            }


          
            // Importante, vuelvo a false la bandera
            flagDevolverMateriales = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MENU.MostrarFondoAlumanta();
        }
    }
}
