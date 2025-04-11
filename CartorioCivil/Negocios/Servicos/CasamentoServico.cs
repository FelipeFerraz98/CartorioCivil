using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Infraestrutura.RegistrosDAO;
using CartorioCivil.Negocios.Validadores;

namespace CartorioCivil.Negocios.Servicos
{
    public class CasamentoServico : RegistroServicoBase<Casamento>
    {
        private readonly ICasamentoDAO _casamentoDAO;
        private readonly IConjugueDAO _conjugueDAO;

        public CasamentoServico()
        {
            _casamentoDAO = new CasamentoDAO();
            _conjugueDAO = new ConjugueDAO();
        }

        public CasamentoServico(ICasamentoDAO casamentoDAO, IConjugueDAO conjugueDAO)
        {
            _casamentoDAO = casamentoDAO;
            _conjugueDAO = conjugueDAO;
        }
        public override async Task<int> AdicionarAsync(Casamento casamento, params object[] parametros)
        {
            if (parametros == null || parametros.Length != 2)
                throw new ArgumentException("São necessários dois parâmetros do tipo Conjugue.");

            Conjugue conjugue1 = parametros[0] as Conjugue;
            Conjugue conjugue2 = parametros[1] as Conjugue;

            ValidarConjugues(conjugue1, conjugue2);
            ValidarCpfs(conjugue1, conjugue2);

            if (casamento.DataCasamento > DateTime.Today)
                throw new ArgumentException("A data do casamento não pode ser no futuro.");

            conjugue1.Id = await _conjugueDAO.AdicionarAsync(conjugue1);
            conjugue2.Id = await _conjugueDAO.AdicionarAsync(conjugue2);

            casamento.IdConjugue1 = conjugue1.Id;
            casamento.IdConjugue2 = conjugue2.Id;

            return await _casamentoDAO.AdicionarAsync(casamento);
        }

        public override async Task AtualizarAsync(Casamento casamento, params object[] parametros)
        {
            if (parametros == null || parametros.Length != 2)
                throw new ArgumentException("São necessários dois parâmetros do tipo Conjugue.");

            Conjugue conjugue1 = parametros[0] as Conjugue;
            Conjugue conjugue2 = parametros[1] as Conjugue;

            ValidarConjugues( conjugue1, conjugue2);
            ValidarCpfs(conjugue1, conjugue2);  

            if (casamento.DataCasamento > DateTime.Today)
                throw new ArgumentException("A data do casamento não pode ser no futuro.");

            await _conjugueDAO.AtualizarAsync(conjugue1);
            await _conjugueDAO.AtualizarAsync(conjugue2);

            await _casamentoDAO.AtualizarAsync(casamento);
        }

        public override async Task RemoverAsync(int idCasamento)
        {
            var casamento = await _casamentoDAO.ObterPorIdAsync(idCasamento);
            _ = casamento ??throw new ArgumentException("Casamento não encontrado.");

            await _casamentoDAO.RemoverAsync(idCasamento);

            await _conjugueDAO.RemoverAsync(casamento.IdConjugue1);
            await _conjugueDAO.RemoverAsync(casamento.IdConjugue2);
        }

        public async Task<Casamento> ObterCasamentoPorConjugueAsync(int idConjugue)
        {
            var casamento = await _casamentoDAO.ObterPorIdConjugueAsync(idConjugue);
            if (casamento != null)
            {
                var conjugue1 = await _conjugueDAO.ObterPorIdAsync(casamento.IdConjugue1);
                var conjugue2 = await _conjugueDAO.ObterPorIdAsync(casamento.IdConjugue2);

                casamento.Conjugue1 = conjugue1;
                casamento.Conjugue2 = conjugue2;
            }

            return casamento;
        }

        public override async Task<List<Casamento>> ObterTodosAsync()
        {
            var casamentos = await _casamentoDAO.ObterTodosAsync();
            foreach (var casamento in casamentos)
            {
                casamento.Conjugue1 = await _conjugueDAO.ObterPorIdAsync(casamento.IdConjugue1);
                casamento.Conjugue2 = await _conjugueDAO.ObterPorIdAsync(casamento.IdConjugue2);
            }

            return casamentos;
        }

        public async Task<List<Conjugue>> ObterConjuguePorNomeAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do cônjuge não pode ser vazio.");

            var conjugue = await _conjugueDAO.ObterPorNomeAsync(nome);

            _ = conjugue ?? throw new ArgumentException("Cônjuge não encontrado.");

            return conjugue;
        }

        public async Task<Conjugue> ObterConjuguePorCpfAsync(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("O CPF do cônjuge não pode ser vazio.");

            if (!ValidarCPF.Validar(cpf))
                throw new ArgumentException("O CPF fornecido é inválido.");

            var conjugue = await _conjugueDAO.ObterPorCpfAsync(cpf);

            _ = conjugue ?? throw new ArgumentException("Cônjuge não encontrado.");

            return conjugue;
        }


        private void ValidarConjugues( Conjugue conjugue1, Conjugue conjugue2)
        {
            ValidarEntidade.Validar(conjugue1);
            ValidarEntidade.Validar(conjugue2);
        }
        private void ValidarCpfs(Conjugue conjugue1, Conjugue conjugue2)
        {
            if (!ValidarCPF.Validar(conjugue1.CPF))
                throw new ArgumentException("O CPFs do Conjugue1 é inválido.");

            if (!ValidarCPF.Validar(conjugue2.CPF))
                throw new ArgumentException("O CPFs do Conjugue2 é inválido.");
        }
    }
}
