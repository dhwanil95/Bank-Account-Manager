using System.Collections.Generic;

namespace BankAccManagerApp.Models
{
    public class Currency
    {
        public string Code { get; }
        public decimal ExchangeRateToCAD { get; }

        private static readonly Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            { "CAD", 1m },    // 1 CAD = 1 CAD
            { "USD", 0.5m },  // 1 CAD = 0.5 USD
            { "MXN", 10m },   // 1 CAD = 10 MXN
            { "EURO", 0.25m } // 1 CAD = 0.25 EURO
        };

        private Currency(string code, decimal exchangeRateToCAD)
        {
            Code = code;
            ExchangeRateToCAD = exchangeRateToCAD;
        }

        public static Currency FromCode(string code)
        {
            if (exchangeRates.TryGetValue(code, out decimal rate))
            {
                return new Currency(code, rate);
            }
            throw new KeyNotFoundException("Currency not supported");
        }
    }
}
