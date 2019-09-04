using System;
using System.Collections.Generic;
using System.Text;

namespace listaelab_model.Model
{
    public abstract class Questao
    {
        public virtual Guid Id { get; set; }
        public virtual string Enunciado { get; set; }
        public virtual int Codigo { get; set; }
        public virtual string Resposta { get; set; }

        public abstract bool RespostaEhCorreta();
    }
}
