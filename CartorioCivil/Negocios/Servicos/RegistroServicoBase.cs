using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartorioCivil.Negocios.Servicos
{
    public abstract class RegistroServicoBase<T>
    {
        /// <returns>Retorna o Id da entidade adicionada ao banco.</returns>
        public abstract Task<int> AdicionarAsync(T registro, params object[] parametros);
        public abstract Task AtualizarAsync(T registro, params object[] parametros);
        public virtual Task<T> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException("O método ObterPorIdAsync não está implementado para essa classe.");
        }
        public abstract Task<List<T>> ObterTodosAsync();
        public abstract Task RemoverAsync(int id);
    }
}
