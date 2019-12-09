using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ListElab.Dominio.CustomAttributes;
using MongoDB.Driver;

namespace ListElab.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T>
    {
        private ConexaoDb _conexao;

        /// <summary>
        /// Acessa a coleção do objeto passado no tipo genérico.
        /// </summary>
        /// <returns>Retorna uma conexão com o banco com a coleção do tipo passado.</returns>
        public IMongoCollection<T> Collection()
        {
            T objeto = Activator.CreateInstance<T>();

            var colecao = objeto.GetType().GetCustomAttributes(true)[0] as Colecao;

            var conexao = Conexao();

            return conexao.ConexaoMongoDB().GetCollection<T>(colecao.Nome);
        }

        /// <summary>
        /// Atualiza um objeto no banco.
        /// </summary>
        /// <param name="condicao">Condição para verificar qual objeto será atualizado.</param>
        /// <param name="objeto">Objeto atualizado para ser persistido.</param>
        public void Atualize(Expression<Func<T, bool>> condicao, T objeto)
        {
            ExecuteAcaoNoBanco(() =>
            {
                Collection().ReplaceOne(condicao, objeto);
            });
        }

        /// <summary>
        /// Cadastra um objeto no banco.
        /// </summary>
        /// <param name="objeto">Objeto criado para ser persistido.</param>
        public void Cadastre(T objeto)
        {
            ExecuteAcaoNoBanco(() =>
            {
                Collection().InsertOne(objeto);
            });
        }

        /// <summary>
        /// Consulta um objeto no banco.
        /// </summary>
        /// <param name="condicao">Condição para filtrar a consulta a ser realizada.</param>
        public T Consulte(Expression<Func<T, bool>> condicao)
        {
            return Collection().Find(condicao).FirstOrDefault();
        }

        /// <summary>
        /// Verifica se um item existe no banco.
        /// </summary>
        /// <param name="condicao">Condição para determinar se um item existe no banco.</param>
        public bool ItemExiste(Expression<Func<T, bool>> condicao)
        {
            return Collection().CountDocuments(condicao) > 0;
        }

        /// <summary>
        /// Consulta uma lista de itens no banco.
        /// </summary>
        /// <param name="condicao">Condição para determinar os itens da lista.</param>
        public IList<T> ConsulteLista(Expression<Func<T, bool>> condicao)
        {
 
            return Collection().Find(condicao).ToList();
        }

        /// <summary>
        /// Exclui um item do banco.
        /// </summary>
        /// <param name="condicao">Condição para determinar qual item deve ser excluído.</param>
        public void Exclua(Expression<Func<T, bool>> condicao)
        {
            ExecuteAcaoNoBanco(() =>
            {
                Collection().DeleteOne(condicao);
            });
        }

        /// <summary>
        /// Executa uma ação no banco.
        /// </summary>
        /// <param name="execute">Ação que deverá ser executada no banco.</param>
        private void ExecuteAcaoNoBanco(Action execute)
        {
            Conexao().Sessao.StartTransaction();

            try
            {
                execute.Invoke();
                Conexao().Sessao.CommitTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao salvar no banco: " + e.Message);
                Conexao().Sessao.AbortTransaction();
            }
        }

        private ConexaoDb Conexao()
        {
            return _conexao ?? (_conexao = new ConexaoDb());
        }
    }
}
