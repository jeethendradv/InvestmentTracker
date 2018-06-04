using System;

namespace InvestmentTracker.Core.DataObj
{
    public class NavHistory
    {
        public decimal nav { get; set; }
        public string date { get; set; }
        public DateTime Date
        {
            get
            {
                return Convert.ToDateTime(date);
            }
        }
    }
}
