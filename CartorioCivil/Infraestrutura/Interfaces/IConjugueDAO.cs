using System.Collections.Generic;
using System.Threading.Tasks;
using CartorioCivil.Entidades;

namespace CartorioCivil.Infraestrutura.Interfaces
{
    public interface IConjugueDAO : IRegistroDAO<Conjugue>
    {
        Task<List<Conjugue>> ObterPorNomeAsync(string nome);
        Task<Conjugue> ObterPorCpfAsync(string cpf);
    }
}
