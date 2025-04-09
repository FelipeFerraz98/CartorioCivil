using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Infraestrutura.BancoDeDados;
using System.Linq;

namespace CartorioCivil.Infraestrutura.RegristrosDAO
{
    public class ObitoDAO : IRegistroDAO<Obito>
    {
        private readonly ConexaoDB _conexaoBanco;

        public ObitoDAO()
        {
            _conexaoBanco = new ConexaoDB();
        }

        public async Task AdicionarAsync(Obito obito)
        {
            string consulta = @"
                INSERT INTO Obito (DataRegistro, DataObito, NomeFalecido, DataNascimento, NomePai, NomeMae, DataNascimentoPai, DataNascimentoMae)
                VALUES (@DataRegistro, @DataObito, @NomeFalecido, @DataNascimento, @NomePai, @NomeMae, @DataNascimentoPai, @DataNascimentoMae)";

            var parametros = new Dictionary<string, object>
            {
                { "@DataRegistro", obito.DataRegistro },
                { "@DataObito", obito.DataObito },
                { "@NomeFalecido", obito.NomeFalecido },
                { "@DataNascimento", obito.DataNascimento },
                { "@NomePai", obito.NomePai },
                { "@NomeMae", obito.NomeMae },
                { "@DataNascimentoPai", obito.DataNascimentoPai },
                { "@DataNascimentoMae", obito.DataNascimentoMae }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task AtualizarAsync(Obito obito)
        {
            string consulta = @"
                UPDATE Obito
                SET DataRegistro = @DataRegistro, 
                    DataObito = @DataObito, 
                    NomeFalecido = @NomeFalecido,
                    DataNascimento = @DataNascimento,
                    NomePai = @NomePai,
                    NomeMae = @NomeMae,
                    DataNascimentoPai = @DataNascimentoPai,
                    DataNascimentoMae = @DataNascimentoMae
                WHERE Id = @Id";

            var parametros = new Dictionary<string, object>
            {
                { "@Id", obito.Id },
                { "@DataRegistro", obito.DataRegistro },
                { "@DataObito", obito.DataObito },
                { "@NomeFalecido", obito.NomeFalecido },
                { "@DataNascimento", obito.DataNascimento },
                { "@NomePai", obito.NomePai },
                { "@NomeMae", obito.NomeMae },
                { "@DataNascimentoPai", obito.DataNascimentoPai },
                { "@DataNascimentoMae", obito.DataNascimentoMae }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task RemoverAsync(int id)
        {
            string consulta = "DELETE FROM Obito WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task<List<Obito>> ObterTodosAsync()
        {
            string consulta = "SELECT * FROM Obito";
            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros);
        }

        public async Task<Obito> ObterPorIdAsync(int id)
        {
            string consulta = "SELECT * FROM Obito WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }

        public Obito MapearParametros(NpgsqlDataReader leitor)
        {
            return new Obito
            {
                Id = leitor.GetInt32(leitor.GetOrdinal("Id")),
                DataRegistro = leitor.GetDateTime(leitor.GetOrdinal("DataRegistro")),
                DataObito = leitor.GetDateTime(leitor.GetOrdinal("DataObito")),
                NomeFalecido = leitor.GetString(leitor.GetOrdinal("NomeFalecido")),
                DataNascimento = leitor.GetDateTime(leitor.GetOrdinal("DataNascimento")),
                NomePai = leitor.GetString(leitor.GetOrdinal("NomePai")),
                NomeMae = leitor.GetString(leitor.GetOrdinal("NomeMae")),
                DataNascimentoPai = leitor.GetDateTime(leitor.GetOrdinal("DataNascimentoPai")),
                DataNascimentoMae = leitor.GetDateTime(leitor.GetOrdinal("DataNascimentoMae"))
            };
        }
    }
}
