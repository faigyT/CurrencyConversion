using CurrencyConversionBL.Interfaces;
using CurrencyConversionEntities;
using CurrencyConversionDL.Interfaces;
using System.Text.Json;

namespace CurrencyConversionBL.Services
{
    public class ConvertionBL : IConvertionBL
    {
        private Dictionary<string, double> _exchangeRates;
        private readonly IConversionDL _currencyConversionDL;

        public ConvertionBL(IConversionDL currencyConversionDL)
        {
            _currencyConversionDL = currencyConversionDL;
        }

        //private void LoadExchangeRates()
        //{
        //    var json = File.ReadAllText("exchangeRates.json"); // או נתיב יחסי לתוך /Data
        //    _exchangeRates = JsonSerializer.Deserialize<Dictionary<string, double>>(json);
        //}

        public bool IsValidCurrency(string currencyCode)//מקבל קוד מטבע
        {
            if (string.IsNullOrWhiteSpace(currencyCode))
                return false;

            currencyCode = currencyCode.ToUpper();

            if (currencyCode.Length != 3)
                return false;

            if (!currencyCode.All(char.IsLetter))
                return false;

            return _currencyConversionDL.isContaintCurrency(currencyCode);
        }

        public BaseResponse<double> Convert(ConversionRequest req)
        {
            if (!IsValidCurrency(req.TargetCurrency)|| !IsValidCurrency(req.SourceCurrency))
            {
                return new BaseResponse<double> { ErrorMessage="The Currency is not valid", IsSuccess = false, statusCode = 400 };
            }

            if (req.Amount <= 0)
            {
                return new BaseResponse<double> { ErrorMessage="The Amount is not valid" ,IsSuccess = false, statusCode = 400 };
            }

            double targetCurrencyAmount = _currencyConversionDL.GetRateOfCurrency(req.TargetCurrency);
            double sourceCurrencyAmount = _currencyConversionDL.GetRateOfCurrency(req.SourceCurrency);

            double amount=req.Amount/sourceCurrencyAmount*targetCurrencyAmount;


            return new BaseResponse<double> { Data = amount, IsSuccess = true, statusCode = 200 };
        }

        public BaseResponse<List<string>> GetCurrenccies()
        {
            List<string> allCurrencies = _currencyConversionDL.GetCurrenccies();
            return new BaseResponse<List<string>> { Data = allCurrencies, IsSuccess = true, statusCode = 200 };
        }
    }
}
