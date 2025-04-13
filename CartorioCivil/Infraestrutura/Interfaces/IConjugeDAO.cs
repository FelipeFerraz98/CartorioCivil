using System.Collections.Generic;
using System.Threading.Tasks;
using CartorioCivil.Entidades;

namespace CartorioCivil.Infraestrutura.Interfaces
{
    public interface IConjugeDAO : IRegistroDAO<Conjuge>
    {
        Task<List<Conjuge>> ObterPorNomeAsync(string nome);
        Task<Conjuge> ObterPorCpfAsync(string cpf);
    }
}
