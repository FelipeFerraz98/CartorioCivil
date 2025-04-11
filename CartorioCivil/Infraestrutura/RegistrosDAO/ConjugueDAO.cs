using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Infraestrutura.BancoDeDados;
using System.Linq;

namespace CartorioCivil.Infraestrutura.RegistrosDAO
{
    public class ConjugueDAO : IConjugueDAO
    {
        private readonly ConexaoDB _conexaoBanco;

        public ConjugueDAO() => _conexaoBanco = new ConexaoDB();

        public async Task<int> AdicionarAsync(Conjugue conjugue)
        {
            string consulta = @"
                INSERT INTO Conjugue (Nome, CPF, NomePai, NomeMae, DataNascimentoPai, DataNascimentoMae, CpfnPai, CpfnMae)
                VALUES (@Nome, @CPF, @NomePai, @NomeMae, @DataNascimentoPai, @DataNascimentoMae, @CpfnPai, @CpfnMae)
                RETURNING Id"; 

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", conjugue.Nome },
                { "@CPF", conjugue.CPF },
                { "@NomePai", conjugue.NomePai },
                { "@NomeMae", conjugue.NomeMae },
                { "@DataNascimentoPai", conjugue.DataNascimentoPai },
                { "@DataNascimentoMae", conjugue.DataNascimentoMae },
                { "@CpfnPai", conjugue.CpfnPai },
                { "@CpfnMae", conjugue.CpfnMae }
            };

            return await _conexaoBanco.ExecutarComandoComRetornoAsync<int>(consulta, parametros);
        }

        public async Task AtualizarAsync(Conjugue conjugue)
        {
            string consulta = @"
                UPDATE Conjugue
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
                { "@Id", conjugue.Id },
                { "@Nome", conjugue.Nome },
                { "@CPF", conjugue.CPF },
                { "@NomePai", conjugue.NomePai },
                { "@NomeMae", conjugue.NomeMae },
                { "@DataNascimentoPai", conjugue.DataNascimentoPai },
                { "@DataNascimentoMae", conjugue.DataNascimentoMae },
                { "@CpfnPai", conjugue.CpfnPai },
                { "@CpfnMae", conjugue.CpfnMae }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task RemoverAsync(int id)
        {
            string consulta = "DELETE FROM Conjugue WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task<List<Conjugue>> ObterTodosAsync()
        {
            string consulta = "SELECT * FROM Conjugue";
            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros);
        }

        public async Task<Conjugue> ObterPorIdAsync(int id)
        {
            string consulta = "SELECT * FROM Conjugue WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }

        public Conjugue MapearParametros(NpgsqlDataReader leitor)
        {
            return new Conjugue
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

        public async Task<List<Conjugue>> ObterPorNomeAsync(string nome)
        {
            string consulta = @"
                SELECT * FROM Conjugue 
                WHERE Nome = @Nome";

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", nome }
            };

            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
        }

        public async Task<Conjugue> ObterPorCpfAsync(string cpf)
        {
            string consulta = @"
                SELECT * FROM Conjugue 
                WHERE CPF = @CPF";

            var parametros = new Dictionary<string, object>
            {
                { "@CPF", cpf }
            };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }
    }
}
