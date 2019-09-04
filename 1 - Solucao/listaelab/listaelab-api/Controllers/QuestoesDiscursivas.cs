using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using listaelab_model.Model;
using listaelab_model.Servico;
using Microsoft.AspNetCore.Mvc;

namespace listaelab_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestoesDiscursivas : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{codigo}")]
        public ActionResult<QuestaoDiscursiva> Get(int codigo)
        {
            using (var servico = new ServicoQuestaoDiscursiva())
            {
                return servico.Consulte(codigo);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
