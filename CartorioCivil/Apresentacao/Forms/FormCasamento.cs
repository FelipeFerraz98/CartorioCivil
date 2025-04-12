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
        private Conjugue _conjugue1;
        private Conjugue _conjugue2;
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
                    var conjugue = await _casamentoServico.ObterConjuguePorCpfAsync(entrada);
                    if (conjugue != null)
                    {
                        var casamento = await _casamentoServico.ObterCasamentoPorConjugueAsync(conjugue.Id);
                        if (casamento != null)
                            casamentosEncontrados.Add(casamento);
                    }
                }
                else
                {
                    var conjuges = await _casamentoServico.ObterConjuguePorNomeAsync(entrada);
                    foreach (var conjugue in conjuges)
                    {
                        var casamento = await _casamentoServico.ObterCasamentoPorConjugueAsync(conjugue.Id);
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
                var item = new ListViewItem(casamento.Conjugue1.Nome);
                item.SubItems.Add(casamento.Conjugue1.CPF);

                item.SubItems.Add(casamento.Conjugue2.Nome);
                item.SubItems.Add(casamento.Conjugue2.CPF);

                item.SubItems.Add(casamento.DataCasamento.ToShortDateString());
                item.SubItems.Add(casamento.DataRegistro.ToShortDateString());

                item.Tag = casamento;
                listViewResultados.Items.Add(item);
            }
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                _conjugue1 = ObterConjugue1();
                _conjugue2 = ObterConjugue2();

                Casamento casamento = new Casamento
                {
                    DataCasamento = dtDataCasamento.Value.Date,
                    DataRegistro = dtDataRegistro.Value.Date
                };

                int id = await _casamentoServico.AdicionarAsync(casamento, _conjugue1, _conjugue2);
                casamento.Id = id;
                _conjugue1.Id = casamento.IdConjugue1;
                _conjugue2.Id = casamento.IdConjugue2;
                casamento.Conjugue1 = _conjugue1;
                casamento.Conjugue2 = _conjugue2;

                _casamentoSelecionado = casamento;

                MessageBox.Show("Casamento adicionado com sucesso!");
                AtualizarBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_casamentoSelecionado == null) return;

                _casamentoSelecionado.DataCasamento = dtDataCasamento.Value.Date;
                _casamentoSelecionado.DataRegistro = dtDataRegistro.Value.Date;

                var conjugue1 = ObterConjugue1();
                var conjugue2 = ObterConjugue2();

                conjugue1.Id = _casamentoSelecionado.IdConjugue1;
                conjugue2.Id = _casamentoSelecionado.IdConjugue2;

                await _casamentoServico.AtualizarAsync(_casamentoSelecionado, conjugue1, conjugue2);
                MessageBox.Show("Casamento atualizado com sucesso!");
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

        private Conjugue ObterConjugue1() => new Conjugue
            {
                Nome = txtNomeConjugue1.Text.Trim(),
                CPF = txtCpfConjugue1.Text.Trim(),
                NomePai = txtNomePaiConjugue1.Text.Trim(),
                CpfnPai = txtCpfPaiConjugue1.Text.Trim(),
                NomeMae = txtNomeMaeConjugue1.Text.Trim(),
                CpfnMae = txtCpfMaeConjugue1.Text.Trim(),
                DataNascimentoPai = dtNascimentoPaiConjugue1.Value,
                DataNascimentoMae = dtNascimentoMaeConjugue1.Value
            };

        private Conjugue ObterConjugue2() => new Conjugue
            {
                Nome = txtNomeConjugue2.Text.Trim(),
                CPF = txtCpfConjugue2.Text.Trim(),
                NomePai = txtNomePaiConjugue2.Text.Trim(),
                CpfnPai = txtCpfPaiConjugue2.Text.Trim(),
                NomeMae = txtNomeMaeConjugue2.Text.Trim(),
                CpfnMae = txtCpfMaeConjugue2.Text.Trim(),
                DataNascimentoPai = dtNascimentoPaiConjugue2.Value,
                DataNascimentoMae = dtNascimentoMaeConjugue2.Value
            };

        private void LimparForm()
        {
            dtNascimentoPaiConjugue1.Value = DateTime.Today;
            dtNascimentoMaeConjugue1.Value = DateTime.Today;
            dtNascimentoPaiConjugue2.Value = DateTime.Today;
            dtNascimentoMaeConjugue2.Value = DateTime.Today;
            dtDataCasamento.Value = DateTime.Today;
            dtDataRegistro.Value = DateTime.Today;

            txtNomeConjugue2.Clear();
            txtCpfConjugue2.Clear();
            txtNomePaiConjugue2.Clear();
            txtCpfPaiConjugue2.Clear();
            txtNomeMaeConjugue2.Clear();
            txtCpfMaeConjugue2.Clear();

            txtNomeConjugue1.Clear();
            txtCpfConjugue1.Clear();
            txtNomePaiConjugue1.Clear();
            txtCpfPaiConjugue1.Clear();
            txtNomeMaeConjugue1.Clear();
            txtCpfMaeConjugue1.Clear();

            listViewResultados.Items.Clear();

            _casamentoSelecionado = null;
            _conjugue1 = null;
            _conjugue2 = null;
            AtualizarBotoes();
        }

        private void listViewResultados_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listViewResultados.SelectedItems.Count > 0)
            {
                var casamento = (Casamento)listViewResultados.SelectedItems[0].Tag;
                _casamentoSelecionado = casamento;

                txtNomeConjugue1.Text = casamento.Conjugue1.Nome;
                txtCpfConjugue1.Text = casamento.Conjugue1.CPF;
                txtNomePaiConjugue1.Text = casamento.Conjugue1.NomePai;
                txtCpfPaiConjugue1.Text = casamento.Conjugue1.CpfnPai;
                txtNomeMaeConjugue1.Text = casamento.Conjugue1.NomeMae;
                txtCpfMaeConjugue1.Text = casamento.Conjugue1.CpfnMae;
                dtNascimentoPaiConjugue1.Value = casamento.Conjugue1.DataNascimentoPai;
                dtNascimentoMaeConjugue1.Value = casamento.Conjugue1.DataNascimentoMae;

                txtNomeConjugue2.Text = casamento.Conjugue2.Nome;
                txtCpfConjugue2.Text = casamento.Conjugue2.CPF;
                txtNomePaiConjugue2.Text = casamento.Conjugue2.NomePai;
                txtCpfPaiConjugue2.Text = casamento.Conjugue2.CpfnPai;
                txtNomeMaeConjugue2.Text = casamento.Conjugue2.NomeMae;
                txtCpfMaeConjugue2.Text = casamento.Conjugue2.CpfnMae;
                dtNascimentoPaiConjugue2.Value = casamento.Conjugue2.DataNascimentoPai;
                dtNascimentoMaeConjugue2.Value = casamento.Conjugue2.DataNascimentoMae;

                dtDataCasamento.Value = casamento.DataCasamento;
                dtDataRegistro.Value = casamento.DataRegistro;
                AtualizarBotoes();
            }
        }

        private void btnLimpar_Click_1(object sender, EventArgs e) => LimparForm();

    }
}

