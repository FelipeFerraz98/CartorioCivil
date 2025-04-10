using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;

namespace CartorioCivil.Infraestrutura.BancoDeDados
{
    public class ConexaoDB : IDisposable
    {
        private readonly string _stringDeConexao;
        private NpgsqlConnection _conexao;

        public ConexaoDB()
        {
            _stringDeConexao = ConfigurationManager.ConnectionStrings["PostgreSQLConexao"]?.ConnectionString
                               ?? throw new InvalidOperationException("String de conexão não encontrada.");
            _conexao = new NpgsqlConnection(_stringDeConexao);
        }

        public async Task AbrirConexaoAsync()
        {
            if (_conexao.State == ConnectionState.Closed)
            {
                await _conexao.OpenAsync();
            }
        }

        public void FecharConexao()
        {
            if (_conexao.State == ConnectionState.Open)
            {
                _conexao.Close();
            }
        }

        public async Task ExecutarComandoAsync(string consulta, Dictionary<string, object> parametros = null)
        {
            await AbrirConexaoAsync();

            using (var comando = new NpgsqlCommand(consulta, _conexao))
            {
                AdicionarParametros(comando, parametros);
                await comando.ExecuteNonQueryAsync();
            }
        }
        public async Task<T> ExecutarComandoComRetornoAsync<T>(string consulta, Dictionary<string, object> parametros = null)
        {
            await AbrirConexaoAsync();

            using (var comando = new NpgsqlCommand(consulta, _conexao))
            {
                AdicionarParametros(comando, parametros);

                var resultado = await comando.ExecuteScalarAsync();

                return resultado != DBNull.Value ? (T)Convert.ChangeType(resultado, typeof(T)) : default;
            }
        }


        public async Task<List<T>> ExecutarConsultaAsync<T>(string consulta, Func<NpgsqlDataReader, T> funcaoMapeamento, Dictionary<string, object> parametros = null)
        {
            await AbrirConexaoAsync();

            var resultado = new List<T>();
            using (var comando = new NpgsqlCommand(consulta, _conexao))
            {
                AdicionarParametros(comando, parametros);

                using (var leitor = await comando.ExecuteReaderAsync())
                {
                    while (await leitor.ReadAsync())
                    {
                        resultado.Add(funcaoMapeamento(leitor));
                    }
                }
            }

            return resultado;
        }

        private void AdicionarParametros(NpgsqlCommand comando, Dictionary<string, object> parametros)
        {
            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                }
            }
        }

        public void Dispose()
        {
            FecharConexao();
            _conexao?.Dispose();
        }
    }
}
