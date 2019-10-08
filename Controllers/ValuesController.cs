using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiEither.Services;

namespace WebApiEither.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetValue()
        {
            var either = await _valuesService.GetValueAsync();
            return either.ToResponse();
        }

    }
}
