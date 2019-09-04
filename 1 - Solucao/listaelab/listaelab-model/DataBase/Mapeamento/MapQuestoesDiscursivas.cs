using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using listaelab_model.Model;

namespace listaelab_model.DataBase.Mapeamento
{
    public class MapQuestoesDiscursivas : ClassMap<QuestaoDiscursiva>
    {
        public MapQuestoesDiscursivas()
        {
            Id(l => l.Codigo, "Codigo");
            Map(l => l.Enunciado, "Enunciado");
            Map(l => l.Resposta, "Resposta");
            HasMany(x => x.PalavrasChaves).Table("PALAVRACHAVE").KeyColumn("CodigoQuestao").Element("Palavra");

            Table("QUESTDISC");
        }
    }
}
