using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartorioCivil.Negocios.Servicos;

namespace CartorioCivil.Negocios.Relatorios
{
    public class RelNascimento
    {
        private readonly NascimentoServico _nascimentoServico;
        public RelNascimento() => _nascimentoServico = new NascimentoServico();

        public async Task<DataTable> GerarRelatorio(DateTime dataInicio, DateTime dataFinal)
        {
            var nascimentos = await _nascimentoServico.ObterPorPeriodoAsync(dataInicio, dataFinal);

            DataTable dt = new DataTable();

            dt.Columns.Add("NomeRegistrado", typeof(string));
            dt.Columns.Add("DataNascimento", typeof(string)); 
            dt.Columns.Add("DataRegistro", typeof(string));
            dt.Columns.Add("NomePai", typeof(string));
            dt.Columns.Add("CPFPai", typeof(string));
            dt.Columns.Add("DataNascimentoPai", typeof(string));
            dt.Columns.Add("NomeMae", typeof(string));
            dt.Columns.Add("CPFMae", typeof(string));
            dt.Columns.Add("DataNascimentoMae", typeof(string));

            foreach (var nascimento in nascimentos)
            {
                dt.Rows.Add(
                    nascimento.NomeRegistrado,
                    nascimento.DataNascimento.ToString("dd/MM/yyyy"),
                    nascimento.DataRegistro.ToString("dd/MM/yyyy"),
                    nascimento.NomePai,
                    nascimento.CpfPai,
                    nascimento.DataNascimentoPai.ToString("dd/MM/yyyy"),
                    nascimento.NomeMae,
                    nascimento.CpfMae,
                    nascimento.DataNascimentoMae.ToString("dd/MM/yyyy")
                );
            }

            return dt;

        }
    }
}
