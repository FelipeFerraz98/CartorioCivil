using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartorioCivil.Entidades;

namespace CartorioCivil.Infraestrutura.Interfaces
{
    public interface INascimentoDAO : IRegistroDAO<Nascimento>
    {
        Task<List<Nascimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<List<Nascimento>> ObterPorNomeAsync(string nome);
    }
}
