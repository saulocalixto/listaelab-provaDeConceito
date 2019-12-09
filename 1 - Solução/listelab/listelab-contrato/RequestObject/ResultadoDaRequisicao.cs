using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListElab.Contrato.Requisicao
{
    public class ResultadoDaRequisicao<T>
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object Resultado { get; set; }

        /// <summary>
        /// Retorna um objeto de exceção.
        /// </summary>
        /// <param name="e">A mensagem da exception gerada.</param>
        /// <returns>Retorna o objeto com o erro.</returns>
        public static ResultadoDaRequisicao<T> Erro(Exception e)
        {
            return new ResultadoDaRequisicao<T>
            {
                Mensagem = e.Message,
                Resultado = null,
                Sucesso = false
            };
        }

        /// <summary>
        /// Cria um objeto sem retorno.
        /// </summary>
        /// <param name="menssagem">Mensagem a ser apresentada.</param>
        /// <returns>Retorna objeto sem retorno.</returns>
        public static ResultadoDaRequisicao<T> ApenasMensagem(string menssagem)
        {
            return new ResultadoDaRequisicao<T>
            {
                Mensagem = menssagem,
                Resultado = null,
                Sucesso = true
            };
        }

        /// <summary>
        /// Cria um objeto com retorno.
        /// </summary>
        /// <param name="value">Valor de retorno.</param>
        /// <param name="menssagem">Mensagem de retorno.</param>
        /// <returns></returns>
        public static ResultadoDaRequisicao<T> MensagemEObjeto(object value, string menssagem)
        {
            return new ResultadoDaRequisicao<T>
            {
                Mensagem = menssagem,
                Resultado = value,
                Sucesso = true
            };
        }
    }
}
