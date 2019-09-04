using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace listaelab_model.Model
{
    public class QuestaoDiscursiva : Questao
    {
        public virtual IList<string> PalavrasChaves { get; set; }

        public override bool RespostaEhCorreta()
        {
            return Resposta.Split().Intersect(PalavrasChaves).Any();
        }
    }
}
