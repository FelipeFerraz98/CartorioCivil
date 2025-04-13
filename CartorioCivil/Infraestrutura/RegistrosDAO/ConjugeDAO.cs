using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Infraestrutura.BancoDeDados;
using System.Linq;

namespace CartorioCivil.Infraestrutura.RegistrosDAO
{
    public class ConjugeDAO : IConjugeDAO
    {
        private readonly ConexaoDB _conexaoBanco;

        public ConjugeDAO() => _conexaoBanco = new ConexaoDB();

        public async Task<int> AdicionarAsync(Conjuge conjuge)
        {
            string consulta = @"
                INSERT INTO Conjuge (Nome, CPF, NomePai, NomeMae, DataNascimentoPai, DataNascimentoMae, CpfPai, CpfMae)
                VALUES (@Nome, @CPF, @NomePai, @NomeMae, @DataNascimentoPai, @DataNascimentoMae, @CpfPai, @CpfMae)
                RETURNING Id"; 

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", conjuge.Nome },
                { "@CPF", conjuge.CPF },
                { "@NomePai", conjuge.NomePai },
                { "@NomeMae", conjuge.NomeMae },
                { "@DataNascimentoPai", conjuge.DataNascimentoPai },
                { "@DataNascimentoMae", conjuge.DataNascimentoMae },
                { "@CpfPai", conjuge.CpfPai },
                { "@CpfMae", conjuge.CpfMae }
            };

            return await _conexaoBanco.ExecutarComandoComRetornoAsync<int>(consulta, parametros);
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
                    CpfPai = @CpfPai,
                    CpfMae = @CpfMae
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
                { "@CpfPai", conjuge.CpfPai },
                { "@CpfMae", conjuge.CpfMae }
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
                CpfPai = leitor.GetString(leitor.GetOrdinal("CpfPai")),
                CpfMae = leitor.GetString(leitor.GetOrdinal("CpfMae"))
            };
        }

        public async Task<List<Conjuge>> ObterPorNomeAsync(string nome)
        {
            string consulta = @"
                SELECT * FROM Conjuge 
                WHERE Nome = @Nome";

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", nome }
            };

            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
        }

        public async Task<Conjuge> ObterPorCpfAsync(string cpf)
        {
            string consulta = @"
                SELECT * FROM Conjuge 
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
