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
    public partial class FormObito : Form
    {
        private Obito _obitoSelecionado;
        private readonly ObitoServico _obitoServico;
        public FormObito()
        {
            InitializeComponent();
            _obitoServico = new ObitoServico();
            AtualizarBotoes();
        }

        private void AtualizarBotoes()
        {
            bool enable = _obitoSelecionado != null && _obitoSelecionado.Id > 0;
            btnAtualizar.Enabled = enable;
            btnExcluir.Enabled = enable;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LimparForm();
                string nome = txtBusca.Text.Trim();

                if (string.IsNullOrWhiteSpace(nome))
                    throw new ArgumentException("Digite um nome para buscar.");

                var resultados = await _obitoServico.ObterPorNomeAsync(nome);
                if (resultados.Count == 0)
                    MessageBox.Show("Nenhum óbito encontrado com esse nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    PreencherListView(resultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar óbito: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void PreencherListView(List<Obito> obitos)
            {
            listViewResultados.Items.Clear();

            foreach (var obito in obitos)
            {
                var item = new ListViewItem(obito.NomeFalecido);
                item.SubItems.Add(obito.DataObito.ToShortDateString());
                item.SubItems.Add(obito.DataNascimento.ToShortDateString());
                item.SubItems.Add(obito.NomePai);
                item.SubItems.Add(obito.NomeMae);
                item.Tag = obito;
                listViewResultados.Items.Add(item);
            }

        }

        private void LimparForm()
        {
            txtNomeFalecido.Clear();
            txtNomePai.Clear();
            txtNomeMae.Clear();
            dtNascimento.Value = DateTime.Today;
            dtDataObito.Value = DateTime.Today;
            dtDataRegistro.Value = DateTime.Today;
            dtNascimentoPai.Value = DateTime.Today;
            dtNascimentoMae.Value = DateTime.Today;
            listViewResultados.Items.Clear();
            _obitoSelecionado = null;
            AtualizarBotoes();
        }

        private void listViewResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResultados.SelectedItems.Count > 0)
            {
                _obitoSelecionado = (Obito)listViewResultados.SelectedItems[0].Tag;

                txtNomeFalecido.Text = _obitoSelecionado.NomeFalecido;
                txtNomePai.Text = _obitoSelecionado.NomePai;
                txtNomeMae.Text = _obitoSelecionado.NomeMae;
                dtNascimento.Value = _obitoSelecionado.DataNascimento;
                dtDataObito.Value = _obitoSelecionado.DataObito;
                dtDataRegistro.Value = _obitoSelecionado.DataRegistro;
                dtNascimentoPai.Value = _obitoSelecionado.DataNascimentoPai;
                dtNascimentoMae.Value = _obitoSelecionado.DataNascimentoMae;

                AtualizarBotoes();
            }
        }

        private Obito ObterDadosDoForm() => new Obito
            {
                NomeFalecido = txtNomeFalecido.Text.Trim(),
                NomePai = txtNomePai.Text.Trim(),
                NomeMae = txtNomeMae.Text.Trim(),
                DataNascimento = dtNascimento.Value.Date,
                DataObito = dtDataObito.Value.Date,
                DataRegistro = dtDataRegistro.Value.Date,
                DataNascimentoPai = dtNascimentoPai.Value.Date,
                DataNascimentoMae = dtNascimentoMae.Value.Date
            };

        private async void btnAdicionar_Click_1(object sender, EventArgs e)
        {

            try
            {
                var novoObito = ObterDadosDoForm();

                int id = await _obitoServico.AdicionarAsync(novoObito);
                novoObito.Id = id;
                _obitoSelecionado = novoObito;

                MessageBox.Show("Óbito adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar óbito: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_obitoSelecionado == null) return;

                var obitoAtualizado = ObterDadosDoForm();
                obitoAtualizado.Id = _obitoSelecionado.Id;

                await _obitoServico.AtualizarAsync(obitoAtualizado);
                MessageBox.Show("Óbito atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar óbito: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_obitoSelecionado == null) return;

                await _obitoServico.RemoverAsync(_obitoSelecionado.Id);
                MessageBox.Show("Óbito excluído com sucesso!");
                LimparForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir óbito: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click_1(object sender, EventArgs e) => LimparForm();

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
