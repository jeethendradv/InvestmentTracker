using InvestmentTracker.Core.DataObj;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace InvestmentTracker.Core
{
    public class MutualFundProxy
    {
        public async Task<List<FundData>> Search(string fundName)
        {
            string result = await GetResultAsync($"{Settings.MutualFundSearchByNameUrl}{fundName}");
            if (!string.IsNullOrEmpty(result))
            {
                JObject obj = JObject.Parse(result);
                JToken data = obj.GetValue("data");
                return data.ToObject<List<FundData>>();
            }
            return null;
        }

        public async Task<decimal> GetPrice(string schemecode, DateTime date)
        {
            decimal price = 0;
            var history = await GetHistory(schemecode);
            NavHistory fund = null;
            do
            {
                fund = history.Find(x => x.Date.Date == date.Date);
                if (fund != null)
                {
                    price = fund.nav;
                }
                date = date.AddDays(-1);
            }
            while (fund == null);            
            return price;
        }

        public async Task<NavHistory> GetLatestPrice(string schemecode)
        {
            List<NavHistory> history = await GetHistory(schemecode);
            return history.OrderByDescending(x => x.Date).FirstOrDefault();
        }

        public async Task<FundData> GetFundData(string schemecode)
        {
            string result = await GetResultAsync($"{Settings.MutualFundSearchByCodeUrl}{schemecode}");
            if (!string.IsNullOrEmpty(result))
            {
                JObject obj = JObject.Parse(result);
                JToken data = obj.GetValue("data");
                return data.ToObject<FundData>();
            }
            return null;
        }

        public async Task<List<NavHistory>> GetHistory(string schemecode)
        {
            string result = await GetResultAsync($"{Settings.MutualFundGetHistoryCodeUrl}{schemecode}");
            if (!string.IsNullOrEmpty(result))
            {
                JObject obj = JObject.Parse(result);
                JToken data = obj.GetValue("data");
                return data.ToObject<List<NavHistory>>();
            }
            return null;
        }

        private async Task<string> GetResultAsync(string resourceUri)
        {
            using (HttpClient client = new HttpClient())
            {
                string uri = $"{Settings.MutualFundServiceBaseUrl}{resourceUri}";
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null;
            }
        }
    }
}
