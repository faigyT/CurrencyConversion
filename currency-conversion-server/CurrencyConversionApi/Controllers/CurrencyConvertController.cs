using CurrencyConversionEntities;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConversionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CurrencyConvertController : ControllerBase
    {
        

        [HttpPost]
        public IActionResult Convert([FromBody] ConversionRequest req)
        {
            try
            {
                return Ok(req);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
