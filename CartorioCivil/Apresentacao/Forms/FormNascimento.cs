using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CartorioCivil.Entidades;
using CartorioCivil.Negocios.Servicos;

namespace CartorioCivil.Apresentacao.Forms
{
    public partial class FormNascimento : Form
    {
        private Nascimento _nascimentoSelecionado;
        private readonly NascimentoServico _nascimentoServico;
        public FormNascimento()
        {
            InitializeComponent();
            _nascimentoServico = new NascimentoServico();
            AtualizarBotoes();
        }

        private void AtualizarBotoes()
        {
            bool enableButtons = _nascimentoSelecionado != null && _nascimentoSelecionado.Id > 0;

            btnExcluir.Enabled = enableButtons;
            btnAtualizar.Enabled = enableButtons;
        }


        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var novoNascimento = new Nascimento
                {
                    NomeRegistrado = txtNome.Text.Trim(),
                    NomePai = txtNomePai.Text.Trim(),
                    NomeMae = txtNomeMae.Text.Trim(),
                    CpfnPai = txtCpfPai.Text.Trim(),
                    CpfnMae = txtCpfMae.Text.Trim(),
                    DataNascimento = dtNascimento.Value.Date,
                    DataRegistro = dtRegistro.Value.Date,
                    DataNascimentoPai = dtNascimentoPai.Value.Date,
                    DataNascimentoMae = dtNascimentoMae.Value.Date
                };

                var id = await _nascimentoServico.AdicionarAsync(novoNascimento);
                novoNascimento.Id = id;
                _nascimentoSelecionado = novoNascimento;

                MessageBox.Show("Nascimento adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar nascimento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                _nascimentoSelecionado.NomeRegistrado = txtNome.Text.Trim();
                _nascimentoSelecionado.NomePai = txtNomePai.Text.Trim();
                _nascimentoSelecionado.NomeMae = txtNomeMae.Text.Trim();
                _nascimentoSelecionado.CpfnPai = txtCpfPai.Text.Trim();
                _nascimentoSelecionado.CpfnMae = txtCpfMae.Text.Trim();
                _nascimentoSelecionado.DataNascimento = dtNascimento.Value.Date;
                _nascimentoSelecionado.DataRegistro = dtRegistro.Value.Date;
                _nascimentoSelecionado.DataNascimentoPai = dtNascimentoPai.Value.Date;
                _nascimentoSelecionado.DataNascimentoMae = dtNascimentoMae.Value.Date;

                await _nascimentoServico.AtualizarAsync(_nascimentoSelecionado);
                MessageBox.Show("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                await _nascimentoServico.RemoverAsync(_nascimentoSelecionado.Id);
                MessageBox.Show("Excluído com sucesso!");
                LimparForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var nome = txtBuscaNome.Text.Trim();
                var nascimentos = await _nascimentoServico.ObterPorNomeAsync(nome);
                PreencherListView(nascimentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void listViewResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResultados.SelectedItems.Count > 0)
            {
                var item = listViewResultados.SelectedItems[0];
                int id = Convert.ToInt32(item.Tag);

                _nascimentoSelecionado = await _nascimentoServico.ObterPorIdAsync(id);

                if (_nascimentoSelecionado != null)
                {
                    txtNome.Text = _nascimentoSelecionado.NomeRegistrado;
                    txtNomePai.Text = _nascimentoSelecionado.NomePai;
                    txtNomeMae.Text = _nascimentoSelecionado.NomeMae;
                    txtCpfPai.Text = _nascimentoSelecionado.CpfnPai;
                    txtCpfMae.Text = _nascimentoSelecionado.CpfnMae;
                    dtNascimento.Value = _nascimentoSelecionado.DataNascimento;
                    dtRegistro.Value = _nascimentoSelecionado.DataRegistro;
                    dtNascimentoPai.Value = _nascimentoSelecionado.DataNascimentoPai;
                    dtNascimentoMae.Value = _nascimentoSelecionado.DataNascimentoMae;
                }
                AtualizarBotoes();
            }
        }

        private void PreencherListView(List<Nascimento> nascimentos)
        {
            listViewResultados.Items.Clear();

            foreach (var nascimento in nascimentos)
            {
                var item = new ListViewItem(nascimento.NomeRegistrado);
                item.SubItems.Add(nascimento.NomePai);
                item.SubItems.Add(nascimento.NomeMae);
                item.SubItems.Add(nascimento.DataNascimento.ToShortDateString());

                item.Tag = nascimento.Id;
                listViewResultados.Items.Add(item);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e) => LimparForm();

        private void LimparForm()
        {
            txtNome.Clear();
            txtNomePai.Clear();
            txtNomeMae.Clear();
            txtCpfPai.Clear();
            txtCpfMae.Clear();
            txtBuscaNome.Clear();
            dtNascimento.Value = DateTime.Today;
            dtRegistro.Value = DateTime.Today;
            dtNascimentoPai.Value = DateTime.Today;
            dtNascimentoMae.Value = DateTime.Today;
            listViewResultados.Items.Clear();
            _nascimentoSelecionado = null;
            AtualizarBotoes();
        }

    }
}
