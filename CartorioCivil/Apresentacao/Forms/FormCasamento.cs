using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CartorioCivil.Entidades;
using CartorioCivil.Negocios.Servicos;

namespace CartorioCivil.Apresentacao.Forms
{
    public partial class FormCasamento : Form
    {
        private Casamento _casamentoSelecionado;
        private Conjuge _conjuge1;
        private Conjuge _conjuge2;
        private readonly CasamentoServico _casamentoServico;

        public FormCasamento()
        {
            InitializeComponent();
            _casamentoServico = new CasamentoServico();
            AtualizarBotoes();
        }

        private void AtualizarBotoes()
        {
            bool enable = _casamentoSelecionado != null && _casamentoSelecionado.Id > 0;
            btnAtualizar.Enabled = enable;
            btnExcluir.Enabled = enable;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LimparForm();
                string entrada = txtBusca.Text.Trim();

                if (string.IsNullOrWhiteSpace(entrada))
                    throw new ArgumentException("Digite um nome ou CPF para buscar.");

                var casamentosEncontrados = new List<Casamento>();

                if (char.IsDigit(entrada[0]))
                {
                    var conjuge = await _casamentoServico.ObterConjugePorCpfAsync(entrada);
                    if (conjuge != null)
                    {
                        var casamento = await _casamentoServico.ObterCasamentoPorConjugeAsync(conjuge.Id);
                        if (casamento != null)
                            casamentosEncontrados.Add(casamento);
                    }
                }
                else
                {
                    var conjuges = await _casamentoServico.ObterConjugePorNomeAsync(entrada);
                    foreach (var conjuge in conjuges)
                    {
                        var casamento = await _casamentoServico.ObterCasamentoPorConjugeAsync(conjuge.Id);
                        if (casamento != null)
                            casamentosEncontrados.Add(casamento);
                    }
                }

                if (casamentosEncontrados.Count == 0)
                    MessageBox.Show("Nenhum casamento encontrado para a busca realizada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    PreencherListView(casamentosEncontrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar casamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherListView(List<Casamento> casamentos)
        {


            foreach (var casamento in casamentos)
            {
                var item = new ListViewItem(casamento.Conjuge1.Nome);
                item.SubItems.Add(casamento.Conjuge1.CPF);

                item.SubItems.Add(casamento.Conjuge2.Nome);
                item.SubItems.Add(casamento.Conjuge2.CPF);

                item.SubItems.Add(casamento.DataCasamento.ToShortDateString());
                item.SubItems.Add(casamento.DataRegistro.ToShortDateString());

                item.Tag = casamento;
                listViewResultados.Items.Add(item);
            }
        }

        private Conjuge ObterConjuge1() => new Conjuge
            {
                Nome = txtNomeConjuge1.Text.Trim(),
                CPF = txtCpfConjuge1.Text.Trim(),
                NomePai = txtNomePaiConjuge1.Text.Trim(),
                CpfPai = txtCpfPaiConjuge1.Text.Trim(),
                NomeMae = txtNomeMaeConjuge1.Text.Trim(),
                CpfMae = txtCpfMaeConjuge1.Text.Trim(),
                DataNascimentoPai = dtNascimentoPaiConjuge1.Value,
                DataNascimentoMae = dtNascimentoMaeConjuge1.Value
            };

        private Conjuge ObterConjuge2() => new Conjuge
            {
                Nome = txtNomeConjuge2.Text.Trim(),
                CPF = txtCpfConjuge2.Text.Trim(),
                NomePai = txtNomePaiConjuge2.Text.Trim(),
                CpfPai = txtCpfPaiConjuge2.Text.Trim(),
                NomeMae = txtNomeMaeConjuge2.Text.Trim(),
                CpfMae = txtCpfMaeConjuge2.Text.Trim(),
                DataNascimentoPai = dtNascimentoPaiConjuge2.Value,
                DataNascimentoMae = dtNascimentoMaeConjuge2.Value
            };

        private void LimparForm()
        {
            dtNascimentoPaiConjuge1.Value = DateTime.Today;
            dtNascimentoMaeConjuge1.Value = DateTime.Today;
            dtNascimentoPaiConjuge2.Value = DateTime.Today;
            dtNascimentoMaeConjuge2.Value = DateTime.Today;
            dtDataCasamento.Value = DateTime.Today;
            dtDataRegistro.Value = DateTime.Today;

            txtNomeConjuge2.Clear();
            txtCpfConjuge2.Clear();
            txtNomePaiConjuge2.Clear();
            txtCpfPaiConjuge2.Clear();
            txtNomeMaeConjuge2.Clear();
            txtCpfMaeConjuge2.Clear();

            txtNomeConjuge1.Clear();
            txtCpfConjuge1.Clear();
            txtNomePaiConjuge1.Clear();
            txtCpfPaiConjuge1.Clear();
            txtNomeMaeConjuge1.Clear();
            txtCpfMaeConjuge1.Clear();

            listViewResultados.Items.Clear();

            _casamentoSelecionado = null;
            _conjuge1 = null;
            _conjuge2 = null;
            AtualizarBotoes();
        }

        private async void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            try
            {
                _conjuge1 = ObterConjuge1();
                _conjuge2 = ObterConjuge2();

                Casamento casamento = new Casamento
                {
                    DataCasamento = dtDataCasamento.Value.Date,
                    DataRegistro = dtDataRegistro.Value.Date
                };

                int id = await _casamentoServico.AdicionarAsync(casamento, _conjuge1, _conjuge2);
                casamento.Id = id;
                _conjuge1.Id = casamento.IdConjuge1;
                _conjuge2.Id = casamento.IdConjuge2;
                casamento.Conjuge1 = _conjuge1;
                casamento.Conjuge2 = _conjuge2;

                _casamentoSelecionado = casamento;

                MessageBox.Show("Casamento adicionado com sucesso!");
                AtualizarBotoes();
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
                if (_casamentoSelecionado == null) return;

                await _casamentoServico.RemoverAsync(_casamentoSelecionado.Id);
                MessageBox.Show("Casamento excluído com sucesso!");
                LimparForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_casamentoSelecionado == null) return;

                _casamentoSelecionado.DataCasamento = dtDataCasamento.Value.Date;
                _casamentoSelecionado.DataRegistro = dtDataRegistro.Value.Date;

                var conjuge1 = ObterConjuge1();
                var conjuge2 = ObterConjuge2();

                conjuge1.Id = _casamentoSelecionado.IdConjuge1;
                conjuge2.Id = _casamentoSelecionado.IdConjuge2;

                await _casamentoServico.AtualizarAsync(_casamentoSelecionado, conjuge1, conjuge2);
                MessageBox.Show("Casamento atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e) => LimparForm();

        private void listViewResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResultados.SelectedItems.Count > 0)
            {
                var casamento = (Casamento)listViewResultados.SelectedItems[0].Tag;
                _casamentoSelecionado = casamento;

                txtNomeConjuge1.Text = casamento.Conjuge1.Nome;
                txtCpfConjuge1.Text = casamento.Conjuge1.CPF;
                txtNomePaiConjuge1.Text = casamento.Conjuge1.NomePai;
                txtCpfPaiConjuge1.Text = casamento.Conjuge1.CpfPai;
                txtNomeMaeConjuge1.Text = casamento.Conjuge1.NomeMae;
                txtCpfMaeConjuge1.Text = casamento.Conjuge1.CpfMae;
                dtNascimentoPaiConjuge1.Value = casamento.Conjuge1.DataNascimentoPai;
                dtNascimentoMaeConjuge1.Value = casamento.Conjuge1.DataNascimentoMae;

                txtNomeConjuge2.Text = casamento.Conjuge2.Nome;
                txtCpfConjuge2.Text = casamento.Conjuge2.CPF;
                txtNomePaiConjuge2.Text = casamento.Conjuge2.NomePai;
                txtCpfPaiConjuge2.Text = casamento.Conjuge2.CpfPai;
                txtNomeMaeConjuge2.Text = casamento.Conjuge2.NomeMae;
                txtCpfMaeConjuge2.Text = casamento.Conjuge2.CpfMae;
                dtNascimentoPaiConjuge2.Value = casamento.Conjuge2.DataNascimentoPai;
                dtNascimentoMaeConjuge2.Value = casamento.Conjuge2.DataNascimentoMae;

                dtDataCasamento.Value = casamento.DataCasamento;
                dtDataRegistro.Value = casamento.DataRegistro;
                AtualizarBotoes();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

