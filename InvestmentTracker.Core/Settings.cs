using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentTracker.Core
{
    internal static class Settings
    {
        public static string MutualFundServiceBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["MutualFundServiceBaseUrl"];
            }
        }

        public static string MutualFundSearchByNameUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["MutualFundSearchByNameUrl"];
            }
        }

        public static string MutualFundSearchByCodeUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["MutualFundSearchByCodeUrl"];
            }
        }

        public static string MutualFundGetHistoryCodeUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["MutualFundGetHistoryCodeUrl"];
            }
        }
    }
}
