namespace InvestmentTracker.Core.DataObj
{
    public class FundData
    {
        public string scheme_code { get; set; }
        public string isin_div_payout_or_growth { get; set; }
        public string isin_div_reinvestment { get; set; }
        public string scheme_name { get; set; }
        public decimal? nav { get; set; }
        public decimal? repurchase_price { get; set; }
        public decimal? sale_price { get; set; }
        public string amc { get; set; }
        public string scheme_type { get; set; }
        public string date { get; set; }
    }
}
