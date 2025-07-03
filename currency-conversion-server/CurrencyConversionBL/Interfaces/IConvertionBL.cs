using CurrencyConversionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversionBL.Interfaces
{
    public interface IConvertionBL
    {
        BaseResponse<double> Convert(ConversionRequest req);

        BaseResponse<List<string>> GetCurrenccies();
    }
}
