using ListElab.Data.Repositorios;
using ListElab.Dominio.Conceitos;
using ListElab.Dominio.InterfaceDeServico;
using ListElab.Servico.Validacoes;

namespace ListElab.Servico.ServicosImplementados
{
    public class ServicoQuestaoDiscursiva : ServicoPadrao<QuestaoDiscursiva>, IServicoQuestaoDiscursiva
    {
        private IRepositorio<QuestaoDiscursiva> _repositorio;
        private ValidacoesQuestaoDiscursiva _validador;

        /// <summary>
        /// Retorna o repositório de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do repositório.</returns>
        protected override IRepositorio<QuestaoDiscursiva> Repositorio()
        {
            return _repositorio ?? (_repositorio = new Repositorio<QuestaoDiscursiva>());
        }

        /// <summary>
        /// Retorna uma instância do validador de questões discursivas.
        /// </summary>
        /// <returns>Uma instância do validador.</returns>
        protected override ValidadorPadrao<QuestaoDiscursiva> Validador()
        {
            return _validador ?? (_validador = new ValidacoesQuestaoDiscursiva());
        }
    }
}
