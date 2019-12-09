using System;
using System.Collections.Generic;
using System.Text;

namespace ListElab.Dominio.Conceitos
{
    public class RespostaDiscursiva : Resposta
    {
        public IList<PalavrasChaves> PalavrasChaves { get; set; }
    }
}
