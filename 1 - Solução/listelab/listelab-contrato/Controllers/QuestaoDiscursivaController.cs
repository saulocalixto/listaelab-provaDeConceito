using ListElab.Contrato.Requisicao;
using ListElab.Dominio;
using ListElab.Dominio.Conceitos;
using ListElab.Dominio.InterfaceDeServico;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ListElab.Contrato.Controllers
{
    /// <summary>
    /// Api para o conceito de questão discursiva.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoDiscursivaController : ControllerBase
    {
        /// <summary>
        /// Lista todas as questões discursivas cadastradas.
        /// </summary>
        /// <returns>Retorna um objeto de sucesso ou falha e a lista desejada, caso sucesso.</returns>
        [HttpGet]
        public ActionResult<ResultadoDaRequisicao<QuestaoDiscursiva>> Get()
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                var questao = servico.ConsulteLista();

                return ResultadoDaRequisicao<QuestaoDiscursiva>.MensagemEObjeto(questao, "Consulta realizada sem erros");
            }
            catch (Exception e)
            {
                return ResultadoDaRequisicao<QuestaoDiscursiva>.Erro(e);
            }
        }

        /// <summary>
        /// Retorna a questão discursiva do código informado.
        /// </summary>
        /// <param name="codigo">O código da questão discursiva que se deseja buscar.</param>
        /// <returns>Retorna objeto de resposta de sucesso ou falha, contendo o objeto desejado, caso sucesso.</returns>
        [HttpGet("{codigo}")]
        public ActionResult<ResultadoDaRequisicao<QuestaoDiscursiva>> Get(int codigo)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                var questao = servico.Consulte(codigo);

                return ResultadoDaRequisicao<QuestaoDiscursiva>.MensagemEObjeto(questao, "Consulta realizada sem erros");
            }
            catch (Exception e)
            {
                return ResultadoDaRequisicao<QuestaoDiscursiva>.Erro(e);
            }
        }

        /// <summary>
        /// Cadastra uma questão discursiva.
        /// </summary>
        /// <param name="questao">A questão discursiva que se deseja cadastrar.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Route("cadastre")]
        public ActionResult<ResultadoDaRequisicao<QuestaoDiscursiva>> Cadastre([FromBody] QuestaoDiscursiva questao)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                servico.Cadastre(questao);
                return ResultadoDaRequisicao<QuestaoDiscursiva>.ApenasMensagem("Cadastro realizado sem erros");
            }
            catch (Exception e)
            {
                return ResultadoDaRequisicao<QuestaoDiscursiva>.Erro(e);
            }
        }

        /// <summary>
        /// Atualiza uma questão discursiva.
        /// </summary>
        /// <param name="objeto">O objeto para atualização.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpPost]
        [Route("atualize")]
        public ActionResult<ResultadoDaRequisicao<QuestaoDiscursiva>> Atualize([FromBody] QuestaoDiscursiva objeto)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                servico.Atualize(objeto);
                return ResultadoDaRequisicao<QuestaoDiscursiva>.ApenasMensagem("Atualização realizada sem erros");
            }
            catch (Exception e)
            {
                return ResultadoDaRequisicao<QuestaoDiscursiva>.Erro(e);
            }
        }

        /// <summary>
        /// Exclue uma questão discursiva.
        /// </summary>
        /// <param name="codigo">Código da questão discursiva que se deseja excluir.</param>
        /// <returns>Retorna objeto com resultado da requisição.</returns>
        [HttpDelete("{codigo}")]
        public ActionResult<ResultadoDaRequisicao<QuestaoDiscursiva>> Delete(int codigo)
        {
            try
            {
                var servico = FabricaGenerica.Crie<IServicoQuestaoDiscursiva>();
                servico.Exclua(codigo);

                return ResultadoDaRequisicao<QuestaoDiscursiva>.ApenasMensagem("Exclusão realizada sem erros");
            }
            catch (Exception e)
            {
                return ResultadoDaRequisicao<QuestaoDiscursiva>.Erro(e);
            }
        }
    }
}
