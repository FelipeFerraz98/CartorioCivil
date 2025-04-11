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

        public async Task<int> AdicionarAsync(Casamento casamento)
        {
            string consulta = @"
                INSERT INTO Casamento (DataRegistro, DataCasamento, IdConjugue1, IdConjugue2)
                VALUES (@DataRegistro, @DataCasamento, @IdConjugue1, @IdConjugue2)
                RETURNING Id"; 

            var parametros = new Dictionary<string, object>
            {
                { "@DataRegistro", casamento.DataRegistro },
                { "@DataCasamento", casamento.DataCasamento },
                { "@IdConjugue1", casamento.IdConjugue1 },
                { "@IdConjugue2", casamento.IdConjugue2 }
            };

            return await _conexaoBanco.ExecutarComandoComRetornoAsync<int>(consulta, parametros);
        }


        public async Task AtualizarAsync(Casamento casamento)
        {
            string consulta = @"
                UPDATE Casamento
                SET DataRegistro = @DataRegistro,
                    DataCasamento = @DataCasamento,
                    IdConjugue1 = @IdConjugue1,
                    IdConjugue2 = @IdConjugue2
                WHERE Id = @Id";

            var parametros = new Dictionary<string, object>
            {
                { "@Id", casamento.Id },
                { "@DataRegistro", casamento.DataRegistro },
                { "@DataCasamento", casamento.DataCasamento },
                { "@IdConjugue1", casamento.IdConjugue1 },
                { "@IdConjugue2", casamento.IdConjugue2 }
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
                IdConjugue1 = leitor.GetInt32(leitor.GetOrdinal("IdConjugue1")),
                IdConjugue2 = leitor.GetInt32(leitor.GetOrdinal("IdConjugue2"))
            };
        }

        public async Task<Casamento> ObterPorIdConjugueAsync(int idConjugue)
        {
                string consulta = @"
                    SELECT * FROM Casamento
                    WHERE IdConjugue1 = @IdConjugue
                       OR IdConjugue2 = @IdConjugue";

                var parametros = new Dictionary<string, object>
                {
                    { "@IdConjugue", idConjugue }
                };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }

    }
}
