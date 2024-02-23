using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigedesp.Models;

namespace Sigedesp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDespesaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TipoDespesaModel>> BuscarTodosTipoDespesa()
        {
            return Ok();
        }
    }
}
