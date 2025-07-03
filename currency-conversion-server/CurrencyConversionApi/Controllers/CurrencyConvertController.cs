using CurrencyConversionBL.Interfaces;
using CurrencyConversionEntities;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConversionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CurrencyConvertController : ControllerBase
    {

        private readonly IConvertionBL _convertionBL;

        public CurrencyConvertController(IConvertionBL convertionBL)
        {
            _convertionBL = convertionBL;
        }


        [HttpPost]
        public IActionResult Convert([FromBody] ConversionRequest req)
        {
            try
            {
                BaseResponse<double> baseResponse = _convertionBL.Convert(req);
                return StatusCode(baseResponse.statusCode,baseResponse.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]

        public IActionResult GetCurrenccies()
        {
            try
            {
                BaseResponse<List<string>> baseResponse = _convertionBL.GetCurrenccies();
                return StatusCode(baseResponse.statusCode, baseResponse.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
