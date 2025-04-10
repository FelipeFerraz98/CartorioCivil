using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.RegistrosDAO;
using CartorioCivil.Negocios.Validadores;

namespace CartorioCivil.Negocios.Servicos
{
    public class NascimentoServico : RegistroServicoBase<Nascimento>
    {
        private readonly NascimentoDAO _nascimentoDAO;

        public NascimentoServico() => _nascimentoDAO = new NascimentoDAO();

        public override async Task<int> AdicionarAsync(Nascimento nascimento, params object[] parametros)
        {
            ValidarEntidade.Validar(nascimento);
            ValidarRegrasDeData(nascimento);
            ValidarCPFs(nascimento);

            return await _nascimentoDAO.AdicionarAsync(nascimento);
        }

        public override async Task AtualizarAsync(Nascimento nascimento, params object[] parametros)
        {
            ValidarEntidade.Validar(nascimento);
            ValidarRegrasDeData(nascimento);
            ValidarCPFs(nascimento);

            await _nascimentoDAO.AtualizarAsync(nascimento);
        }

        public override async Task RemoverAsync(int id)
        {
            var nascimento = await _nascimentoDAO.ObterPorIdAsync(id);
            _ = nascimento ?? throw new ArgumentException("Nascimento não encontrado.");

            await _nascimentoDAO.RemoverAsync(id);
        }

        public override async Task<Nascimento> ObterPorIdAsync(int id) => await _nascimentoDAO.ObterPorIdAsync(id);

        public override async Task<List<Nascimento>> ObterTodosAsync() => await _nascimentoDAO.ObterTodosAsync();

        public async Task<List<Nascimento>> ObterPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            _ = (dataInicio != default && dataFim != default) ? true : throw new ArgumentException("Ambas as datas devem ser preenchidas.");


            if (dataInicio > dataFim)
            {
                throw new ArgumentException("A data de início não pode ser maior que a data de fim.");
            }

            return await _nascimentoDAO.ObterPorPeriodoAsync(dataInicio, dataFim);
        }


        public async Task<List<Nascimento>> ObterPorNomeAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do registrado não pode ser vazio.");

            return await _nascimentoDAO.ObterPorNomeAsync(nome);
        }

        private void ValidarRegrasDeData(Nascimento nascimento)
        {
            if (nascimento.DataRegistro > DateTime.Today)
                throw new ArgumentException("A data de registro não pode ser no futuro.");

            if (nascimento.DataNascimento > DateTime.Today)
                throw new ArgumentException("A data de nascimento não pode ser no futuro.");

            if (nascimento.DataRegistro < nascimento.DataNascimento)
                throw new ArgumentException("A data de registro não pode ser anterior à data de nascimento.");
        }

        private void ValidarCPFs(Nascimento nascimento)
        {
            if (!ValidarCPF.Validar(nascimento.CpfnPai))
                throw new ArgumentException("CPF do pai inválido.");

            if (!ValidarCPF.Validar(nascimento.CpfnMae))
                throw new ArgumentException("CPF da mãe inválido.");
        }
    }
}
