using NUnit.Framework;
using Moq;
using CartorioCivil.Entidades;
using CartorioCivil.Infraestrutura.Interfaces;
using CartorioCivil.Negocios.Servicos;
using System;
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
        public void AdicionarAsync_ObitoComCamposObrigatoriosEmBranco_DeveLancarExcecao()
        {
            // Arrange: Objeto com um campo obrigatório faltando
            var obito = new Obito
            {
                DataObito = DateTime.Today.AddDays(-1),
                DataRegistro = DateTime.Today,
                DataNascimento = DateTime.Today.AddYears(-70),
                NomeFalecido = null, // Campo obrigatório
                NomePai = "Nome Pai",
                NomeMae = "Nome Mãe",
                DataNascimentoPai = DateTime.Today.AddYears(-80),
                DataNascimentoMae = DateTime.Today.AddYears(-75)
            };

            // Act & Assert: Verificando se a exceção será lançada
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _obitoServico.AdicionarAsync(obito));
            Assert.That(ex.Message, Is.EqualTo("O nome do falecido não pode ser vazio ou nulo."));
        }

        [Test]
        public async Task ObterPorIdAsync_ObitoExistente_DeveRetornarObito()
        {
            var obitoEsperado = new Obito
            {
                Id = 1,
                NomeFalecido = "Falecido Teste",
                DataNascimento = DateTime.Today.AddYears(-70),
                DataObito = DateTime.Today.AddDays(-1),
                DataRegistro = DateTime.Today
            };

            _mockObitoDAO.Setup(dao => dao.ObterPorIdAsync(1)).ReturnsAsync(obitoEsperado);

            var resultado = await _obitoServico.ObterPorIdAsync(1);

            Assert.NotNull(resultado);
            Assert.AreEqual(obitoEsperado.Id, resultado.Id);
            Assert.AreEqual(obitoEsperado.NomeFalecido, resultado.NomeFalecido);
            _mockObitoDAO.Verify(dao => dao.ObterPorIdAsync(1), Times.Once);
        }
    }
}
