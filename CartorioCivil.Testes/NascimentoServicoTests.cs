using NUnit.Framework;
using Moq;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Negocios.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartorioCivil.Tests
{
    [TestFixture]
    public class NascimentoServicoTests
    {
        private NascimentoServico _nascimentoServico;
        private Mock<INascimentoDAO> _mockNascimentoDAO;

        [SetUp]
        public void Setup()
        {
            _mockNascimentoDAO = new Mock<INascimentoDAO>();
            _nascimentoServico = new NascimentoServico(_mockNascimentoDAO.Object);
        }

        [Test]
        public async Task AdicionarAsync_NascimentoValido_DeveAdicionarComSucesso()
        {
            var nascimento = new Nascimento
            {
                DataNascimento = DateTime.Today.AddYears(-5),
                DataRegistro = DateTime.Today,
                NomeRegistrado = "Lucas Oliveira",
                NomePai = "Carlos Oliveira",
                NomeMae = "Fernanda Silva",
                DataNascimentoPai = new DateTime(1980, 5, 10),
                DataNascimentoMae = new DateTime(1985, 8, 20),
                CpfnPai = "425.493.080-18",
                CpfnMae = "256.109.870-24"
            };

            _mockNascimentoDAO.Setup(dao => dao.AdicionarAsync(It.IsAny<Nascimento>())).ReturnsAsync(1);

            var resultado = await _nascimentoServico.AdicionarAsync(nascimento);

            Assert.AreEqual(1, resultado);
            _mockNascimentoDAO.Verify(dao => dao.AdicionarAsync(It.IsAny<Nascimento>()), Times.Once);
        }

        [Test]
        public void AdicionarAsync_DataNascimentoFutura_DeveLancarExcecao()
        {
            var nascimento = new Nascimento
            {
                DataNascimento = DateTime.Today.AddYears(-5),
                DataRegistro = DateTime.Today,
                NomeRegistrado = "Lucas Oliveira",
                NomePai = "Carlos Oliveira",
                NomeMae = "Fernanda Silva",
                DataNascimentoPai = new DateTime(1980, 5, 10),
                DataNascimentoMae = new DateTime(1985, 8, 20),
                CpfnPai = "425.493.080-18",
                CpfnMae = "256.109.870-24"
            };
            nascimento.DataNascimento = DateTime.Today.AddDays(1);

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _nascimentoServico.AdicionarAsync(nascimento));
            Assert.That(ex.Message, Is.EqualTo("A data de nascimento não pode ser no futuro."));
        }

        [Test]
        public void AdicionarAsync_CPFInvalidoPai_DeveLancarExcecao()
        {
            var nascimento = new Nascimento
            {
                DataNascimento = DateTime.Today.AddYears(-5),
                DataRegistro = DateTime.Today,
                NomeRegistrado = "Lucas Oliveira",
                NomePai = "Carlos Oliveira",
                NomeMae = "Fernanda Silva",
                DataNascimentoPai = new DateTime(1980, 5, 10),
                DataNascimentoMae = new DateTime(1985, 8, 20),
                CpfnPai = "123.456.789-00",
                CpfnMae = "256.109.870-24"
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _nascimentoServico.AdicionarAsync(nascimento));
            Assert.That(ex.Message, Is.EqualTo("CPF do pai inválido."));
        }

        [Test]
        public async Task ObterPorNomeAsync_NomeValido_DeveRetornarLista()
        {
            var nascimento = new Nascimento
            {
                DataNascimento = DateTime.Today.AddYears(-5),
                DataRegistro = DateTime.Today,
                NomeRegistrado = "Lucas Oliveira",
                NomePai = "Carlos Oliveira",
                NomeMae = "Fernanda Silva",
                DataNascimentoPai = new DateTime(1980, 5, 10),
                DataNascimentoMae = new DateTime(1985, 8, 20),
                CpfnPai = "123.456.789-00",
                CpfnMae = "256.109.870-24"
            };

            _mockNascimentoDAO.Setup(dao => dao.ObterPorNomeAsync(nascimento.NomeRegistrado))
                              .ReturnsAsync(new List<Nascimento> { nascimento });

            var resultado = await _nascimentoServico.ObterPorNomeAsync(nascimento.NomeRegistrado);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(nascimento.NomeRegistrado, resultado[0].NomeRegistrado);
        }

        [Test]
        public void ObterPorNomeAsync_NomeVazio_DeveLancarExcecao()
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _nascimentoServico.ObterPorNomeAsync(""));
            Assert.That(ex.Message, Is.EqualTo("O nome do registrado não pode ser vazio."));
        }

        [Test]
        public async Task ObterPorPeriodoAsync_PeriodoValido_DeveRetornarLista()
        {
            var dataInicio = new DateTime(2020, 1, 1);
            var dataFim = new DateTime(2021, 1, 1);
            var nascimento = new Nascimento
            {
                DataNascimento = DateTime.Today.AddYears(-5),
                DataRegistro = DateTime.Today,
                NomeRegistrado = "Lucas Oliveira",
                NomePai = "Carlos Oliveira",
                NomeMae = "Fernanda Silva",
                DataNascimentoPai = new DateTime(1980, 5, 10),
                DataNascimentoMae = new DateTime(1985, 8, 20),
                CpfnPai = "123.456.789-00",
                CpfnMae = "256.109.870-24"
            };

            _mockNascimentoDAO.Setup(dao => dao.ObterPorPeriodoAsync(dataInicio, dataFim))
                              .ReturnsAsync(new List<Nascimento> { nascimento });

            var resultado = await _nascimentoServico.ObterPorPeriodoAsync(dataInicio, dataFim);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Count);
        }

        [Test]
        public void ObterPorPeriodoAsync_DataInicioMaiorQueFim_DeveLancarExcecao()
        {
            var dataInicio = new DateTime(2022, 1, 1);
            var dataFim = new DateTime(2021, 1, 1);

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _nascimentoServico.ObterPorPeriodoAsync(dataInicio, dataFim));
            Assert.That(ex.Message, Is.EqualTo("A data de início não pode ser maior que a data de fim."));
        }
    }
}
