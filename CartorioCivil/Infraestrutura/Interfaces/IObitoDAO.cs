using System.Collections.Generic;
using System.Threading.Tasks;
using CartorioCivil.Entidades;

namespace CartorioCivil.Infraestrutura.Interfaces
{
    public interface IObitoDAO : IRegistroDAO<Obito>
    {
        Task<List<Obito>> ObterPorNomeAsync(string nome);
    }
}
