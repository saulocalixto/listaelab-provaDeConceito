using System;
using System.Collections.Generic;
using System.Text;
using listaelab_model.Model;
using listaelab_model.Servico.Contratos;
using listelab_database.Repositorios;
using listelab_database.Repositorios.Contratos;

namespace listaelab_model.Servico
{
    public class ServicoQuestaoDiscursiva : ServicoPadrao<QuestaoDiscursiva>, IServicoQuestaoDiscursiva
    {
        private RepositorioPadrao<QuestaoDiscursiva> _repositorio;

        protected override RepositorioPadrao<QuestaoDiscursiva> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioPadrao<QuestaoDiscursiva>());
        }
    }
}
