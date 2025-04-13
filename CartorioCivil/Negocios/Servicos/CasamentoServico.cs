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
        private readonly IConjugeDAO _conjugeDAO;

        public CasamentoServico()
        {
            _casamentoDAO = new CasamentoDAO();
            _conjugeDAO = new ConjugeDAO();
        }

        public CasamentoServico(ICasamentoDAO casamentoDAO, IConjugeDAO conjugeDAO)
        {
            _casamentoDAO = casamentoDAO;
            _conjugeDAO = conjugeDAO;
        }
        public override async Task<int> AdicionarAsync(Casamento casamento, params object[] parametros)
        {
            if (parametros == null || parametros.Length != 2)
                throw new ArgumentException("São necessários dois parâmetros do tipo Conjuge.");

            Conjuge conjuge1 = parametros[0] as Conjuge;
            Conjuge conjuge2 = parametros[1] as Conjuge;

            ValidarConjuges(conjuge1, conjuge2);
            ValidarCpfs(conjuge1, conjuge2);

            if (casamento.DataCasamento > DateTime.Today)
                throw new ArgumentException("A data do casamento não pode ser no futuro.");

            conjuge1.Id = await _conjugeDAO.AdicionarAsync(conjuge1);
            conjuge2.Id = await _conjugeDAO.AdicionarAsync(conjuge2);

            casamento.IdConjuge1 = conjuge1.Id;
            casamento.IdConjuge2 = conjuge2.Id;

            return await _casamentoDAO.AdicionarAsync(casamento);
        }

        public override async Task AtualizarAsync(Casamento casamento, params object[] parametros)
        {
            if (parametros == null || parametros.Length != 2)
                throw new ArgumentException("São necessários dois parâmetros do tipo Conjuge.");

            Conjuge conjuge1 = parametros[0] as Conjuge;
            Conjuge conjuge2 = parametros[1] as Conjuge;

            ValidarConjuges( conjuge1, conjuge2);
            ValidarCpfs(conjuge1, conjuge2);  

            if (casamento.DataCasamento > DateTime.Today)
                throw new ArgumentException("A data do casamento não pode ser no futuro.");

            await _conjugeDAO.AtualizarAsync(conjuge1);
            await _conjugeDAO.AtualizarAsync(conjuge2);

            await _casamentoDAO.AtualizarAsync(casamento);
        }

        public override async Task RemoverAsync(int idCasamento)
        {
            var casamento = await _casamentoDAO.ObterPorIdAsync(idCasamento);
            _ = casamento ??throw new ArgumentException("Casamento não encontrado.");

            await _casamentoDAO.RemoverAsync(idCasamento);

            await _conjugeDAO.RemoverAsync(casamento.IdConjuge1);
            await _conjugeDAO.RemoverAsync(casamento.IdConjuge2);
        }

        public async Task<Casamento> ObterCasamentoPorConjugeAsync(int idConjuge)
        {
            var casamento = await _casamentoDAO.ObterPorIdConjugeAsync(idConjuge);
            if (casamento != null)
            {
                var conjuge1 = await _conjugeDAO.ObterPorIdAsync(casamento.IdConjuge1);
                var conjuge2 = await _conjugeDAO.ObterPorIdAsync(casamento.IdConjuge2);

                casamento.Conjuge1 = conjuge1;
                casamento.Conjuge2 = conjuge2;
            }

            return casamento;
        }

        public override async Task<List<Casamento>> ObterTodosAsync()
        {
            var casamentos = await _casamentoDAO.ObterTodosAsync();
            foreach (var casamento in casamentos)
            {
                casamento.Conjuge1 = await _conjugeDAO.ObterPorIdAsync(casamento.IdConjuge1);
                casamento.Conjuge2 = await _conjugeDAO.ObterPorIdAsync(casamento.IdConjuge2);
            }

            return casamentos;
        }

        public async Task<List<Conjuge>> ObterConjugePorNomeAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do cônjuge não pode ser vazio.");

            var conjuge = await _conjugeDAO.ObterPorNomeAsync(nome);

            _ = conjuge ?? throw new ArgumentException("Cônjuge não encontrado.");

            return conjuge;
        }

        public async Task<Conjuge> ObterConjugePorCpfAsync(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("O CPF do cônjuge não pode ser vazio.");

            if (!ValidarCPF.Validar(cpf))
                throw new ArgumentException("O CPF fornecido é inválido.");

            var conjuge = await _conjugeDAO.ObterPorCpfAsync(cpf);

            _ = conjuge ?? throw new ArgumentException("Cônjuge não encontrado.");

            return conjuge;
        }


        private void ValidarConjuges( Conjuge conjuge1, Conjuge conjuge2)
        {
            ValidarEntidade.Validar(conjuge1);
            ValidarEntidade.Validar(conjuge2);
        }
        private void ValidarCpfs(Conjuge conjuge1, Conjuge conjuge2)
        {
            if (!ValidarCPF.Validar(conjuge1.CPF))
                throw new ArgumentException("O CPFs do Conjuge1 é inválido.");

            if (!ValidarCPF.Validar(conjuge2.CPF))
                throw new ArgumentException("O CPFs do Conjuge2 é inválido.");
        }
    }
}
