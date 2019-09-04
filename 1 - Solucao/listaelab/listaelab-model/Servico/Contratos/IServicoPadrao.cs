using System;
using System.Collections.Generic;
using System.Text;
using listelab_database.Repositorios.Contratos;

namespace listaelab_model.Servico.Contratos
{
    public interface IServicoPadrao<T>
    {
        /// <summary>
        /// Cadastra um conceito.
        /// </summary>
        /// <param name="questao">Conceito a ser cadastrado.</param>
        void Cadastre(T questao);

        /// <summary>
        /// Atualiza um conceito.
        /// </summary>
        /// <param name="questao">Conceito a ser atualizado.</param>
        void Atualize(T questao);

        /// <summary>
        /// Exclua um conceito.
        /// </summary>
        /// <param name="codigo">Questão a ser excluída.</param>
        void Exclua(int codigo);

        /// <summary>
        /// Consulte um conceito.
        /// </summary>
        /// <param name="codigo">Código do conceito.</param>
        /// <returns>Questão discursiva.</returns>
        T Consulte(int codigo);

        /// <summary>
        /// Consulte todos os conceitos cadastrados no banco.
        /// </summary>
        /// <returns>Todos os conceitos cadastrados.</returns>
        List<T> Consulte();
    }
}
