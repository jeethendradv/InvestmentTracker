using InvestmentTracker.Core.DataObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentTracker.Web.Models
{
    public class InvestmentSummary
    {
        private List<FundInfo> _funds;
        public InvestmentSummary(List<FundInfo> funds)
        {
            _funds = funds;
        }

        public decimal TotalInvested
        {
            get
            {
                return Round(_funds.Sum(x => x.AmountInvested));
            }
        }

        public decimal TotalCurrentValue
        {
            get
            {
                return Round(_funds.Sum(x => x.CurrentValue));
            }
        }

        public decimal ProfitLoss
        {
            get
            {
                return TotalCurrentValue - TotalInvested;
            }
        }

        public decimal Percentage
        {
            get
            {
                return Round((ProfitLoss / TotalInvested) * 100);
            }
        }

        public bool IsInProfit
        {
            get
            {
                return ProfitLoss > 0;
            }
        }

        private decimal Round(decimal price)
        {
            return Math.Round(price, 4);
        }
    }
}