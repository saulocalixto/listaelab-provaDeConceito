using ListElab.Dominio.Abstrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListElab.Dominio.Conceitos
{
    /// <summary>
    /// Representa uma questão genérica.
    /// </summary>
    public class Questao : ObjetoComId
    {
        /// <summary>
        /// Representa o enunciado de uma questão.
        /// </summary>
        public string Enunciado { get; set; }
    }
}
