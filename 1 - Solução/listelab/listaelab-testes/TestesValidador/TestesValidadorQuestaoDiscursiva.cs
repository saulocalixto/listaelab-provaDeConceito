using listelab_dominio.Conceitos;
using listelab_servico.Validacoes;
using NUnit.Framework;

namespace listaelab_testes.TestesValidador
{
    [TestFixture]
    public class TestesValidadorQuestaoDiscursiva
    {
        [SetUp]
        public void AntesDeTudo()
        {

        }

        [Test, Sequential]
        public void TestaCodigoValido(
            [Values(-1, 0, 1, 10000)] int codigo,
            [Values(true, true, false, true)] bool ehParaDarErro)
        {
            var validador = new ValidacoesQuestaoDiscursiva();

            validador.AssineRegraCodigoValido();

            var resultado = validador.Validate(new QuestaoDiscursiva { Codigo = codigo });

            if (ehParaDarErro)
            {
                Assert.IsFalse(resultado.IsValid);
                Assert.AreEqual(resultado.Errors[0].ErrorMessage, "O código da questão deve ser superior à 0");
            }
            else
            {
                Assert.IsTrue(resultado.IsValid);
            }
        }
    }
}
