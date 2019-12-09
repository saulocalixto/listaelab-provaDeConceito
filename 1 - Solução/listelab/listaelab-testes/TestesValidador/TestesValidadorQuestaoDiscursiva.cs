using ListElab.Dominio.Conceitos;
using ListElab.Servico.Validacoes;
using NUnit.Framework;
using System.Collections.Generic;

namespace ListElab.Testes.TestesValidador
{
    [TestFixture]
    public class TestesValidadorQuestaoDiscursiva : TesteBase<QuestaoDiscursiva>
    {
        private ValidacoesQuestaoDiscursiva _validador;

        [SetUp]
        public void AntesDoTeste()
        {
            _validador = new ValidacoesQuestaoDiscursiva();
        }

        /// <sumary>
        /// Testa se o código de uma Questão Discursiva é válido.
        /// </sumary>
        /// <param name="codigo">Código de Questão Discursiva a ser testado</param>
        /// <param name="ehParaDarErro">Booleano que determina o resultado esperado do teste</param>
        [Test, Sequential]
        public void TesteRegraCodigoValido(
            [Values(-1, 0, 1, 10000)] int codigo,
            [Values(true, true, false, true)] bool ehParaDarErro)
        {
            _validador.AssineRegraCodigoValido();

            var questaoDiscursiva = new QuestaoDiscursiva { Codigo = codigo };

            EfetueChecagem(ehParaDarErro, questaoDiscursiva, _validador, "O código da questão deve ser superior à 0 e menor ou igual à 9999");
        }

        /// <sumary>
        /// Testa se uma Questão Discursiva sendo criada possui enunciado informado.
        /// </sumary>
        /// <param name="enunciado">Enunciado de Questão Discursiva a ser testada</param>
        /// <param name="ehParaDarErro">Booleano que determina o resultado esperado do teste</param>
        [Test, Sequential]
        public void TesteRegraDeveTerEnunciado(
            [Values(null, "", "Enunciado.", " ")] string enunciado,
            [Values(true, true, false, true)] bool ehParaDarErro)
        {
            _validador.AssineRegraDeveTerEnunciado();

            var questaoDiscursiva = new QuestaoDiscursiva { Enunciado = enunciado };

            EfetueChecagem(ehParaDarErro, questaoDiscursiva, _validador, "O enunciado da questão deve ser informado");
        }

        /// <sumary>
        /// Testa se uma Questão Discursiva sendo criada possui PalavrasChaves e Peso informados.
        /// </sumary>
        /// <param name="palavraChaveInformado">Booleano que determina se a Questão Discursiva possui PalavrasChave</param>
        [Test, Theory]
        public void TesteRegraPalavraChaveInformado(bool palavraChaveInformado)
        {
            _validador.AssineRegraPalavraChaveInformado();

            var questaoDiscursiva = palavraChaveInformado ? new QuestaoDiscursiva
            {
                RespostaEsperada = new RespostaDiscursiva
                {
                    PalavrasChaves = new List<PalavrasChaves>
                    {
                        new PalavrasChaves
                        {
                            PalavraChave = "Dilma",
                            Peso = 10
                        }
                    }
                }
            } : new QuestaoDiscursiva { RespostaEsperada = new RespostaDiscursiva() };

            EfetueChecagem(!palavraChaveInformado, questaoDiscursiva, _validador, "Pelo menos uma palavra chave deve ser informada");
        }
    }
}

