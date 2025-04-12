namespace CartorioCivil.Apresentacao.Forms
{
    partial class FormNascimento
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
            this.listViewResultados = new System.Windows.Forms.ListView();
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mãe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nascimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscaNome = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomePai = new System.Windows.Forms.TextBox();
            this.txtNomeMae = new System.Windows.Forms.TextBox();
            this.txtCpfPai = new System.Windows.Forms.TextBox();
            this.txtCpfMae = new System.Windows.Forms.TextBox();
            this.dtNascimento = new System.Windows.Forms.DateTimePicker();
            this.dtRegistro = new System.Windows.Forms.DateTimePicker();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dtNascimentoPai = new System.Windows.Forms.DateTimePicker();
            this.dtNascimentoMae = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // listViewResultados
            // 
            this.listViewResultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nome,
            this.Pai,
            this.Mãe,
            this.Nascimento});
            this.listViewResultados.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewResultados.HideSelection = false;
            this.listViewResultados.Location = new System.Drawing.Point(56, 62);
            this.listViewResultados.Name = "listViewResultados";
            this.listViewResultados.Size = new System.Drawing.Size(675, 154);
            this.listViewResultados.TabIndex = 0;
            this.listViewResultados.UseCompatibleStateImageBehavior = false;
            this.listViewResultados.View = System.Windows.Forms.View.Details;
            this.listViewResultados.SelectedIndexChanged += new System.EventHandler(this.listViewResultados_SelectedIndexChanged);
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 104;
            // 
            // Pai
            // 
            this.Pai.Text = "Pai";
            this.Pai.Width = 113;
            // 
            // Mãe
            // 
            this.Mãe.Text = "Mãe";
            this.Mãe.Width = 115;
            // 
            // Nascimento
            // 
            this.Nascimento.Text = "Nascimento";
            this.Nascimento.Width = 120;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(359, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscaNome
            // 
            this.txtBuscaNome.Location = new System.Drawing.Point(153, 35);
            this.txtBuscaNome.Name = "txtBuscaNome";
            this.txtBuscaNome.Size = new System.Drawing.Size(200, 20);
            this.txtBuscaNome.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(53, 257);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(145, 20);
            this.txtNome.TabIndex = 5;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(53, 244);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 6;
            this.lblNome.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome do pai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nome da mãe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "CPF do pai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "CPF da mãe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Data de nascimento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Data de registro";
            // 
            // txtNomePai
            // 
            this.txtNomePai.Location = new System.Drawing.Point(56, 297);
            this.txtNomePai.Name = "txtNomePai";
            this.txtNomePai.Size = new System.Drawing.Size(100, 20);
            this.txtNomePai.TabIndex = 13;
            // 
            // txtNomeMae
            // 
            this.txtNomeMae.Location = new System.Drawing.Point(178, 297);
            this.txtNomeMae.Name = "txtNomeMae";
            this.txtNomeMae.Size = new System.Drawing.Size(100, 20);
            this.txtNomeMae.TabIndex = 14;
            // 
            // txtCpfPai
            // 
            this.txtCpfPai.Location = new System.Drawing.Point(303, 296);
            this.txtCpfPai.Name = "txtCpfPai";
            this.txtCpfPai.Size = new System.Drawing.Size(100, 20);
            this.txtCpfPai.TabIndex = 15;
            // 
            // txtCpfMae
            // 
            this.txtCpfMae.Location = new System.Drawing.Point(425, 296);
            this.txtCpfMae.Name = "txtCpfMae";
            this.txtCpfMae.Size = new System.Drawing.Size(100, 20);
            this.txtCpfMae.TabIndex = 16;
            // 
            // dtNascimento
            // 
            this.dtNascimento.Location = new System.Drawing.Point(56, 335);
            this.dtNascimento.Name = "dtNascimento";
            this.dtNascimento.Size = new System.Drawing.Size(200, 20);
            this.dtNascimento.TabIndex = 17;
            // 
            // dtRegistro
            // 
            this.dtRegistro.Location = new System.Drawing.Point(271, 335);
            this.dtRegistro.Name = "dtRegistro";
            this.dtRegistro.Size = new System.Drawing.Size(200, 20);
            this.dtRegistro.TabIndex = 18;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(497, 332);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 19;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(589, 331);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 20;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(589, 374);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 21;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Nome para buscar";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(497, 375);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 23;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dtNascimentoPai
            // 
            this.dtNascimentoPai.Location = new System.Drawing.Point(56, 377);
            this.dtNascimentoPai.Name = "dtNascimentoPai";
            this.dtNascimentoPai.Size = new System.Drawing.Size(200, 20);
            this.dtNascimentoPai.TabIndex = 24;
            // 
            // dtNascimentoMae
            // 
            this.dtNascimentoMae.Location = new System.Drawing.Point(271, 377);
            this.dtNascimentoMae.Name = "dtNascimentoMae";
            this.dtNascimentoMae.Size = new System.Drawing.Size(200, 20);
            this.dtNascimentoMae.TabIndex = 25;
            // 
            // FormNascimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtNascimentoMae);
            this.Controls.Add(this.dtNascimentoPai);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.dtRegistro);
            this.Controls.Add(this.dtNascimento);
            this.Controls.Add(this.txtCpfMae);
            this.Controls.Add(this.txtCpfPai);
            this.Controls.Add(this.txtNomeMae);
            this.Controls.Add(this.txtNomePai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtBuscaNome);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.listViewResultados);
            this.Name = "FormNascimento";
            this.Text = "Nascimento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewResultados;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscaNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomePai;
        private System.Windows.Forms.TextBox txtNomeMae;
        private System.Windows.Forms.TextBox txtCpfPai;
        private System.Windows.Forms.TextBox txtCpfMae;
        private System.Windows.Forms.DateTimePicker dtNascimento;
        private System.Windows.Forms.DateTimePicker dtRegistro;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DateTimePicker dtNascimentoPai;
        private System.Windows.Forms.DateTimePicker dtNascimentoMae;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Pai;
        private System.Windows.Forms.ColumnHeader Mãe;
        private System.Windows.Forms.ColumnHeader Nascimento;
    }
}