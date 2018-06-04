using InvestmentTracker.Core.DataObj;
using InvestmentTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace InvestmentTracker.Core
{
    internal class FundPriceCalculator
    {
        public FundInfo Calculate(decimal currentNavPrice, FundPurchased fund)
        {
            FundInfo fundInfo = new FundInfo
            {
                Name = fund.Name,
                SchemeCode = fund.SchemeCode
            };
            decimal investedAmount = 0, navsPurchased = 0, currentValue = 0, profitLoss = 0;
            if (fund.NavsPurchased.HasValue)
            {
                navsPurchased = fund.NavsPurchased.Value;
                investedAmount = navsPurchased * fund.NavPurchasePrice;
            }
            else if (fund.AmountInvested.HasValue)
            {
                investedAmount = fund.AmountInvested.Value;
                navsPurchased = investedAmount / fund.NavPurchasePrice;
            }
            currentValue = currentNavPrice * navsPurchased;
            profitLoss = currentValue - investedAmount;

            fundInfo.AmountInvested = Round(investedAmount);
            fundInfo.CurrentValue = Round(currentValue);
            fundInfo.NavCurrentPrice = Round(currentNavPrice);
            fundInfo.NavPurchasePrice = Round(fund.NavPurchasePrice);
            fundInfo.NavsPurchased = Round(navsPurchased);
            fundInfo.Percentage = Round((profitLoss / investedAmount) * 100);
            fundInfo.ProfitValue = Round(profitLoss);
            fundInfo.PurchaseDate = fund.PurchaseDate;
            return fundInfo;
        }

        private decimal Round(decimal number)
        {
            return Math.Round(number, 4);
        }
    }
}
