using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.RegistrosDAO;
using CartorioCivil.Negocios.Validadores;

namespace CartorioCivil.Negocios.Servicos
{
    public class ObitoServico : RegistroServicoBase<Obito>
    {
        private readonly ObitoDAO _obitoDAO;

        public ObitoServico() => _obitoDAO = new ObitoDAO();

        public override async Task<int> AdicionarAsync(Obito obito, params object[] parametros)
        {
            ValidarEntidade.Validar(obito);
            ValidarRegrasDeData(obito);

            return await _obitoDAO.AdicionarAsync(obito);
        }

        public override async Task AtualizarAsync(Obito obito, params object[] parametros)
        {
            ValidarEntidade.Validar(obito);
            ValidarRegrasDeData(obito);

            await _obitoDAO.AtualizarAsync(obito);
        }

        public override async Task RemoverAsync(int id)
        {
            var obito = await _obitoDAO.ObterPorIdAsync(id);
            _ = obito ?? throw new ArgumentException("Óbito não encontrado.");

            await _obitoDAO.RemoverAsync(id);
        }

        public override async Task<Obito> ObterPorIdAsync(int id) => await _obitoDAO.ObterPorIdAsync(id);

        public override async Task<List<Obito>> ObterTodosAsync() => await _obitoDAO.ObterTodosAsync();

        public async Task<List<Obito>> ObterPorNomeAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do falecido não pode ser vazio.");

            return await _obitoDAO.ObterPorNomeAsync(nome);
        }
        private void ValidarRegrasDeData(Obito obito)
        {
            if (obito.DataRegistro > DateTime.Today)
                throw new ArgumentException("A data de registro não pode ser no futuro.");

            if (obito.DataObito > DateTime.Today)
                throw new ArgumentException("A data do óbito não pode ser no futuro.");

            if (obito.DataObito < obito.DataNascimento)
                throw new ArgumentException("A data do óbito não pode ser anterior à data de nascimento.");
        }
    }
}
