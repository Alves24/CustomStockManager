
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
    public partial class frmConsulta : Form
    {
        private int id;
        private Type type;

        private void frmConsulta_Load(object sender, EventArgs e)
        {

        }

        public frmConsulta(string Consulta)
        {
            InitializeComponent();
            this.lblMensaje1.Visible = false;
            this.lblMensaje2.Visible = false;
            this.lblConsulta.Visible = true;

            this.lblConsulta.Text = Consulta;
            btnNO.Visible = false;
            btnSI.Visible = false;
            btnOk.Visible = true;
        }
        public frmConsulta(string Msj1, string Msj2, int id, Type type)
        {
            InitializeComponent();
            this.lblMensaje1.Text = Msj1;
            this.lblMensaje2.Text = Msj2;
            this.id = id;
            this.type = type;
        }

       
       
        private void btnSI_Click(object sender, EventArgs e)
        {
            IForm formInterface = this.Owner as IForm;

            if (formInterface != null)
            {
                formInterface.Borrar(id, type);
                darinfo();
            }
            else
            {
                formInterface.Info(false, 0, "No se pudo completar la accion , Fallo del sistema !");
            }

            this.Dispose();
        }
        private void btnNO_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void darinfo ()
        {
            IForm formInterface = this.Owner as IForm;

            if (type == typeof(MateriaPrima))
            {
                formInterface.Info(true, 1, "Materia prima eliminada del sistema.");
            }

            if (type == typeof(Balde))
            {
                formInterface.Info(true, 1, "Producto eliminado del sistema.");
            }

            if (type == typeof(List<MateriaPrima>))
            {
                formInterface.Info(true, 1, "Receta eliminada.");
            }

            if (type == typeof(OrdenDePedido))
            {
                formInterface.Info(true, 1, "Orden eliminada.");
            }
        }

       
    }
}
