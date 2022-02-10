namespace Mep3._0
{
    partial class frmProduccion
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
            this.components = new System.ComponentModel.Container();
            this.btnProdCancel = new System.Windows.Forms.Button();
            this.btnProdConfirmado = new System.Windows.Forms.Button();
            this.lblProduccionColor = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblProduccionNombre = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt10 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txt20 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnProdOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape7 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape5 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl10Sin = new System.Windows.Forms.Label();
            this.lbl20Sin = new System.Windows.Forms.Label();
            this.lbl1Sin = new System.Windows.Forms.Label();
            this.lbl4Sin = new System.Windows.Forms.Label();
            this.lbl10Con = new System.Windows.Forms.Label();
            this.lbl20Con = new System.Windows.Forms.Label();
            this.lbl1Con = new System.Windows.Forms.Label();
            this.lbl4Con = new System.Windows.Forms.Label();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rectangleShape6 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SuspendLayout();
            // 
            // btnProdCancel
            // 
            this.btnProdCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnProdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProdCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnProdCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProdCancel.Location = new System.Drawing.Point(189, 528);
            this.btnProdCancel.Name = "btnProdCancel";
            this.btnProdCancel.Size = new System.Drawing.Size(149, 33);
            this.btnProdCancel.TabIndex = 38;
            this.btnProdCancel.Text = "Cancelar";
            this.btnProdCancel.UseVisualStyleBackColor = false;
            this.btnProdCancel.Click += new System.EventHandler(this.btnProdCancel_Click);
            // 
            // btnProdConfirmado
            // 
            this.btnProdConfirmado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(173)))), ((int)(((byte)(0)))));
            this.btnProdConfirmado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProdConfirmado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdConfirmado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProdConfirmado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdConfirmado.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnProdConfirmado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProdConfirmado.Location = new System.Drawing.Point(189, 559);
            this.btnProdConfirmado.Name = "btnProdConfirmado";
            this.btnProdConfirmado.Size = new System.Drawing.Size(298, 33);
            this.btnProdConfirmado.TabIndex = 37;
            this.btnProdConfirmado.Text = "Confirmar";
            this.btnProdConfirmado.UseVisualStyleBackColor = false;
            this.btnProdConfirmado.Visible = false;
            this.btnProdConfirmado.Click += new System.EventHandler(this.btnProdConfirmado_Click);
            // 
            // lblProduccionColor
            // 
            this.lblProduccionColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.lblProduccionColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProduccionColor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduccionColor.ForeColor = System.Drawing.Color.Gold;
            this.lblProduccionColor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblProduccionColor.Location = new System.Drawing.Point(170, 143);
            this.lblProduccionColor.Name = "lblProduccionColor";
            this.lblProduccionColor.Size = new System.Drawing.Size(331, 25);
            this.lblProduccionColor.TabIndex = 43;
            this.lblProduccionColor.Text = "BLANCO";
            this.lblProduccionColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Light", 23.75F);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(189, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(298, 45);
            this.lblTitulo.TabIndex = 34;
            this.lblTitulo.Text = "Produccion";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProduccionNombre
            // 
            this.lblProduccionNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.lblProduccionNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblProduccionNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 15.25F, System.Drawing.FontStyle.Bold);
            this.lblProduccionNombre.ForeColor = System.Drawing.Color.Gold;
            this.lblProduccionNombre.Location = new System.Drawing.Point(174, 110);
            this.lblProduccionNombre.Name = "lblProduccionNombre";
            this.lblProduccionNombre.Size = new System.Drawing.Size(327, 33);
            this.lblProduccionNombre.TabIndex = 33;
            this.lblProduccionNombre.Text = "Membrana en Pasta";
            this.lblProduccionNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.Location = new System.Drawing.Point(308, 399);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(54, 29);
            this.txt1.TabIndex = 35;
            this.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt1.TextChanged += new System.EventHandler(this.txt1_TextChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(244, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "10 kgs.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(244, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = " 1  kg.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(244, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "20 kgs.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt10
            // 
            this.txt10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt10.Location = new System.Drawing.Point(308, 321);
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(54, 29);
            this.txt10.TabIndex = 33;
            this.txt10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt10.TextChanged += new System.EventHandler(this.txt10_TextChanged);
            // 
            // txt4
            // 
            this.txt4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4.Location = new System.Drawing.Point(308, 360);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(54, 29);
            this.txt4.TabIndex = 34;
            this.txt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt4.TextChanged += new System.EventHandler(this.txt4_TextChanged);
            // 
            // txt20
            // 
            this.txt20.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt20.Location = new System.Drawing.Point(308, 283);
            this.txt20.Name = "txt20";
            this.txt20.Size = new System.Drawing.Size(54, 29);
            this.txt20.TabIndex = 32;
            this.txt20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt20.TextChanged += new System.EventHandler(this.txt20_TextChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(244, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = " 4  kgs.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProdOK
            // 
            this.btnProdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(124)))), ((int)(((byte)(204)))));
            this.btnProdOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProdOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdOK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdOK.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProdOK.Location = new System.Drawing.Point(336, 528);
            this.btnProdOK.Name = "btnProdOK";
            this.btnProdOK.Size = new System.Drawing.Size(151, 33);
            this.btnProdOK.TabIndex = 36;
            this.btnProdOK.Text = "Ingresar tachada";
            this.btnProdOK.UseVisualStyleBackColor = false;
            this.btnProdOK.Click += new System.EventHandler(this.btnProdOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(289, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 21);
            this.label2.TabIndex = 47;
            this.label2.Text = "nro.";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lblNum.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(124)))), ((int)(((byte)(204)))));
            this.lblNum.Location = new System.Drawing.Point(320, 54);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(56, 25);
            this.lblNum.TabIndex = 48;
            this.lblNum.Text = "9999";
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Black;
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape1.BorderWidth = 5;
            this.rectangleShape1.CornerRadius = 1;
            this.rectangleShape1.Enabled = false;
            this.rectangleShape1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape1.Location = new System.Drawing.Point(174, 4);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(325, 601);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape7,
            this.rectangleShape6,
            this.rectangleShape5,
            this.rectangleShape4,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(699, 614);
            this.shapeContainer1.TabIndex = 49;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape7
            // 
            this.rectangleShape7.BackColor = System.Drawing.Color.Black;
            this.rectangleShape7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(46)))), ((int)(((byte)(63)))));
            this.rectangleShape7.CornerRadius = 2;
            this.rectangleShape7.Enabled = false;
            this.rectangleShape7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.rectangleShape7.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape7.Location = new System.Drawing.Point(177, 6);
            this.rectangleShape7.Name = "rectangleShape7";
            this.rectangleShape7.Size = new System.Drawing.Size(319, 87);
            // 
            // rectangleShape5
            // 
            this.rectangleShape5.BackColor = System.Drawing.Color.Black;
            this.rectangleShape5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(46)))), ((int)(((byte)(63)))));
            this.rectangleShape5.CornerRadius = 2;
            this.rectangleShape5.Enabled = false;
            this.rectangleShape5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.rectangleShape5.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape5.Location = new System.Drawing.Point(177, 476);
            this.rectangleShape5.Name = "rectangleShape5";
            this.rectangleShape5.Size = new System.Drawing.Size(319, 125);
            // 
            // rectangleShape4
            // 
            this.rectangleShape4.BackColor = System.Drawing.Color.Black;
            this.rectangleShape4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(46)))), ((int)(((byte)(63)))));
            this.rectangleShape4.CornerRadius = 2;
            this.rectangleShape4.Enabled = false;
            this.rectangleShape4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.rectangleShape4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape4.Location = new System.Drawing.Point(177, 182);
            this.rectangleShape4.Name = "rectangleShape4";
            this.rectangleShape4.Size = new System.Drawing.Size(319, 54);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.Black;
            this.rectangleShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape2.BorderWidth = 5;
            this.rectangleShape2.CornerRadius = 5;
            this.rectangleShape2.Enabled = false;
            this.rectangleShape2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.rectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape2.Location = new System.Drawing.Point(160, 95);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(350, 85);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblTotal.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblTotal.Location = new System.Drawing.Point(331, 483);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(91, 31);
            this.lblTotal.TabIndex = 70;
            this.lblTotal.Text = "0 ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(278, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 31);
            this.label1.TabIndex = 69;
            this.label1.Text = "Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl10Sin
            // 
            this.lbl10Sin.AutoSize = true;
            this.lbl10Sin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl10Sin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10Sin.ForeColor = System.Drawing.Color.Tomato;
            this.lbl10Sin.Location = new System.Drawing.Point(375, 325);
            this.lbl10Sin.Name = "lbl10Sin";
            this.lbl10Sin.Size = new System.Drawing.Size(96, 21);
            this.lbl10Sin.TabIndex = 71;
            this.lbl10Sin.Text = "Sin Etiqueta";
            this.lbl10Sin.Click += new System.EventHandler(this.lbl10Sin_Click);
            // 
            // lbl20Sin
            // 
            this.lbl20Sin.AutoSize = true;
            this.lbl20Sin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl20Sin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl20Sin.ForeColor = System.Drawing.Color.Tomato;
            this.lbl20Sin.Location = new System.Drawing.Point(375, 287);
            this.lbl20Sin.Name = "lbl20Sin";
            this.lbl20Sin.Size = new System.Drawing.Size(96, 21);
            this.lbl20Sin.TabIndex = 71;
            this.lbl20Sin.Text = "Sin Etiqueta";
            this.lbl20Sin.Click += new System.EventHandler(this.lbl20Sin_Click);
            // 
            // lbl1Sin
            // 
            this.lbl1Sin.AutoSize = true;
            this.lbl1Sin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl1Sin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Sin.ForeColor = System.Drawing.Color.Tomato;
            this.lbl1Sin.Location = new System.Drawing.Point(375, 402);
            this.lbl1Sin.Name = "lbl1Sin";
            this.lbl1Sin.Size = new System.Drawing.Size(96, 21);
            this.lbl1Sin.TabIndex = 71;
            this.lbl1Sin.Text = "Sin Etiqueta";
            this.lbl1Sin.Click += new System.EventHandler(this.lbl1Sin_Click);
            // 
            // lbl4Sin
            // 
            this.lbl4Sin.AutoSize = true;
            this.lbl4Sin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl4Sin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4Sin.ForeColor = System.Drawing.Color.Tomato;
            this.lbl4Sin.Location = new System.Drawing.Point(375, 364);
            this.lbl4Sin.Name = "lbl4Sin";
            this.lbl4Sin.Size = new System.Drawing.Size(96, 21);
            this.lbl4Sin.TabIndex = 71;
            this.lbl4Sin.Text = "Sin Etiqueta";
            this.lbl4Sin.Click += new System.EventHandler(this.lbl4Sin_Click);
            // 
            // lbl10Con
            // 
            this.lbl10Con.AutoSize = true;
            this.lbl10Con.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl10Con.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10Con.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl10Con.Location = new System.Drawing.Point(370, 325);
            this.lbl10Con.Name = "lbl10Con";
            this.lbl10Con.Size = new System.Drawing.Size(103, 21);
            this.lbl10Con.TabIndex = 71;
            this.lbl10Con.Text = "Con Etiqueta";
            this.lbl10Con.Visible = false;
            this.lbl10Con.Click += new System.EventHandler(this.lbl10Con_Click);
            // 
            // lbl20Con
            // 
            this.lbl20Con.AutoSize = true;
            this.lbl20Con.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl20Con.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl20Con.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl20Con.Location = new System.Drawing.Point(370, 287);
            this.lbl20Con.Name = "lbl20Con";
            this.lbl20Con.Size = new System.Drawing.Size(103, 21);
            this.lbl20Con.TabIndex = 71;
            this.lbl20Con.Text = "Con Etiqueta";
            this.lbl20Con.Visible = false;
            this.lbl20Con.Click += new System.EventHandler(this.lbl20Con_Click);
            // 
            // lbl1Con
            // 
            this.lbl1Con.AutoSize = true;
            this.lbl1Con.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl1Con.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Con.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl1Con.Location = new System.Drawing.Point(370, 402);
            this.lbl1Con.Name = "lbl1Con";
            this.lbl1Con.Size = new System.Drawing.Size(103, 21);
            this.lbl1Con.TabIndex = 71;
            this.lbl1Con.Text = "Con Etiqueta";
            this.lbl1Con.Visible = false;
            this.lbl1Con.Click += new System.EventHandler(this.lbl1Con_Click);
            // 
            // lbl4Con
            // 
            this.lbl4Con.AutoSize = true;
            this.lbl4Con.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.lbl4Con.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4Con.ForeColor = System.Drawing.Color.GreenYellow;
            this.lbl4Con.Location = new System.Drawing.Point(370, 364);
            this.lbl4Con.Name = "lbl4Con";
            this.lbl4Con.Size = new System.Drawing.Size(103, 21);
            this.lbl4Con.TabIndex = 71;
            this.lbl4Con.Text = "Con Etiqueta";
            this.lbl4Con.Visible = false;
            this.lbl4Con.Click += new System.EventHandler(this.lbl4Con_Click);
            // 
            // txtMes
            // 
            this.txtMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.txtMes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMes.ForeColor = System.Drawing.Color.LightGray;
            this.txtMes.Location = new System.Drawing.Point(323, 210);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(28, 22);
            this.txtMes.TabIndex = 32;
            this.txtMes.Text = "03";
            this.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMes.TextChanged += new System.EventHandler(this.txt20_TextChanged);
            // 
            // txtAnio
            // 
            this.txtAnio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.txtAnio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAnio.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.ForeColor = System.Drawing.Color.LightGray;
            this.txtAnio.Location = new System.Drawing.Point(358, 210);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(37, 22);
            this.txtAnio.TabIndex = 32;
            this.txtAnio.Text = "2011";
            this.txtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnio.TextChanged += new System.EventHandler(this.txt20_TextChanged);
            // 
            // txtDia
            // 
            this.txtDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.txtDia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia.ForeColor = System.Drawing.Color.LightGray;
            this.txtDia.Location = new System.Drawing.Point(290, 210);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(28, 22);
            this.txtDia.TabIndex = 32;
            this.txtDia.Text = "21";
            this.txtDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDia.TextChanged += new System.EventHandler(this.txt20_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(345, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 21);
            this.label3.TabIndex = 71;
            this.label3.Text = "-";
            this.label3.Click += new System.EventHandler(this.lbl20Con_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(313, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 21);
            this.label4.TabIndex = 71;
            this.label4.Text = "-";
            this.label4.Click += new System.EventHandler(this.lbl20Con_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.label9.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(183, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(309, 21);
            this.label9.TabIndex = 71;
            this.label9.Text = "FECHA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.Click += new System.EventHandler(this.lbl20Con_Click);
            // 
            // rectangleShape6
            // 
            this.rectangleShape6.BackColor = System.Drawing.Color.Black;
            this.rectangleShape6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(46)))), ((int)(((byte)(63)))));
            this.rectangleShape6.CornerRadius = 2;
            this.rectangleShape6.Enabled = false;
            this.rectangleShape6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(53)))), ((int)(((byte)(81)))));
            this.rectangleShape6.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape6.Location = new System.Drawing.Point(177, 241);
            this.rectangleShape6.Name = "rectangleShape6";
            this.rectangleShape6.Size = new System.Drawing.Size(319, 230);
            // 
            // frmProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(699, 614);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDia);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.lbl4Con);
            this.Controls.Add(this.lbl20Con);
            this.Controls.Add(this.lbl1Con);
            this.Controls.Add(this.lbl10Con);
            this.Controls.Add(this.lbl4Sin);
            this.Controls.Add(this.lbl1Sin);
            this.Controls.Add(this.lbl20Sin);
            this.Controls.Add(this.lbl10Sin);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProduccionColor);
            this.Controls.Add(this.btnProdConfirmado);
            this.Controls.Add(this.lblProduccionNombre);
            this.Controls.Add(this.btnProdOK);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt20);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnProdCancel);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProduccion";
            this.Text = "PRODUCCIONcs";
            this.Load += new System.EventHandler(this.frmProduccion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProdCancel;
        private System.Windows.Forms.Button btnProdConfirmado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt10;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txt20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnProdOK;
       
        public System.Windows.Forms.Label lblProduccionColor;
        public System.Windows.Forms.Label lblProduccionNombre;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblNum;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl10Sin;
        private System.Windows.Forms.Label lbl20Sin;
        private System.Windows.Forms.Label lbl1Sin;
        private System.Windows.Forms.Label lbl4Sin;
        private System.Windows.Forms.Label lbl10Con;
        private System.Windows.Forms.Label lbl20Con;
        private System.Windows.Forms.Label lbl1Con;
        private System.Windows.Forms.Label lbl4Con;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape4;
        private System.Windows.Forms.Label label9;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape5;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape7;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape6;
    }
}