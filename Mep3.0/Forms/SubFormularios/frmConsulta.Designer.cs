namespace Mep3._0
{
    partial class frmConsulta
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
            this.lblMensaje2 = new System.Windows.Forms.Label();
            this.lblMensaje1 = new System.Windows.Forms.Label();
            this.btnNO = new System.Windows.Forms.Button();
            this.btnSI = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMensaje2
            // 
            this.lblMensaje2.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblMensaje2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMensaje2.Location = new System.Drawing.Point(12, 80);
            this.lblMensaje2.Name = "lblMensaje2";
            this.lblMensaje2.Size = new System.Drawing.Size(458, 40);
            this.lblMensaje2.TabIndex = 18;
            this.lblMensaje2.Text = "MENSAJE 2";
            this.lblMensaje2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMensaje1
            // 
            this.lblMensaje1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblMensaje1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMensaje1.Location = new System.Drawing.Point(11, 21);
            this.lblMensaje1.Name = "lblMensaje1";
            this.lblMensaje1.Size = new System.Drawing.Size(456, 39);
            this.lblMensaje1.TabIndex = 17;
            this.lblMensaje1.Text = "MENSAJE 1";
            this.lblMensaje1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNO
            // 
            this.btnNO.BackColor = System.Drawing.Color.Crimson;
            this.btnNO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnNO.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNO.Location = new System.Drawing.Point(70, 160);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(165, 50);
            this.btnNO.TabIndex = 15;
            this.btnNO.Text = "No, Cancelar";
            this.btnNO.UseVisualStyleBackColor = false;
            this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
            // 
            // btnSI
            // 
            this.btnSI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(173)))), ((int)(((byte)(0)))));
            this.btnSI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSI.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSI.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSI.Location = new System.Drawing.Point(252, 160);
            this.btnSI.Name = "btnSI";
            this.btnSI.Size = new System.Drawing.Size(165, 50);
            this.btnSI.TabIndex = 16;
            this.btnSI.Text = "Si , estoy seguro";
            this.btnSI.UseVisualStyleBackColor = false;
            this.btnSI.Click += new System.EventHandler(this.btnSI_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOk.Location = new System.Drawing.Point(133, 160);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(222, 50);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "OK ";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblConsulta
            // 
            this.lblConsulta.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsulta.Location = new System.Drawing.Point(70, 21);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(347, 136);
            this.lblConsulta.TabIndex = 20;
            this.lblConsulta.Text = "\r\n";
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 231);
            this.Controls.Add(this.lblMensaje2);
            this.Controls.Add(this.lblMensaje1);
            this.Controls.Add(this.btnNO);
            this.Controls.Add(this.btnSI);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblConsulta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(496, 270);
            this.MinimumSize = new System.Drawing.Size(496, 270);
            this.Name = "frmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmacion";
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje2;
        private System.Windows.Forms.Label lblMensaje1;
        private System.Windows.Forms.Button btnNO;
        private System.Windows.Forms.Button btnSI;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblConsulta;
    }
}