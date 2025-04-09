using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Infraestrutura.BancoDeDados;
using System.Linq;

namespace CartorioCivil.Infraestrutura.RegristrosDAO
{
    public class ConjugeDAO : IRegistroDAO<Conjuge>
    {
        private readonly ConexaoDB _conexaoBanco;

        public ConjugeDAO()
        {
            _conexaoBanco = new ConexaoDB();
        }

        public async Task AdicionarAsync(Conjuge conjuge)
        {
            string consulta = @"
                INSERT INTO Conjuge (Nome, CPF, NomePai, NomeMae, DataNascimentoPai, DataNascimentoMae, CpfnPai, CpfnMae)
                VALUES (@Nome, @CPF, @NomePai, @NomeMae, @DataNascimentoPai, @DataNascimentoMae, @CpfnPai, @CpfnMae)";

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", conjuge.Nome },
                { "@CPF", conjuge.CPF },
                { "@NomePai", conjuge.NomePai },
                { "@NomeMae", conjuge.NomeMae },
                { "@DataNascimentoPai", conjuge.DataNascimentoPai },
                { "@DataNascimentoMae", conjuge.DataNascimentoMae },
                { "@CpfnPai", conjuge.CpfnPai },
                { "@CpfnMae", conjuge.CpfnMae }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task AtualizarAsync(Conjuge conjuge)
        {
            string consulta = @"
                UPDATE Conjuge
                SET Nome = @Nome,
                    CPF = @CPF,
                    NomePai = @NomePai,
                    NomeMae = @NomeMae,
                    DataNascimentoPai = @DataNascimentoPai,
                    DataNascimentoMae = @DataNascimentoMae,
                    CpfnPai = @CpfnPai,
                    CpfnMae = @CpfnMae
                WHERE Id = @Id";

            var parametros = new Dictionary<string, object>
            {
                { "@Id", conjuge.Id },
                { "@Nome", conjuge.Nome },
                { "@CPF", conjuge.CPF },
                { "@NomePai", conjuge.NomePai },
                { "@NomeMae", conjuge.NomeMae },
                { "@DataNascimentoPai", conjuge.DataNascimentoPai },
                { "@DataNascimentoMae", conjuge.DataNascimentoMae },
                { "@CpfnPai", conjuge.CpfnPai },
                { "@CpfnMae", conjuge.CpfnMae }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task RemoverAsync(int id)
        {
            string consulta = "DELETE FROM Conjuge WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task<List<Conjuge>> ObterTodosAsync()
        {
            string consulta = "SELECT * FROM Conjuge";
            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros);
        }

        public async Task<Conjuge> ObterPorIdAsync(int id)
        {
            string consulta = "SELECT * FROM Conjuge WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }

        public Conjuge MapearParametros(NpgsqlDataReader leitor)
        {
            return new Conjuge
            {
                Id = leitor.GetInt32(leitor.GetOrdinal("Id")),
                Nome = leitor.GetString(leitor.GetOrdinal("Nome")),
                CPF = leitor.GetString(leitor.GetOrdinal("CPF")),
                NomePai = leitor.GetString(leitor.GetOrdinal("NomePai")),
                NomeMae = leitor.GetString(leitor.GetOrdinal("NomeMae")),
                DataNascimentoPai = leitor.GetDateTime(leitor.GetOrdinal("DataNascimentoPai")),
                DataNascimentoMae = leitor.GetDateTime(leitor.GetOrdinal("DataNascimentoMae")),
                CpfnPai = leitor.GetString(leitor.GetOrdinal("CpfnPai")),
                CpfnMae = leitor.GetString(leitor.GetOrdinal("CpfnMae"))
            };
        }
    }
}
