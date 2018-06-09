using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvestmentTracker.Core
{
    internal class CurrencyPriceProxy
    {
        public async Task<decimal> Convert(Currency from, Currency to)
        {
            string result = await GetResultAsync(from, to);
            if (!string.IsNullOrEmpty(result))
            {
                JObject obj = JObject.Parse(result);
                JToken data = obj.SelectToken($"{from.ToString()}_{to.ToString()}.val");
                return data.Value<decimal>();
            }
            return 0;
        }

        private async Task<string> GetResultAsync(Currency from, Currency to)
        {
            string uri = $"{ConfigurationManager.AppSettings["CurrencyconverterUrl"]}&q={from.ToString()}_{to.ToString()}";
            using (HttpClient client = new HttpClient())
            {
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
