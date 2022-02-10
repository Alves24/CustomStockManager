namespace Mep3._0
{
    partial class Excel_frmVerOrdenes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Excel_frmVerOrdenes));
            this.dtgvLista = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndiceLista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape7 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape6 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.dtgvDetalle = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTituloTablaDetalle = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.rectangleShape8 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvLista
            // 
            this.dtgvLista.AllowUserToAddRows = false;
            this.dtgvLista.AllowUserToDeleteRows = false;
            this.dtgvLista.AllowUserToOrderColumns = true;
            this.dtgvLista.AllowUserToResizeColumns = false;
            this.dtgvLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.NullValue = null;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Green;
            this.dtgvLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dtgvLista.BackgroundColor = System.Drawing.Color.Gray;
            this.dtgvLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dtgvLista.ColumnHeadersHeight = 34;
            this.dtgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Stock,
            this.IndiceLista});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvLista.DefaultCellStyle = dataGridViewCellStyle17;
            this.dtgvLista.EnableHeadersVisualStyles = false;
            this.dtgvLista.GridColor = System.Drawing.Color.Green;
            this.dtgvLista.Location = new System.Drawing.Point(17, 90);
            this.dtgvLista.MultiSelect = false;
            this.dtgvLista.Name = "dtgvLista";
            this.dtgvLista.ReadOnly = true;
            this.dtgvLista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dtgvLista.RowHeadersVisible = false;
            this.dtgvLista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvLista.Size = new System.Drawing.Size(169, 444);
            this.dtgvLista.TabIndex = 6;
            this.dtgvLista.SelectionChanged += new System.EventHandler(this.dtgvLista_SelectionChange);
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Numero.DefaultCellStyle = dataGridViewCellStyle15;
            this.Numero.FillWeight = 20F;
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Numero.Width = 80;
            // 
            // Stock
            // 
            this.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle16;
            this.Stock.FillWeight = 1F;
            this.Stock.HeaderText = "Fecha";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // IndiceLista
            // 
            this.IndiceLista.HeaderText = "IndiceLista[HIDE]";
            this.IndiceLista.Name = "IndiceLista";
            this.IndiceLista.ReadOnly = true;
            this.IndiceLista.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IndiceLista.Visible = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnIngresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIngresar.Location = new System.Drawing.Point(554, 548);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(131, 52);
            this.btnIngresar.TabIndex = 60;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.ForestGreen;
            this.title.Font = new System.Drawing.Font("Segoe UI Semilight", 22.25F);
            this.title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.title.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.title.Location = new System.Drawing.Point(24, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(652, 42);
            this.title.TabIndex = 61;
            this.title.Text = "Ordenes de pedido a Ingresar!";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape8,
            this.rectangleShape7,
            this.rectangleShape6,
            this.rectangleShape4,
            this.rectangleShape3,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(704, 614);
            this.shapeContainer1.TabIndex = 62;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape7
            // 
            this.rectangleShape7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.rectangleShape7.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape7.BorderWidth = 4;
            this.rectangleShape7.CornerRadius = 3;
            this.rectangleShape7.Enabled = false;
            this.rectangleShape7.FillColor = System.Drawing.Color.ForestGreen;
            this.rectangleShape7.FillGradientColor = System.Drawing.Color.DodgerBlue;
            this.rectangleShape7.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal;
            this.rectangleShape7.Location = new System.Drawing.Point(203, 541);
            this.rectangleShape7.Name = "rectangleShape7";
            this.rectangleShape7.Size = new System.Drawing.Size(488, 65);
            // 
            // rectangleShape6
            // 
            this.rectangleShape6.BackColor = System.Drawing.Color.Black;
            this.rectangleShape6.BorderColor = System.Drawing.Color.DimGray;
            this.rectangleShape6.Enabled = false;
            this.rectangleShape6.FillColor = System.Drawing.Color.DimGray;
            this.rectangleShape6.FillGradientColor = System.Drawing.Color.DodgerBlue;
            this.rectangleShape6.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape6.Location = new System.Drawing.Point(211, 90);
            this.rectangleShape6.Name = "rectangleShape6";
            this.rectangleShape6.Size = new System.Drawing.Size(472, 38);
            // 
            // rectangleShape4
            // 
            this.rectangleShape4.BackColor = System.Drawing.Color.Black;
            this.rectangleShape4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(92)))), ((int)(((byte)(145)))));
            this.rectangleShape4.CornerRadius = 6;
            this.rectangleShape4.Enabled = false;
            this.rectangleShape4.FillColor = System.Drawing.Color.ForestGreen;
            this.rectangleShape4.FillGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(92)))), ((int)(((byte)(145)))));
            this.rectangleShape4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape4.Location = new System.Drawing.Point(10, 6);
            this.rectangleShape4.Name = "rectangleShape4";
            this.rectangleShape4.Size = new System.Drawing.Size(683, 60);
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.BackColor = System.Drawing.Color.Black;
            this.rectangleShape3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape3.BorderWidth = 4;
            this.rectangleShape3.CornerRadius = 3;
            this.rectangleShape3.Enabled = false;
            this.rectangleShape3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(92)))), ((int)(((byte)(145)))));
            this.rectangleShape3.FillGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(46)))), ((int)(((byte)(80)))));
            this.rectangleShape3.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Vertical;
            this.rectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape3.Location = new System.Drawing.Point(3, 3);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(697, 69);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.Black;
            this.rectangleShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape2.BorderWidth = 4;
            this.rectangleShape2.CornerRadius = 3;
            this.rectangleShape2.Enabled = false;
            this.rectangleShape2.FillColor = System.Drawing.Color.DodgerBlue;
            this.rectangleShape2.FillGradientColor = System.Drawing.Color.ForestGreen;
            this.rectangleShape2.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal;
            this.rectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape2.Location = new System.Drawing.Point(11, 83);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(182, 458);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Black;
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape1.BorderWidth = 4;
            this.rectangleShape1.CornerRadius = 3;
            this.rectangleShape1.Enabled = false;
            this.rectangleShape1.FillColor = System.Drawing.Color.ForestGreen;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.DodgerBlue;
            this.rectangleShape1.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal;
            this.rectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.rectangleShape1.Location = new System.Drawing.Point(203, 83);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(488, 457);
            // 
            // dtgvDetalle
            // 
            this.dtgvDetalle.AllowUserToAddRows = false;
            this.dtgvDetalle.AllowUserToDeleteRows = false;
            this.dtgvDetalle.AllowUserToResizeColumns = false;
            this.dtgvDetalle.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.NullValue = null;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Green;
            this.dtgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dtgvDetalle.BackgroundColor = System.Drawing.Color.Gray;
            this.dtgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle20.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dtgvDetalle.ColumnHeadersHeight = 34;
            this.dtgvDetalle.ColumnHeadersVisible = false;
            this.dtgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDetalle.DefaultCellStyle = dataGridViewCellStyle23;
            this.dtgvDetalle.EnableHeadersVisualStyles = false;
            this.dtgvDetalle.GridColor = System.Drawing.Color.Green;
            this.dtgvDetalle.Location = new System.Drawing.Point(211, 125);
            this.dtgvDetalle.Name = "dtgvDetalle";
            this.dtgvDetalle.ReadOnly = true;
            this.dtgvDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dtgvDetalle.RowHeadersVisible = false;
            this.dtgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDetalle.Size = new System.Drawing.Size(473, 408);
            this.dtgvDetalle.TabIndex = 63;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn1.FillWeight = 20F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn2.FillWeight = 1F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblTituloTablaDetalle
            // 
            this.lblTituloTablaDetalle.BackColor = System.Drawing.Color.DimGray;
            this.lblTituloTablaDetalle.Font = new System.Drawing.Font("Segoe UI Semilight", 13.25F);
            this.lblTituloTablaDetalle.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTituloTablaDetalle.Location = new System.Drawing.Point(226, 93);
            this.lblTituloTablaDetalle.Name = "lblTituloTablaDetalle";
            this.lblTituloTablaDetalle.Size = new System.Drawing.Size(438, 30);
            this.lblTituloTablaDetalle.TabIndex = 64;
            this.lblTituloTablaDetalle.Text = "Productos ";
            this.lblTituloTablaDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI Semilight", 13F);
            this.lblCliente.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCliente.Location = new System.Drawing.Point(217, 547);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(69, 25);
            this.lblCliente.TabIndex = 67;
            this.lblCliente.Text = "Cliente:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClienteNombre
            // 
            this.lblClienteNombre.AutoSize = true;
            this.lblClienteNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.lblClienteNombre.Font = new System.Drawing.Font("Segoe UI Semilight", 17F);
            this.lblClienteNombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblClienteNombre.Location = new System.Drawing.Point(217, 570);
            this.lblClienteNombre.Name = "lblClienteNombre";
            this.lblClienteNombre.Size = new System.Drawing.Size(104, 31);
            this.lblClienteNombre.TabIndex = 68;
            this.lblClienteNombre.Text = "Ferretera";
            this.lblClienteNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.Crimson;
            this.btnAnular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAnular.Image = ((System.Drawing.Image)(resources.GetObject("btnAnular.Image")));
            this.btnAnular.Location = new System.Drawing.Point(490, 548);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(58, 52);
            this.btnAnular.TabIndex = 69;
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(124)))), ((int)(((byte)(204)))));
            this.btnReload.BackgroundImage = global::Mep3._0.Properties.Resources.Flecha2;
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReload.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReload.Location = new System.Drawing.Point(21, 548);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(167, 52);
            this.btnReload.TabIndex = 70;
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // rectangleShape8
            // 
            this.rectangleShape8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(76)))), ((int)(((byte)(122)))));
            this.rectangleShape8.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(46)))), ((int)(((byte)(69)))));
            this.rectangleShape8.BorderWidth = 4;
            this.rectangleShape8.CornerRadius = 3;
            this.rectangleShape8.Enabled = false;
            this.rectangleShape8.FillColor = System.Drawing.Color.ForestGreen;
            this.rectangleShape8.FillGradientColor = System.Drawing.Color.DodgerBlue;
            this.rectangleShape8.FillGradientStyle = Microsoft.VisualBasic.PowerPacks.FillGradientStyle.Horizontal;
            this.rectangleShape8.Location = new System.Drawing.Point(11, 541);
            this.rectangleShape8.Name = "rectangleShape8";
            this.rectangleShape8.Size = new System.Drawing.Size(183, 65);
            // 
            // Excel_frmVerOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(59)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(704, 614);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblClienteNombre);
            this.Controls.Add(this.lblTituloTablaDetalle);
            this.Controls.Add(this.dtgvDetalle);
            this.Controls.Add(this.title);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.dtgvLista);
            this.Controls.Add(this.shapeContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Excel_frmVerOrdenes";
            this.Load += new System.EventHandler(this.frmMOD_Ordenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dtgvLista;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label title;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        public System.Windows.Forms.DataGridView dtgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape6;
        private System.Windows.Forms.Label lblTituloTablaDetalle;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndiceLista;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape7;
        private System.Windows.Forms.Button btnAnular;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape8;
        private System.Windows.Forms.Button btnReload;
    }
}