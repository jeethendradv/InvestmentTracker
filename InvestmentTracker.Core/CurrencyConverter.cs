using System.Threading.Tasks;

namespace InvestmentTracker.Core
{
    internal class CurrencyConverter
    {
        CurrencyPriceProxy _currencyPriceProxy;
        public CurrencyConverter()
        {
            _currencyPriceProxy = new CurrencyPriceProxy();
        }

        public async Task<decimal> ConvertAsync(Currency from, Currency to, decimal amount)
        {
            decimal price = await _currencyPriceProxy.Convert(from, to);
            return amount * price;
        }
    }
}
