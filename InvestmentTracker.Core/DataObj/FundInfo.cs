using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentTracker.Core.DataObj
{
    public class FundInfo
    {
        public string SchemeCode { get; set; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal NavsPurchased { get; set; }
        public decimal NavPurchasePrice { get; set; }
        public decimal NavCurrentPrice { get; set; }
        public decimal AmountInvested { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal ProfitValue { get; set; }
        public decimal Percentage { get; set; }
        public bool IsInProfit
        {
            get
            {
                return ProfitValue > 0;
            }
        }
    }
}
