﻿using ListElab.Data.Repositorios;
using ListElab.Dominio.Abstrato;
using ListElab.Dominio.InterfaceDeServico;
using ListElab.Servico.Validacoes;
using System;
using System.Collections.Generic;

namespace ListElab.Servico.ServicosImplementados
{
    public abstract class ServicoPadrao<T> : IServicoPadrao<T> where T : ObjetoComId
    {
        /// <summary>
        /// Atualiza um objeto genérico no banco.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        public void Atualize(T objeto)
        {
            Validador().AssineRegrasAtualizacao();

            Validador().Valide(objeto);

            if (objeto.Id != Guid.Empty)
            {
                Repositorio().Atualize(x => x.Codigo == objeto.Codigo, objeto);
            }
            else
            {
                objeto.Id = Repositorio().Consulte(x => x.Codigo == objeto.Codigo).Id;
                Repositorio().Atualize(x => x.Codigo == objeto.Codigo, objeto);
            }
        }

        /// <summary>
        /// Cadastra um objeto de tipo genérico.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        public virtual void Cadastre(T objeto)
        {
            Validador().AssineRegrasCadastro();

            Validador().Valide(objeto);

            Repositorio().Cadastre(objeto);
        }

        /// <summary>
        /// Consulta o primeiro objeto genérico que atende uma condição.
        /// </summary>
        /// <param name="codigo">O código que será usado como filtro.</param>
        /// <returns></returns>
        public virtual T Consulte(int codigo)
        {
            return Repositorio().Consulte(x => x.Codigo == codigo);
        }

        /// <summary>
        /// Consulta todos os objetos que obedecem uma condição.
        /// </summary>
        /// <returns>Retorna uma coleção de objetos genéricos.</returns>
        public virtual IList<T> ConsulteLista()
        {
            return Repositorio().ConsulteLista(x => true);
        }

        /// <summary>
        /// Exclua todos os objetos que atendem determinada condição.
        /// </summary>
        /// <param name="codigo">O código que será usado como filtro.</param>
        public virtual void Exclua(int codigo)
        {
            Repositorio().Exclua(x => x.Codigo == codigo);
        }

        protected abstract IRepositorio<T> Repositorio();

        protected abstract ValidadorPadrao<T> Validador();
    }
}
