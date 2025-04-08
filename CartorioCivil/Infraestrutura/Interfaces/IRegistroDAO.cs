using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartorioCivil.Infraestrutura.Interfaces
{
    public interface IRegistroDAO<T>
    {
        Task AdicionarAsync(T entidade);
        Task RemoverAsync(int id);
        Task AtualizarAsync(T entidade);
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int id);
    }
}
