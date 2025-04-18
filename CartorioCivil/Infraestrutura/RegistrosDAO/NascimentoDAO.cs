﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Infraestrutura.BancoDeDados;
using System.Linq;

namespace CartorioCivil.Infraestrutura.RegistrosDAO
{
    public class NascimentoDAO : INascimentoDAO
    {
        private readonly ConexaoDB _conexaoBanco;

        public NascimentoDAO() => _conexaoBanco = new ConexaoDB();

        public async Task<int> AdicionarAsync(Nascimento nascimento)
        {
            string consulta = @"
                INSERT INTO Nascimento (DataRegistro, DataNascimento, NomeRegistrado, NomePai, NomeMae, 
                                         DataNascimentoPai, DataNascimentoMae, CpfPai, CpfMae)
                VALUES (@DataRegistro, @DataNascimento, @NomeRegistrado, @NomePai, @NomeMae, 
                        @DataNascimentoPai, @DataNascimentoMae, @CpfPai, @CpfMae)
                        RETURNING Id";

            var parametros = new Dictionary<string, object>
            {
                { "@DataRegistro", nascimento.DataRegistro },
                { "@DataNascimento", nascimento.DataNascimento },
                { "@NomeRegistrado", nascimento.NomeRegistrado },
                { "@NomePai", nascimento.NomePai },
                { "@NomeMae", nascimento.NomeMae },
                { "@DataNascimentoPai", nascimento.DataNascimentoPai },
                { "@DataNascimentoMae", nascimento.DataNascimentoMae },
                { "@CpfPai", nascimento.CpfPai },
                { "@CpfMae", nascimento.CpfMae }
            };

            return await _conexaoBanco.ExecutarComandoComRetornoAsync<int>(consulta, parametros);
        }

        public async Task AtualizarAsync(Nascimento nascimento)
        {
            string consulta = @"
                UPDATE Nascimento
                SET DataRegistro = @DataRegistro, 
                    DataNascimento = @DataNascimento, 
                    NomeRegistrado = @NomeRegistrado, 
                    NomePai = @NomePai, 
                    NomeMae = @NomeMae, 
                    DataNascimentoPai = @DataNascimentoPai, 
                    DataNascimentoMae = @DataNascimentoMae, 
                    CpfPai = @CpfPai, 
                    CpfMae = @CpfMae
                WHERE Id = @Id";

            var parametros = new Dictionary<string, object>
            {
                { "@Id", nascimento.Id },
                { "@DataRegistro", nascimento.DataRegistro },
                { "@DataNascimento", nascimento.DataNascimento },
                { "@NomeRegistrado", nascimento.NomeRegistrado },
                { "@NomePai", nascimento.NomePai },
                { "@NomeMae", nascimento.NomeMae },
                { "@DataNascimentoPai", nascimento.DataNascimentoPai },
                { "@DataNascimentoMae", nascimento.DataNascimentoMae },
                { "@CpfPai", nascimento.CpfPai },
                { "@CpfMae", nascimento.CpfMae }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task RemoverAsync(int id)
        {
            string consulta = "DELETE FROM Nascimento WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            await _conexaoBanco.ExecutarComandoAsync(consulta, parametros);
        }

        public async Task<List<Nascimento>> ObterTodosAsync()
        {
            string consulta = "SELECT * FROM Nascimento";
            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros);
        }

        public async Task<Nascimento> ObterPorIdAsync(int id)
        {
            string consulta = "SELECT * FROM Nascimento WHERE Id = @Id";
            var parametros = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var resultados = await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
            return resultados.FirstOrDefault();
        }

        public Nascimento MapearParametros(NpgsqlDataReader leitor)
        {
            return new Nascimento
            {
                Id = leitor.GetInt32(leitor.GetOrdinal("Id")),
                DataRegistro = leitor.GetDateTime(leitor.GetOrdinal("DataRegistro")),
                DataNascimento = leitor.GetDateTime(leitor.GetOrdinal("DataNascimento")),
                NomeRegistrado = leitor.GetString(leitor.GetOrdinal("NomeRegistrado")),
                NomePai = leitor.GetString(leitor.GetOrdinal("NomePai")),
                NomeMae = leitor.GetString(leitor.GetOrdinal("NomeMae")),
                DataNascimentoPai = leitor.GetDateTime(leitor.GetOrdinal("DataNascimentoPai")),
                DataNascimentoMae = leitor.GetDateTime(leitor.GetOrdinal("DataNascimentoMae")),
                CpfPai = leitor.GetString(leitor.GetOrdinal("CpfPai")),
                CpfMae = leitor.GetString(leitor.GetOrdinal("CpfMae"))
            };
        }

        public async Task<List<Nascimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            string consulta = @"
                SELECT * FROM Nascimento
                WHERE DataNascimento BETWEEN @DataInicio AND @DataFim";

            var parametros = new Dictionary<string, object>
            {
                { "@DataInicio", dataInicio },
                { "@DataFim", dataFim }
            };

            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);
        }

        public async Task<List<Nascimento>> ObterPorNomeAsync(string nome)
        {
            string consulta = @"
                SELECT * FROM Nascimento 
                WHERE NomeRegistrado = @Nome";

            var parametros = new Dictionary<string, object>
            {
                { "@Nome", nome }
            };

            return await _conexaoBanco.ExecutarConsultaAsync(consulta, MapearParametros, parametros);

        }
    }
}
