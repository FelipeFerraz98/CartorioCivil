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
    public class ObitoServicoTests
    {
        private ObitoServico _obitoServico;
        private Mock<IObitoDAO> _mockObitoDAO;

        [SetUp]
        public void Setup()
        {
            _mockObitoDAO = new Mock<IObitoDAO>();
            _obitoServico = new ObitoServico(_mockObitoDAO.Object);
        }

        [Test]
        public async Task AdicionarAsync_ObitoValido_DeveAdicionarComSucesso()
        {
            // Arrange: Preparando os dados de entrada e mock
            var obito = new Obito
            {
                DataObito = DateTime.Today.AddDays(-1),
                DataRegistro = DateTime.Today,
                NomeFalecido = "João da Silva",
                DataNascimento = DateTime.Today.AddYears(-70),
                NomePai = "José da Silva",
                NomeMae = "Maria da Silva",
                DataNascimentoPai = DateTime.Today.AddYears(-100),
                DataNascimentoMae = DateTime.Today.AddYears(-98)
            };

            _mockObitoDAO.Setup(dao => dao.AdicionarAsync(It.IsAny<Obito>())).ReturnsAsync(1); 

            // Act: Chamando o método que estamos testando
            var resultado = await _obitoServico.AdicionarAsync(obito);

            // Assert: Verificando se o resultado é o esperado
            Assert.AreEqual(1, resultado); 
            _mockObitoDAO.Verify(dao => dao.AdicionarAsync(It.IsAny<Obito>()), Times.Once); 
        }

        [Test]
        public void AdicionarAsync_ObitoComErro_DeveLancarExcecao()
        {
            // Arrange: Preparando um óbito com dados inválidos (nome vazio)
            var obito = new Obito
            {
                DataObito = DateTime.Today.AddDays(-1),
                DataRegistro = DateTime.Today,
                NomeFalecido = "", // Nome do falecido vazio, o que deve gerar um erro
                DataNascimento = DateTime.Today.AddYears(-70),
                NomePai = "José da Silva",
                NomeMae = "Maria da Silva",
                DataNascimentoPai = DateTime.Today.AddYears(-100),
                DataNascimentoMae = DateTime.Today.AddYears(-98)
            };

            // Act & Assert: Verificando se a exceção será lançada
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _obitoServico.AdicionarAsync(obito));
            Assert.That(ex.Message, Is.EqualTo("O campo 'NomeFalecido' não pode ser vazio ou nulo."));
        }

        [Test]
        public async Task ObterPorIdAsync_ObitoExistente_DeveRetornarObito()
        {
            // Arrange: Preparando um óbito para ser retornado
            var obito = new Obito
            {
                Id = 1,
                NomeFalecido = "João da Silva",
                DataObito = DateTime.Today.AddDays(-1),
                DataRegistro = DateTime.Today,
                DataNascimento = DateTime.Today.AddYears(-70)
            };

            _mockObitoDAO.Setup(dao => dao.ObterPorIdAsync(1)).ReturnsAsync(obito); 

            // Act: Chamando o método que estamos testando
            var resultado = await _obitoServico.ObterPorIdAsync(1);

            // Assert: Verificando se o óbito retornado é o esperado
            Assert.AreEqual(obito.Id, resultado.Id); 
            Assert.AreEqual(obito.NomeFalecido, resultado.NomeFalecido); 
        }

        [Test]
        public async Task ObterPorNomeAsync_ObitoExistente_DeveRetornarObito()
        {
            // Arrange: Preparando um óbito para ser retornado
            var obito = new Obito
            {
                Id = 1,
                NomeFalecido = "João da Silva",
                DataObito = DateTime.Today.AddDays(-1),
                DataRegistro = DateTime.Today,
                DataNascimento = DateTime.Today.AddYears(-70)
            };

            var listaObitos = new List<Obito> { obito };

            _mockObitoDAO.Setup(dao => dao.ObterPorNomeAsync("João da Silva")).ReturnsAsync(listaObitos);

            // Act: Chamando o método que estamos testando
            var resultado = await _obitoServico.ObterPorNomeAsync("João da Silva");

            // Assert: Verificando se a lista de óbitos retornada é a esperada
            Assert.AreEqual(1, resultado.Count); 
            Assert.AreEqual(obito.NomeFalecido, resultado[0].NomeFalecido); 
        }

    }
}
