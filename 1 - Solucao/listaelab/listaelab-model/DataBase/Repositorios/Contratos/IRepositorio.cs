using System;
using System.Collections.Generic;
using System.Text;

namespace listelab_database.Repositorios.Contratos
{
    public interface IRepositorio<T>
    {
        /// <summary>
        /// Consulta um item no banco.
        /// </summary>
        /// <param name="codigo">Código do item buscado.</param>
        /// <returns>Item que correspende ao código passado.</returns>
        T Consulte(int codigo);

        /// <summary>
        /// Consulta todos itens no banco.
        /// </summary>
        /// <returns>Itens cadastrados na tabela do banco.</returns>
        IList<T> Consulte();

        /// <summary>
        /// Cadastra um item no banco.
        /// </summary>
        /// <param name="objeto">Item a ser cadastrado.</param>
        void Cadastre(T objeto);

        /// <summary>
        /// Atualize um item no banco.
        /// </summary>
        /// <param name="objeto">Item a ser atualizado.</param>
        void Atualize(T objeto);

        /// <summary>
        /// Atualize um item no banco.
        /// </summary>
        /// <param name="codigo">Item a ser atualizado.</param>
        void Exclua(int codigo);
    }
}
