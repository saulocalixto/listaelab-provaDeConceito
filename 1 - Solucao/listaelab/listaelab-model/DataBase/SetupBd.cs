using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace listelab_database
{
    public class SetupBd
    {
        public ISessionFactory PegueConfiguracaoBd()
        {
            var connStr = @"Server=localhost\SQLEXPRESS;Database=listelab;Trusted_Connection=True;";
            var _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                .BuildSessionFactory();

            return _sessionFactory;
        }
    }
}
