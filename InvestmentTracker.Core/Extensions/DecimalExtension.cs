using System.Globalization;

namespace InvestmentTracker.Core.Extensions
{
    public static class DecimalExtension
    {
        public static string ToIndianMoneyFormat(this decimal value)
        {
            CultureInfo hindi = new CultureInfo("hi-IN");
            string text = string.Format(hindi, "{0:c}", value);
            return text;
        }
    }
}
