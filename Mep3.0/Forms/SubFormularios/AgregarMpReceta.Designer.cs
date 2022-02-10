namespace Mep3._0
{
    partial class AgregarMpReceta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtKgs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAniadir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1,
            this.rectangleShape2,
            this.rectangleShape3});
            this.shapeContainer1.Size = new System.Drawing.Size(467, 349);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Black;
            this.rectangleShape1.BorderColor = System.Drawing.Color.Gray;
            this.rectangleShape1.CornerRadius = 3;
            this.rectangleShape1.Enabled = false;
            this.rectangleShape1.FillColor = System.Drawing.Color.Gainsboro;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape1.Location = new System.Drawing.Point(21, 50);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(421, 57);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.Black;
            this.rectangleShape2.BorderColor = System.Drawing.Color.Black;
            this.rectangleShape2.CornerRadius = 3;
            this.rectangleShape2.Enabled = false;
            this.rectangleShape2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.rectangleShape2.FillGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.rectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape2.Location = new System.Drawing.Point(12, 11);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(438, 321);
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.rectangleShape3.BorderColor = System.Drawing.Color.Black;
            this.rectangleShape3.Enabled = false;
            this.rectangleShape3.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.rectangleShape3.FillGradientColor = System.Drawing.Color.DarkSlateBlue;
            this.rectangleShape3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal;
            this.rectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape3.Location = new System.Drawing.Point(-1, 0);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(469, 349);
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Gainsboro;
            this.lblNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 19.25F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(31, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(402, 39);
            this.lblNombre.TabIndex = 45;
            this.lblNombre.Text = "Concentrado Rojo Febrite";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKgs
            // 
            this.txtKgs.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.txtKgs.Location = new System.Drawing.Point(181, 168);
            this.txtKgs.Name = "txtKgs";
            this.txtKgs.Size = new System.Drawing.Size(82, 38);
            this.txtKgs.TabIndex = 0;
            this.txtKgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgs.TextChanged += new System.EventHandler(this.txtKgs_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 13F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(269, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 63;
            this.label1.Text = "Kgs.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(31, 259);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(188, 55);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar ingrediente";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAniadir
            // 
            this.btnAniadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(124)))), ((int)(((byte)(204)))));
            this.btnAniadir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAniadir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAniadir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAniadir.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniadir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAniadir.Location = new System.Drawing.Point(245, 259);
            this.btnAniadir.Name = "btnAniadir";
            this.btnAniadir.Size = new System.Drawing.Size(188, 55);
            this.btnAniadir.TabIndex = 1;
            this.btnAniadir.Text = "Añadir a receta";
            this.btnAniadir.UseVisualStyleBackColor = false;
            this.btnAniadir.Click += new System.EventHandler(this.btnAniadir_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "Agregando a Receta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AgregarMpReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(467, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAniadir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKgs);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(483, 388);
            this.MinimumSize = new System.Drawing.Size(483, 388);
            this.Name = "AgregarMpReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregando a la receta !";
            this.Load += new System.EventHandler(this.subform_AddMp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtKgs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAniadir;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.Label label2;
    }
}