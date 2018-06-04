using InvestmentTracker.Core.DataObj;
using InvestmentTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentTracker.Core.Service
{
    public class MutualFundService
    {
        public async Task Add(FundPurchased fund)
        {
            using (var context = new InvestmentTrackerDbContext())
            {
                MutualFundProxy proxy = new MutualFundProxy();
                fund.NavPurchasePrice = await proxy.GetPrice(fund.SchemeCode, fund.PurchaseDate);
                context.FundPurchased.Add(fund);
                context.SaveChanges();
            }
        }

        public async Task<List<FundInfo>> GetAllFunds()
        {
            List<FundInfo> fundInfo = new List<FundInfo>();
            using (var context = new InvestmentTrackerDbContext())
            {
                var funds = context.FundPurchased.ToList();
                var fundgroups = funds.GroupBy(x => x.SchemeCode);
                MutualFundProxy proxy = new MutualFundProxy();
                FundPriceCalculator calculator = new FundPriceCalculator();
                foreach (var group in fundgroups)
                {
                    var latestPrice = await FetchLatestNavPrice(group.Key);
                    foreach (var fund in group)
                    {
                        fundInfo.Add(calculator.Calculate(latestPrice, fund));
                    }
                }
            }
            return fundInfo;
        }

        private async Task<decimal> FetchLatestNavPrice(string schemecode)
        {
            decimal price = 0;
            LatestNavPrice lastestNavPrice = FetchCachedPrice(schemecode);
            if (lastestNavPrice != null)
            {
                price = lastestNavPrice.NavPrice;
            }
            else
            {
                MutualFundProxy proxy = new MutualFundProxy();
                NavHistory nav = await proxy.GetLatestPrice(schemecode);
                UpdateCache(schemecode, nav);
                price = nav.nav;
            }
            return price;
        }

        private LatestNavPrice FetchCachedPrice(string schemecode)
        {
            using (var context = new InvestmentTrackerDbContext())
            {
                var cachedPrice = context.LatestNavPrice.Where(x => x.SchemeCode == schemecode)
                    .SingleOrDefault();
                return (cachedPrice != null
                && (cachedPrice.Date.Date == DateTime.Now.GetIndianDateTime().Date ||
                cachedPrice.LastFetch.Date == DateTime.Now.GetIndianDateTime().Date)) ?
                cachedPrice : null;
            }
        }

        private void UpdateCache(string schemecode, NavHistory latestNav)
        {
            using (var context = new InvestmentTrackerDbContext())
            {
                var latest = context.LatestNavPrice.Where(x => x.SchemeCode == schemecode).SingleOrDefault();
                if (latest == null)
                {
                    context.LatestNavPrice.Add(new LatestNavPrice
                    {
                        SchemeCode = schemecode,
                        LastFetch = DateTime.Now.GetIndianDateTime().Date,
                        Date = latestNav.Date,
                        NavPrice = latestNav.nav
                    });
                }
                else
                {
                    latest.LastFetch = DateTime.Now.GetIndianDateTime();
                    latest.Date = latestNav.Date;
                    latest.NavPrice = latestNav.nav;                    
                }
                context.SaveChanges();
            }
        }
    }
}
