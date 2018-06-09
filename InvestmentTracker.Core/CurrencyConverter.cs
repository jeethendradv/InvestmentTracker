using InvestmentTracker.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace InvestmentTracker.Core
{
    internal class CurrencyConverter
    {
        public async Task<decimal> ConvertAsync(Currency from, Currency to, decimal amount)
        {
            decimal price = await FetchPrice(from, to);
            return amount * price;
        }

        private async Task<decimal> FetchPrice(Currency from, Currency to)
        {
            decimal price = 0;
            CurrencyPrice currencyPrice = FetchCachedPrice(from, to);
            if (currencyPrice != null)
            {
                price = currencyPrice.Price;
            }
            else
            {
                CurrencyPriceProxy currencyPriceProxy = new CurrencyPriceProxy();
                price = await currencyPriceProxy.Convert(from, to);
                UpateCache(from, to, price);
            }
            return price;
        }

        private CurrencyPrice FetchCachedPrice(Currency from, Currency to)
        {
            using (var context = new InvestmentTrackerDbContext())
            {
                var currencyPrice = context.CurrencyPrice.Where(x => x.From == from.ToString() && x.To == to.ToString())
                    .SingleOrDefault();
                return (currencyPrice != null &&
                    (currencyPrice.LastUpdated - DateTime.Now).Hours < 3) ? currencyPrice : null;
            }
        }

        private void UpateCache(Currency from, Currency to, decimal price)
        {
            using (var context = new InvestmentTrackerDbContext())
            {
                context.CurrencyPrice.AddOrUpdate(new CurrencyPrice
                {
                    From = from.ToString(),
                    To = to.ToString(),
                    LastUpdated = DateTime.Now,
                    Price = price
                });
                context.SaveChanges();
            }
        }
    }
}
