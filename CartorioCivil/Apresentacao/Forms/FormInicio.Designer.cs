namespace CartorioCivil.Apresentacao.Forms
{
    partial class FormInicio
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
            this.btnObito = new System.Windows.Forms.Button();
            this.btnCasamento = new System.Windows.Forms.Button();
            this.btnNascimento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnObito
            // 
            this.btnObito.BackColor = System.Drawing.Color.White;
            this.btnObito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObito.FlatAppearance.BorderSize = 0;
            this.btnObito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObito.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnObito.ForeColor = System.Drawing.Color.DimGray;
            this.btnObito.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObito.Location = new System.Drawing.Point(593, 106);
            this.btnObito.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnObito.Name = "btnObito";
            this.btnObito.Size = new System.Drawing.Size(122, 77);
            this.btnObito.TabIndex = 77;
            this.btnObito.Text = "Obito";
            this.btnObito.UseVisualStyleBackColor = false;
            this.btnObito.Click += new System.EventHandler(this.btnObito_Click);
            // 
            // btnCasamento
            // 
            this.btnCasamento.BackColor = System.Drawing.Color.White;
            this.btnCasamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCasamento.FlatAppearance.BorderSize = 0;
            this.btnCasamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCasamento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCasamento.ForeColor = System.Drawing.Color.DimGray;
            this.btnCasamento.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCasamento.Location = new System.Drawing.Point(342, 106);
            this.btnCasamento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCasamento.Name = "btnCasamento";
            this.btnCasamento.Size = new System.Drawing.Size(122, 77);
            this.btnCasamento.TabIndex = 76;
            this.btnCasamento.Text = "Casamento";
            this.btnCasamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCasamento.UseVisualStyleBackColor = false;
            this.btnCasamento.Click += new System.EventHandler(this.btnCasamento_Click);
            // 
            // btnNascimento
            // 
            this.btnNascimento.BackColor = System.Drawing.Color.White;
            this.btnNascimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNascimento.FlatAppearance.BorderSize = 0;
            this.btnNascimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNascimento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNascimento.ForeColor = System.Drawing.Color.DimGray;
            this.btnNascimento.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNascimento.Location = new System.Drawing.Point(80, 106);
            this.btnNascimento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNascimento.Name = "btnNascimento";
            this.btnNascimento.Size = new System.Drawing.Size(122, 77);
            this.btnNascimento.TabIndex = 75;
            this.btnNascimento.Text = "Nascimento";
            this.btnNascimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNascimento.UseVisualStyleBackColor = false;
            this.btnNascimento.Click += new System.EventHandler(this.btnNascimento_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(253)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(878, 276);
            this.Controls.Add(this.btnObito);
            this.Controls.Add(this.btnCasamento);
            this.Controls.Add(this.btnNascimento);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNascimento;
        private System.Windows.Forms.Button btnCasamento;
        private System.Windows.Forms.Button btnObito;
    }
}