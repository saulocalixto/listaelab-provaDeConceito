using System.Collections.Generic;
using listaelab_model.Model;
using NHibernate;
using System.Linq;
using listelab_database.Repositorios.Contratos;
using NHibernate.Linq;

namespace listelab_database.Repositorios
{
    public class RepositorioPadrao<T> : IRepositorio<T> where T : Questao
    {
        private ISessionFactory _sessao;        

        public ISession Sessao { get; set; }

        public RepositorioPadrao()
        {
            _sessao = new SetupBd().PegueConfiguracaoBd();
            Sessao = _sessao.OpenSession();
        }

        public T Consulte(int codigo)
        {
            return Sessao.QueryOver<T>().Where(x => x.Codigo == codigo).SingleOrDefault();
        }

        public IList<T> Consulte()
        {
            return Sessao.QueryOver<T>().List();
        }

        public void Cadastre(T objeto)
        {
            Sessao.SaveOrUpdate(objeto);
        }

        public void Atualize(T objeto)
        {
            Sessao.SaveOrUpdate(objeto);
        }

        public void Exclua(int codigo)
        {
            Sessao.Query<T>().Where(x => x.Codigo == codigo).Delete();
        }
    }
}
