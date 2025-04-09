using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Infraestrutura.BancoDeDados;
using System.Linq;

namespace CartorioCivil.Infraestrutura.RegistrosDAO
{
    public class CasamentoDAO : ICasamentoDAO
    {
        private readonly ConexaoDB _conexaoBanco;

        public CasamentoDAO() => _conexaoBanco = new ConexaoDB();

        public async Task AdicionarAsync(Casamento casamento)
        {
            string consulta = @"
                INSERT INTO Casamento (DataRegistro, DataCasamento, IdConjuge1, IdConjuge2)
                VALUES (@DataRegistro, @DataCasamento, @IdConjuge1, @IdConjuge2)";

            var parametros = new Dictionary<string, object>
            {
                { "@DataRegistro", casamento.DataRegistro },
                { "@DataCasamento", casamento.DataCasamento },
                { "@IdConjuge1", casamento.IdConjuge1 },
                { "@IdConjuge2", casamento.IdConjuge2 }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task AtualizarAsync(Casamento casamento)
        {
            string consulta = @"
                UPDATE Casamento
                SET DataRegistro = @DataRegistro,
                    DataCasamento = @DataCasamento,
                    IdConjuge1 = @IdConjuge1,
                    IdConjuge2 = @IdConjuge2
                WHERE Id = @Id";

            var parametros = new Dictionary<string, object>
            {
                { "@Id", casamento.Id },
                { "@DataRegistro", casamento.DataRegistro },
                { "@DataCasamento", casamento.DataCasamento },
                { "@IdConjuge1", casamento.IdConjuge1 },
                { "@IdConjuge2", casamento.IdConjuge2 }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task RemoverAsync(int id)
        {
            string consulta = "DELETE FROM Casamento WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task<List<Casamento>> ObterTodosAsync()
        {
            string consulta = "SELECT * FROM Casamento";
            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros);
        }

        public async Task<Casamento> ObterPorIdAsync(int id)
        {
            string consulta = "SELECT * FROM Casamento WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }

        public Casamento MapearParametros(NpgsqlDataReader leitor)
        {
            return new Casamento
            {
                Id = leitor.GetInt32(leitor.GetOrdinal("Id")),
                DataRegistro = leitor.GetDateTime(leitor.GetOrdinal("DataRegistro")),
                DataCasamento = leitor.GetDateTime(leitor.GetOrdinal("DataCasamento")),
                IdConjuge1 = leitor.GetInt32(leitor.GetOrdinal("IdConjuge1")),
                IdConjuge2 = leitor.GetInt32(leitor.GetOrdinal("IdConjuge2"))
            };
        }

        public async Task<Casamento> ObterPorIdConjugueAsync(string idConjuge)
        {
                string consulta = @"
                    SELECT * FROM Casamento
                    WHERE IdConjuge1 = @IdConjuge
                       OR IdConjuge2 = @IdConjuge";

                var parametros = new Dictionary<string, object>
                {
                    { "@IdConjuge", idConjuge }
                };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }

    }
}
