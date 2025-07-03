using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversionDL.Interfaces
{
    public interface IConversionDL
    {
        bool isContaintCurrency(string currencyCode);

        double GetRateOfCurrency(string currencyCode);

        List<string> GetCurrenccies();
    }
}
