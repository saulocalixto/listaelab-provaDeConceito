using FluentValidation;
using ListElab.Dominio.Conceitos;
using System.Collections.Generic;
using System.Linq;

namespace ListElab.Servico.Validacoes
{
    public class ValidacoesQuestaoDiscursiva : ValidadorPadrao<QuestaoDiscursiva>
    {
        /// <summary>
        /// Adiciona a validação de código da questão ao Validador, verificando se o código está ente um intervalo válido.
        /// ID do requisito: não se aplica.
        /// </summary>
        public void AssineRegraCodigoValido()
        {
            RuleFor(questao => questao.Codigo)
                .Must(codigo => codigo > 0 && codigo < 9999)
                .WithMessage("O código da questão deve ser superior à 0 e menor ou igual à 9999");
        }

        /// <summary>
        /// Adiciona a validação de enunciado da questão ao Validador, verificando se uma questão possui enunciado.
        /// ID do requisito: UC003
        /// </summary>
        public void AssineRegraDeveTerEnunciado()
        {
            RuleFor(questao => questao.Enunciado)
                .Must(enunciado => !string.IsNullOrEmpty(enunciado))
                .WithMessage("O enunciado da questão deve ser informado");
        }

        /// <summary>
        /// Adiciona a validação de palavras chave da questão ao Validador, verificando se uma questão possui palavras chave informadas.
        /// ID do requisito: UC003.4
        /// </summary>
        public void AssineRegraPalavraChaveInformado()
        {
            RuleFor(questao => questao.PalavrasChaves)
                .Must(ValidePalavrasChaves)
                .WithMessage("Pelo menos uma palavra chave deve ser informada");
        }

        /// <summary>
        /// Assina regras para o cenário de cadastro.
        /// </summary>
        protected override void AssineRegrasDeCadastro()
        {
            AssineRegraCodigoValido();
            AssineRegraPalavraChaveInformado();
            AssineRegraDeveTerEnunciado();
        }

        /// <summary>
        /// Assina regras para o cenário de atualização.
        /// </summary>
        protected override void AssineRegrasDeAtualizacao()
        {
            AssineRegraCodigoValido();
            AssineRegraPalavraChaveInformado();
            AssineRegraDeveTerEnunciado();
        }

        /// <summary>
        /// Assina regras para o cenário de exclusão.
        /// </summary>
        protected override void AssineRegrasDeExclusao()
        {
        }

        private bool ValidePalavrasChaves(IList<string> palavras)
        {
            if (palavras == null)
            {
                return false;
            }

            var listaValidada = palavras.ToList();

            return listaValidada.Any(x => !string.IsNullOrWhiteSpace(x));
        }
    }
}
