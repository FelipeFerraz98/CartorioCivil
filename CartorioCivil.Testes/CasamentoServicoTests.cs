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
        private Mock<IConjugueDAO> _mockConjugueDAO;

        [SetUp]
        public void Setup()
        {
            // Criando mocks do ICasamentoDAO e IConjugueDAO
            _mockCasamentoDAO = new Mock<ICasamentoDAO>();
            _mockConjugueDAO = new Mock<IConjugueDAO>();

            // Inicializando o serviço com os mocks
            _casamentoServico = new CasamentoServico(_mockCasamentoDAO.Object, _mockConjugueDAO.Object);
        }

        #region Testes para AdicionarAsync (Adição de Casamento e Conjugues)

        [Test]
        public async Task AdicionarAsync_CasamentoValido_DeveAdicionarComSucesso()
        {
            // Arrange: Preparando os dados de entrada e mocks
            var conjugue1 = new Conjugue
            {
                Nome = "Ana Silva",
                CPF = "425.493.080-18", 
                NomePai = "Carlos Silva",
                NomeMae = "Maria Silva",
                DataNascimentoPai = new DateTime(1950, 5, 10), 
                DataNascimentoMae = new DateTime(1955, 8, 20), 
                CpfnPai = "123.456.789-00", 
                CpfnMae = "987.654.321-11" 
            };


            var conjugue2 = new Conjugue
            {
                Nome = "João Pereira",
                CPF = "256.109.870-24", 
                NomePai = "Ricardo Pereira",
                NomeMae = "Lucia Pereira",
                DataNascimentoPai = new DateTime(1952, 3, 14), 
                DataNascimentoMae = new DateTime(1957, 9, 18), 
                CpfnPai = "321.654.987-00", 
                CpfnMae = "654.987.123-11"
            };


            var casamento = new Casamento
            {
                DataRegistro = DateTime.Today,
                DataCasamento = DateTime.Today.AddDays(-1)
            };

            _mockConjugueDAO.Setup(dao => dao.AdicionarAsync(conjugue1)).ReturnsAsync(1);
            _mockConjugueDAO.Setup(dao => dao.AdicionarAsync(conjugue2)).ReturnsAsync(2);
            _mockCasamentoDAO.Setup(dao => dao.AdicionarAsync(It.IsAny<Casamento>())).ReturnsAsync(1);

            // Act: Chamando o método que estamos testando
            var resultado = await _casamentoServico.AdicionarAsync(casamento, conjugue1, conjugue2);

            // Assert: Verificando se o resultado é o esperado
            Assert.AreEqual(1, resultado); 
            _mockConjugueDAO.Verify(dao => dao.AdicionarAsync(conjugue1), Times.Once);
            _mockConjugueDAO.Verify(dao => dao.AdicionarAsync(conjugue2), Times.Once);
            _mockCasamentoDAO.Verify(dao => dao.AdicionarAsync(It.IsAny<Casamento>()), Times.Once);
        }

        [Test]
        public void AdicionarAsync_CasamentoComErro_DeveLancarExcecao()
        {
            // Arrange: Preparando os dados de entrada com dados inválidos
            var conjugue1 = new Conjugue
            {
                Id = 1,
                Nome = "Ana Silva",
                CPF = "425.493.080-18", 
                NomePai = "Carlos Silva",
                NomeMae = "Maria Silva",
                DataNascimentoPai = new DateTime(1950, 5, 10), 
                DataNascimentoMae = new DateTime(1955, 8, 20), 
                CpfnPai = "123.456.789-00", 
                CpfnMae = "987.654.321-11" 
            };


            var conjugue2 = new Conjugue
            {
                Id = 2,
                Nome = "João Pereira",
                CPF = "256.109.870-24", 
                NomePai = "Ricardo Pereira",
                NomeMae = "Lucia Pereira",
                DataNascimentoPai = new DateTime(1952, 3, 14),
                DataNascimentoMae = new DateTime(1957, 9, 18), 
                CpfnPai = "321.654.987-00", 
                CpfnMae = "654.987.123-11"
            };

            var casamento = new Casamento
            {
                DataRegistro = DateTime.Today,
                DataCasamento = DateTime.Today.AddDays(1) // Data do casamento no futuro
            };

            // Act & Assert: Verificando se a exceção será lançada devido a data inválida
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _casamentoServico.AdicionarAsync(casamento, conjugue1, conjugue2));
            Assert.That(ex.Message, Is.EqualTo("A data do casamento não pode ser no futuro."));
        }

        #endregion

        #region Testes para ObterConjuguePorCpfAsync

        [Test]
        public async Task ObterConjuguePorCpfAsync_CpfValido_DeveRetornarConjugue()
        {
            // Arrange: Preparando os dados de entrada e mock
            var conjugue = new Conjugue
            {
                Id = 1,
                Nome = "Ana Silva",
                CPF = "425.493.080-18",
                NomePai = "Carlos Silva",
                NomeMae = "Maria Silva",
                DataNascimentoPai = new DateTime(1950, 5, 10),
                DataNascimentoMae = new DateTime(1955, 8, 20),
                CpfnPai = "123.456.789-00",
                CpfnMae = "987.654.321-11"
            };

            _mockConjugueDAO.Setup(dao => dao.ObterPorCpfAsync("425.493.080-18")).ReturnsAsync(conjugue);

            // Act: Chamando o método que estamos testando
            var resultado = await _casamentoServico.ObterConjuguePorCpfAsync("425.493.080-18");

            Assert.AreEqual("Ana Silva", resultado.Nome); 
            Assert.AreEqual("425.493.080-18", resultado.CPF); 
        }

        [Test]
        public void ObterConjuguePorCpfAsync_CpfInvalido_DeveLancarExcecao()
        {
            // Arrange: CPF inválido
            var cpfInvalido = "123.456.789-00";

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _casamentoServico.ObterConjuguePorCpfAsync(cpfInvalido));
            Assert.That(ex.Message, Is.EqualTo("O CPF fornecido é inválido."));
        }

        #endregion

        #region Testes para ObterConjuguePorNomeAsync

        [Test]
        public async Task ObterConjuguePorNomeAsync_ConjugueExistente_DeveRetornarConjugue()
        {
            // Arrange: Preparando os dados de entrada e mock
            var conjugue = new Conjugue
            {
                Id = 1,
                Nome = "Ana Silva",
                CPF = "425.493.080-18" 
            };

            _mockConjugueDAO.Setup(dao => dao.ObterPorNomeAsync("Ana Silva")).ReturnsAsync(new List<Conjugue> { conjugue });

            // Act: Chamando o método que estamos testando
            var resultado = await _casamentoServico.ObterConjuguePorNomeAsync("Ana Silva");

            // Assert
            Assert.AreEqual(1, resultado.Count); 
            Assert.AreEqual("Ana Silva", resultado[0].Nome); 
        }

        [Test]
        public void ObterConjuguePorNomeAsync_NomeVazio_DeveLancarExcecao()
        {
            // Act & Assert: Verificando se a exceção será lançada
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _casamentoServico.ObterConjuguePorNomeAsync(""));
            Assert.That(ex.Message, Is.EqualTo("O nome do cônjuge não pode ser vazio."));
        }

        [Test]
        public void ObterConjuguePorNomeAsync_ConjugueNaoEncontrado_DeveLancarExcecao()
        {
            // Arrange
            var mockCasamentoDAO = new Mock<ICasamentoDAO>();
            var mockConjugueDAO = new Mock<IConjugueDAO>();

            mockConjugueDAO
                .Setup(dao => dao.ObterPorNomeAsync("Ana Silva"))
                .ReturnsAsync((List<Conjugue>)null); 

            var casamentoServico = new CasamentoServico(mockCasamentoDAO.Object, mockConjugueDAO.Object);

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                await casamentoServico.ObterConjuguePorNomeAsync("Ana Silva"));

            Assert.That(ex.Message, Is.EqualTo("Cônjuge não encontrado."));
        }

        #endregion
    }
}
