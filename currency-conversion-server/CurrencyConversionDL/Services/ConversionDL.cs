using CurrencyConversionDL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyConversionDL.Services
{
    public class ConversionDL : IConversionDL
    {
        private static readonly Dictionary<string, double> _rates = new()
        {
              {"USD", 1.0 },
              {"EUR",0.85},
              {"ILS", 3.36},
              {"GBP", 0.8},
              {"JPY", 144.0},
              {"AUD", 1.5},
              {"CAD", 1.3},
              {"CHF", 0.9},
              {"SEK", 10.2},
              {"NZD", 1.6 }
        };

        public bool isContaintCurrency(string currencyCode)
        {
            return _rates.ContainsKey(currencyCode);
        }

        public double GetRateOfCurrency(string currencyCode)
        {
            return _rates[currencyCode];
        }

        public List<string> GetCurrenccies()
        {
            return _rates.Keys.ToList();
        }
    }
}
