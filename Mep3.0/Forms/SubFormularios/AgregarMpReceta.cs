
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
    public partial class AgregarMpReceta : Form
    {
        private MateriaPrima Mp;
        private frmModificarRecetas FormBase;
        float Cant;
        

        public AgregarMpReceta(MateriaPrima Mp)
        {
            InitializeComponent();
            this.Mp = new MateriaPrima(Mp);
        }
        private void subform_AddMp_Load(object sender, EventArgs e)
        {
            FormBase = Owner as frmModificarRecetas;

            Inicializar();
            txtKgs.Focus();
        }



        // Botones
        private void btnAniadir_Click(object sender, EventArgs e)
        {
            int Rec_pos;
            string Consulta;
            Consulta = Verificar();

            if ( Consulta != "GOOD")
            {
                FormBase.Info(true, 0, Consulta);
                Inicializar();
                txtKgs.Focus();
            }
            else
            {
                if (Cant > 0F)
                {
                    Mp.Stock = Cant;

                    Rec_pos = FormBase.BuscarMPenReceta(Mp.id);
                    if (Rec_pos != -1 )
                    {
                        //Sumo Mat.Prima existente en la receta
                        FormBase.Receta[Rec_pos].Stock += Mp.Stock;
                    }
                    else
                    {
                        //Agrego nueva Mat.prima a la receta
                        FormBase.Receta.Add(Mp);
                    }

                    FormBase.KgsTotal += Mp.Stock;
                    FormBase.Info(false);
                    this.Dispose();
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormBase.Info(false);
            this.Dispose();
        }


        
        private void Inicializar()
        {
            lblNombre.Text = Mp.Nombre;
            FormBase.Info(false);

            Cant = 0;
            txtKgs.Text = "0";
            txtKgs.Focus();
        }
        private string Verificar()
        {
           
            String kgs = txtKgs.Text;

            kgs.Trim();
            kgs = kgs.Replace(",",".");

            if (kgs == "") kgs = "0";

            if (!float.TryParse(kgs, out Cant))
            {
                return " Se ingreso mal el numero , intente de nuevo ";
            }

            return "GOOD";
        }

        private void txtKgs_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
