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
    public class CasamentoServicoTests
    {
        private CasamentoServico _casamentoServico;
        private Mock<ICasamentoDAO> _mockCasamentoDAO;
        private Mock<IConjugeDAO> _mockConjugeDAO;

        [SetUp]
        public void Setup()
        {
            // Criando mocks do ICasamentoDAO e IConjugeDAO
            _mockCasamentoDAO = new Mock<ICasamentoDAO>();
            _mockConjugeDAO = new Mock<IConjugeDAO>();

            // Inicializando o serviço com os mocks
            _casamentoServico = new CasamentoServico(_mockCasamentoDAO.Object, _mockConjugeDAO.Object);
        }

        #region Testes para AdicionarAsync (Adição de Casamento e Conjuges)

        [Test]
        public async Task AdicionarAsync_CasamentoValido_DeveAdicionarComSucesso()
        {
            // Arrange: Preparando os dados de entrada e mocks
            var conjuge1 = new Conjuge
            {
                Nome = "Ana Silva",
                CPF = "425.493.080-18", 
                NomePai = "Carlos Silva",
                NomeMae = "Maria Silva",
                DataNascimentoPai = new DateTime(1950, 5, 10), 
                DataNascimentoMae = new DateTime(1955, 8, 20), 
                CpfPai = "123.456.789-00", 
                CpfMae = "987.654.321-11" 
            };


            var conjuge2 = new Conjuge
            {
                Nome = "João Pereira",
                CPF = "256.109.870-24", 
                NomePai = "Ricardo Pereira",
                NomeMae = "Lucia Pereira",
                DataNascimentoPai = new DateTime(1952, 3, 14), 
                DataNascimentoMae = new DateTime(1957, 9, 18), 
                CpfPai = "321.654.987-00", 
                CpfMae = "654.987.123-11"
            };


            var casamento = new Casamento
            {
                DataRegistro = DateTime.Today,
                DataCasamento = DateTime.Today.AddDays(-1)
            };

            _mockConjugeDAO.Setup(dao => dao.AdicionarAsync(conjuge1)).ReturnsAsync(1);
            _mockConjugeDAO.Setup(dao => dao.AdicionarAsync(conjuge2)).ReturnsAsync(2);
            _mockCasamentoDAO.Setup(dao => dao.AdicionarAsync(It.IsAny<Casamento>())).ReturnsAsync(1);

            // Act: Chamando o método que estamos testando
            var resultado = await _casamentoServico.AdicionarAsync(casamento, conjuge1, conjuge2);

            // Assert: Verificando se o resultado é o esperado
            Assert.AreEqual(1, resultado); 
            _mockConjugeDAO.Verify(dao => dao.AdicionarAsync(conjuge1), Times.Once);
            _mockConjugeDAO.Verify(dao => dao.AdicionarAsync(conjuge2), Times.Once);
            _mockCasamentoDAO.Verify(dao => dao.AdicionarAsync(It.IsAny<Casamento>()), Times.Once);
        }

        [Test]
        public void AdicionarAsync_CasamentoComErro_DeveLancarExcecao()
        {
            // Arrange: Preparando os dados de entrada com dados inválidos
            var conjuge1 = new Conjuge
            {
                Id = 1,
                Nome = "Ana Silva",
                CPF = "425.493.080-18", 
                NomePai = "Carlos Silva",
                NomeMae = "Maria Silva",
                DataNascimentoPai = new DateTime(1950, 5, 10), 
                DataNascimentoMae = new DateTime(1955, 8, 20), 
                CpfPai = "123.456.789-00", 
                CpfMae = "987.654.321-11" 
            };


            var conjuge2 = new Conjuge
            {
                Id = 2,
                Nome = "João Pereira",
                CPF = "256.109.870-24", 
                NomePai = "Ricardo Pereira",
                NomeMae = "Lucia Pereira",
                DataNascimentoPai = new DateTime(1952, 3, 14),
                DataNascimentoMae = new DateTime(1957, 9, 18), 
                CpfPai = "321.654.987-00", 
                CpfMae = "654.987.123-11"
            };

            var casamento = new Casamento
            {
                DataRegistro = DateTime.Today,
                DataCasamento = DateTime.Today.AddDays(1) // Data do casamento no futuro
            };

            // Act & Assert: Verificando se a exceção será lançada devido a data inválida
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _casamentoServico.AdicionarAsync(casamento, conjuge1, conjuge2));
            Assert.That(ex.Message, Is.EqualTo("A data do casamento não pode ser no futuro."));
        }

        #endregion

        #region Testes para ObterConjugePorCpfAsync

        [Test]
        public async Task ObterConjugePorCpfAsync_CpfValido_DeveRetornarConjuge()
        {
            // Arrange: Preparando os dados de entrada e mock
            var conjuge = new Conjuge
            {
                Id = 1,
                Nome = "Ana Silva",
                CPF = "425.493.080-18",
                NomePai = "Carlos Silva",
                NomeMae = "Maria Silva",
                DataNascimentoPai = new DateTime(1950, 5, 10),
                DataNascimentoMae = new DateTime(1955, 8, 20),
                CpfPai = "123.456.789-00",
                CpfMae = "987.654.321-11"
            };

            _mockConjugeDAO.Setup(dao => dao.ObterPorCpfAsync("425.493.080-18")).ReturnsAsync(conjuge);

            // Act: Chamando o método que estamos testando
            var resultado = await _casamentoServico.ObterConjugePorCpfAsync("425.493.080-18");

            Assert.AreEqual("Ana Silva", resultado.Nome); 
            Assert.AreEqual("425.493.080-18", resultado.CPF); 
        }

        [Test]
        public void ObterConjugePorCpfAsync_CpfInvalido_DeveLancarExcecao()
        {
            // Arrange: CPF inválido
            var cpfInvalido = "123.456.789-00";

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _casamentoServico.ObterConjugePorCpfAsync(cpfInvalido));
            Assert.That(ex.Message, Is.EqualTo("O CPF fornecido é inválido."));
        }

        #endregion

        #region Testes para ObterConjugePorNomeAsync

        [Test]
        public async Task ObterConjugePorNomeAsync_ConjugeExistente_DeveRetornarConjuge()
        {
            // Arrange: Preparando os dados de entrada e mock
            var conjuge = new Conjuge
            {
                Id = 1,
                Nome = "Ana Silva",
                CPF = "425.493.080-18" 
            };

            _mockConjugeDAO.Setup(dao => dao.ObterPorNomeAsync("Ana Silva")).ReturnsAsync(new List<Conjuge> { conjuge });

            // Act: Chamando o método que estamos testando
            var resultado = await _casamentoServico.ObterConjugePorNomeAsync("Ana Silva");

            // Assert
            Assert.AreEqual(1, resultado.Count); 
            Assert.AreEqual("Ana Silva", resultado[0].Nome); 
        }

        [Test]
        public void ObterConjugePorNomeAsync_NomeVazio_DeveLancarExcecao()
        {
            // Act & Assert: Verificando se a exceção será lançada
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _casamentoServico.ObterConjugePorNomeAsync(""));
            Assert.That(ex.Message, Is.EqualTo("O nome do cônjuge não pode ser vazio."));
        }

        [Test]
        public void ObterConjugePorNomeAsync_ConjugeNaoEncontrado_DeveLancarExcecao()
        {
            // Arrange
            var mockCasamentoDAO = new Mock<ICasamentoDAO>();
            var mockConjugeDAO = new Mock<IConjugeDAO>();

            mockConjugeDAO
                .Setup(dao => dao.ObterPorNomeAsync("Ana Silva"))
                .ReturnsAsync((List<Conjuge>)null); 

            var casamentoServico = new CasamentoServico(mockCasamentoDAO.Object, mockConjugeDAO.Object);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await casamentoServico.ObterConjugePorNomeAsync("Ana Silva"));

            Assert.That(ex.Message, Is.EqualTo("Cônjuge não encontrado."));
        }

        #endregion
    }
}
