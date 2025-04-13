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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dtNascimentoMae = new System.Windows.Forms.DateTimePicker();
            this.dtNascimentoPai = new System.Windows.Forms.DateTimePicker();
            this.dtRegistro = new System.Windows.Forms.DateTimePicker();
            this.txtNomeMae = new System.Windows.Forms.TextBox();
            this.txtNomePai = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.listViewResultados = new System.Windows.Forms.ListView();
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NomePai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NomeMae = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataNascimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtNascimento = new System.Windows.Forms.DateTimePicker();
            this.txtBuscaNome = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCpfPai = new System.Windows.Forms.TextBox();
            this.txtCpfMae = new System.Windows.Forms.TextBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 315);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "CPF do pai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 369);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "CPF da mãe";
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.Color.DimGray;
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.Location = new System.Drawing.Point(356, 435);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(89, 25);
            this.btnLimpar.TabIndex = 85;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click_1);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.DimGray;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.Location = new System.Drawing.Point(239, 435);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(89, 25);
            this.btnExcluir.TabIndex = 84;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.White;
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.DimGray;
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtualizar.Location = new System.Drawing.Point(130, 435);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(89, 25);
            this.btnAtualizar.TabIndex = 83;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.FlatAppearance.BorderSize = 0;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.DimGray;
            this.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionar.Location = new System.Drawing.Point(15, 433);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(89, 25);
            this.btnAdicionar.TabIndex = 82;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click_1);
            // 
            // dtNascimentoMae
            // 
            this.dtNascimentoMae.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtNascimentoMae.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtNascimentoMae.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtNascimentoMae.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtNascimentoMae.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtNascimentoMae.CustomFormat = "dd/MM/yyyy";
            this.dtNascimentoMae.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNascimentoMae.Location = new System.Drawing.Point(373, 390);
            this.dtNascimentoMae.Name = "dtNascimentoMae";
            this.dtNascimentoMae.Size = new System.Drawing.Size(89, 23);
            this.dtNascimentoMae.TabIndex = 81;
            // 
            // dtNascimentoPai
            // 
            this.dtNascimentoPai.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtNascimentoPai.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtNascimentoPai.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtNascimentoPai.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtNascimentoPai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtNascimentoPai.CustomFormat = "dd/MM/yyyy";
            this.dtNascimentoPai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNascimentoPai.Location = new System.Drawing.Point(373, 335);
            this.dtNascimentoPai.Name = "dtNascimentoPai";
            this.dtNascimentoPai.Size = new System.Drawing.Size(89, 23);
            this.dtNascimentoPai.TabIndex = 80;
            // 
            // dtRegistro
            // 
            this.dtRegistro.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtRegistro.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtRegistro.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtRegistro.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtRegistro.CustomFormat = "dd/MM/yyyy";
            this.dtRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRegistro.Location = new System.Drawing.Point(373, 281);
            this.dtRegistro.Name = "dtRegistro";
            this.dtRegistro.Size = new System.Drawing.Size(89, 23);
            this.dtRegistro.TabIndex = 79;
            // 
            // txtNomeMae
            // 
            this.txtNomeMae.BackColor = System.Drawing.Color.White;
            this.txtNomeMae.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeMae.ForeColor = System.Drawing.Color.DimGray;
            this.txtNomeMae.Location = new System.Drawing.Point(15, 387);
            this.txtNomeMae.Name = "txtNomeMae";
            this.txtNomeMae.Size = new System.Drawing.Size(215, 25);
            this.txtNomeMae.TabIndex = 77;
            // 
            // txtNomePai
            // 
            this.txtNomePai.BackColor = System.Drawing.Color.White;
            this.txtNomePai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePai.ForeColor = System.Drawing.Color.DimGray;
            this.txtNomePai.Location = new System.Drawing.Point(15, 333);
            this.txtNomePai.Name = "txtNomePai";
            this.txtNomePai.Size = new System.Drawing.Size(215, 25);
            this.txtNomePai.TabIndex = 76;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.DimGray;
            this.txtNome.Location = new System.Drawing.Point(15, 279);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(215, 25);
            this.txtNome.TabIndex = 75;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(239, 68);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 27);
            this.btnBuscar.TabIndex = 74;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // listViewResultados
            // 
            this.listViewResultados.BackColor = System.Drawing.Color.White;
            this.listViewResultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nome,
            this.NomePai,
            this.NomeMae,
            this.DataNascimento});
            this.listViewResultados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listViewResultados.ForeColor = System.Drawing.Color.DimGray;
            this.listViewResultados.FullRowSelect = true;
            this.listViewResultados.GridLines = true;
            this.listViewResultados.HideSelection = false;
            this.listViewResultados.Location = new System.Drawing.Point(13, 112);
            this.listViewResultados.Name = "listViewResultados";
            this.listViewResultados.Size = new System.Drawing.Size(617, 121);
            this.listViewResultados.TabIndex = 73;
            this.listViewResultados.UseCompatibleStateImageBehavior = false;
            this.listViewResultados.View = System.Windows.Forms.View.Details;
            this.listViewResultados.SelectedIndexChanged += new System.EventHandler(this.listViewResultados_SelectedIndexChanged);
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 148;
            // 
            // NomePai
            // 
            this.NomePai.Text = "Nome do Pai";
            this.NomePai.Width = 159;
            // 
            // NomeMae
            // 
            this.NomeMae.Text = "Nome da Mãe";
            this.NomeMae.Width = 125;
            // 
            // DataNascimento
            // 
            this.DataNascimento.Text = "Data de Nascimento";
            this.DataNascimento.Width = 120;
            // 
            // dtNascimento
            // 
            this.dtNascimento.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtNascimento.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtNascimento.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtNascimento.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtNascimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtNascimento.CustomFormat = "dd/MM/yyyy";
            this.dtNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNascimento.Location = new System.Drawing.Point(236, 281);
            this.dtNascimento.Name = "dtNascimento";
            this.dtNascimento.Size = new System.Drawing.Size(89, 23);
            this.dtNascimento.TabIndex = 72;
            // 
            // txtBuscaNome
            // 
            this.txtBuscaNome.BackColor = System.Drawing.Color.White;
            this.txtBuscaNome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaNome.ForeColor = System.Drawing.Color.DimGray;
            this.txtBuscaNome.Location = new System.Drawing.Point(13, 68);
            this.txtBuscaNome.Name = "txtBuscaNome";
            this.txtBuscaNome.Size = new System.Drawing.Size(206, 25);
            this.txtBuscaNome.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(370, 369);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 15);
            this.label10.TabIndex = 70;
            this.label10.Text = "Data de nascimento da mãe";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(370, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 15);
            this.label9.TabIndex = 69;
            this.label9.Text = "Data de nascimento do pai";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(370, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 68;
            this.label8.Text = "Data de registro";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(233, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 15);
            this.label12.TabIndex = 66;
            this.label12.Text = "Data de nascimento";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.Location = new System.Drawing.Point(12, 369);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 65;
            this.label13.Text = "Nome da mãe";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.Location = new System.Drawing.Point(12, 315);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 15);
            this.label14.TabIndex = 64;
            this.label14.Text = "Nome do pai";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.Location = new System.Drawing.Point(12, 261);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 15);
            this.label15.TabIndex = 63;
            this.label15.Text = "Nome do falecido";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DimGray;
            this.label16.Location = new System.Drawing.Point(12, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 15);
            this.label16.TabIndex = 62;
            this.label16.Text = "Busca (Nome do nascido)";
            // 
            // txtCpfPai
            // 
            this.txtCpfPai.BackColor = System.Drawing.Color.White;
            this.txtCpfPai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpfPai.ForeColor = System.Drawing.Color.DimGray;
            this.txtCpfPai.Location = new System.Drawing.Point(236, 333);
            this.txtCpfPai.Name = "txtCpfPai";
            this.txtCpfPai.Size = new System.Drawing.Size(131, 25);
            this.txtCpfPai.TabIndex = 86;
            // 
            // txtCpfMae
            // 
            this.txtCpfMae.BackColor = System.Drawing.Color.White;
            this.txtCpfMae.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpfMae.ForeColor = System.Drawing.Color.DimGray;
            this.txtCpfMae.Location = new System.Drawing.Point(236, 388);
            this.txtCpfMae.Name = "txtCpfMae";
            this.txtCpfMae.Size = new System.Drawing.Size(131, 25);
            this.txtCpfMae.TabIndex = 87;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.White;
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.DimGray;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInicio.Location = new System.Drawing.Point(15, 12);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(104, 25);
            this.btnInicio.TabIndex = 111;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.Color.White;
            this.btnRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelatorio.FlatAppearance.BorderSize = 0;
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.ForeColor = System.Drawing.Color.DimGray;
            this.btnRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelatorio.Location = new System.Drawing.Point(724, 162);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(89, 27);
            this.btnRelatorio.TabIndex = 112;
            this.btnRelatorio.Text = "Gerar";
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // dtInicio
            // 
            this.dtInicio.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtInicio.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtInicio.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtInicio.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtInicio.CustomFormat = "dd/MM/yyyy";
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInicio.Location = new System.Drawing.Point(676, 133);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(89, 23);
            this.dtInicio.TabIndex = 113;
            // 
            // dtFinal
            // 
            this.dtFinal.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFinal.CalendarForeColor = System.Drawing.Color.DimGray;
            this.dtFinal.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtFinal.CalendarTitleForeColor = System.Drawing.Color.DimGray;
            this.dtFinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtFinal.CustomFormat = "dd/MM/yyyy";
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinal.Location = new System.Drawing.Point(771, 133);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(89, 23);
            this.dtFinal.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(673, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 115;
            this.label1.Text = "Data de Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(768, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 116;
            this.label2.Text = "Data Final";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(652, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 21);
            this.label5.TabIndex = 117;
            this.label5.Text = "Gerar Relatorio de Nascimento";
            // 
            // FormNascimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(253)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(961, 498);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFinal);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.txtCpfMae);
            this.Controls.Add(this.txtCpfPai);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dtNascimentoMae);
            this.Controls.Add(this.dtNascimentoPai);
            this.Controls.Add(this.dtRegistro);
            this.Controls.Add(this.txtNomeMae);
            this.Controls.Add(this.txtNomePai);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.listViewResultados);
            this.Controls.Add(this.dtNascimento);
            this.Controls.Add(this.txtBuscaNome);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormNascimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nascimento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DateTimePicker dtNascimentoMae;
        private System.Windows.Forms.DateTimePicker dtNascimentoPai;
        private System.Windows.Forms.DateTimePicker dtRegistro;
        private System.Windows.Forms.TextBox txtNomeMae;
        private System.Windows.Forms.TextBox txtNomePai;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListView listViewResultados;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader DataNascimento;
        private System.Windows.Forms.ColumnHeader NomePai;
        private System.Windows.Forms.ColumnHeader NomeMae;
        private System.Windows.Forms.DateTimePicker dtNascimento;
        private System.Windows.Forms.TextBox txtBuscaNome;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCpfPai;
        private System.Windows.Forms.TextBox txtCpfMae;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}