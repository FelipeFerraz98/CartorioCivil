using System.Threading.Tasks;
using CartorioCivil.Entidades;

namespace CartorioCivil.Infraestrutura.Interfaces
{
    public interface ICasamentoDAO : IRegistroDAO<Casamento>
    {
        Task<Casamento> ObterPorIdConjugeAsync(int idConjuge);
    }
}
