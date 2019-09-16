using listelab_dominio.Abstrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_dominio.Conceitos
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
