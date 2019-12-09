using ListElab.Dominio.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListElab.Dominio.Conceitos
{
    /// <summary>
    /// Representa uma questão discursiva.
    /// </summary>
    [Colecao(Nome = "questoesDiscursivas")]
    public class QuestaoDiscursiva : Questao
    {
        /// <summary>
        /// Representa as palavras chaves que compõe uma resposta esperada.
        /// </summary>
        public IList<string> PalavrasChaves { get; set; }

        public RespostaDiscursiva RespostaEsperada { get; set; }
    }
}
