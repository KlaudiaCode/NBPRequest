using System;
using System.Collections.Generic;
using System.Linq;

namespace NBPRequest
{
    class Models
    {
        public class RateForTableAB
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public double Mid { get; set; }
            public override string ToString()
            {
                return "Currency: " + Currency + Environment.NewLine +
                       "Code: " + Code + Environment.NewLine +
                       "Mid: " + Mid + Environment.NewLine;
            }
        }
        public class RequestForTableAB
        {
            public string Table { get; set; }
            public string No { get; set; }
            public string EffectiveDate { get; set; }
            public List<RateForTableAB> Rates { get; set; }
            public override string ToString()
            {
                string ratesList = "";

                for (int i = 0; i < Rates.LongCount(); i++)
                {
                    ratesList += Rates[i] + Environment.NewLine;
                }

                return "Table: " + Table + Environment.NewLine +
                       "No: " + No + Environment.NewLine +
                       "Effective date: " + EffectiveDate + Environment.NewLine + Environment.NewLine +
                       ratesList;
            }
        }

        public class RateForTableC
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public double Bid { get; set; }
            public double Ask { get; set; }
            public override string ToString()
            {
                return "Currency: " + Currency + Environment.NewLine +
                       "Code: " + Code + Environment.NewLine +
                       "Bid: " + Bid + Environment.NewLine +
                       "Ask: " + Ask + Environment.NewLine;
            }
        }
        public class RequestForTableC
        {
            public string Table { get; set; }
            public string No { get; set; }
            public string TradingDate { get; set; }
            public string EffectiveDate { get; set; }
            public List<RateForTableC> Rates { get; set; }
            public override string ToString()
            {
                string ratesList = "";

                for (int i = 0; i < Rates.LongCount(); i++)
                {
                    ratesList += Rates[i] + Environment.NewLine;
                }

                return "Table: " + Table + Environment.NewLine +
                       "No: " + No + Environment.NewLine +
                       "TradingDate: " + TradingDate + Environment.NewLine +
                       "Effective date: " + EffectiveDate + Environment.NewLine + Environment.NewLine +
                       ratesList;
            }
        }

        public class RateForCurrencyAB
        {
            public string No { get; set; }
            public string EffectiveDate { get; set; }
            public double Mid { get; set; }
            public override string ToString()
            {
                return "No: " + No + Environment.NewLine +
                       "Effective date: " + EffectiveDate + Environment.NewLine +
                       "Mid: " + Mid;
            }
        }

        public class RateForCurrencyC
        {
            public string No { get; set; }
            public string EffectiveDate { get; set; }
            public double Bid { get; set; }
            public double Ask { get; set; }

            public override string ToString()
            {
                return "No: " + No + Environment.NewLine +
                       "Effective date: " + EffectiveDate + Environment.NewLine +
                       "Bid: " + Bid + Environment.NewLine +
                       "Ask: " + Ask + Environment.NewLine;

            }
        }
        public class RequestForCurrencyA
        {
            public string Table { get; set; }
            public string Currency { get; set; }
            public string Code { get; set; }
            public List<RateForCurrencyAB> Rates { get; set; }
            public override string ToString()
            {
                string ratesList = " ";
                for (int i = 0; i < Rates.LongCount(); i++)
                {
                    ratesList += Rates[i];
                }

                return "Table: " + Table + Environment.NewLine +
                       "Currency: " + Currency + Environment.NewLine +
                       "Code: " + Code + Environment.NewLine + Environment.NewLine +
                       ratesList;
            }
        }

        public class RequestForCurrencyB
        {
            public string Table { get; set; }
            public string Country { get; set; }
            public double Symbol { get; set; }
            public string Currency { get; set; }
            public string Code { get; set; }
            public List<RateForCurrencyAB> Rates { get; set; }
            public override string ToString()
            {
                string ratesList = " ";
                for (int i = 0; i < Rates.LongCount(); i++)
                {
                    ratesList += Rates[i];
                }

                return "Table: " + Table + Environment.NewLine +
                       "Country: " + Country + Environment.NewLine +
                       "Symbol: " + Symbol + Environment.NewLine +
                       "Currency: " + Currency + Environment.NewLine +
                       "Code: " + Code + Environment.NewLine + Environment.NewLine +
                       ratesList;
            }
        }

        public class RequestForCurrencyC
        {
            public string Table { get; set; }
            public string Currency { get; set; }
            public string Code { get; set; }
            public List<RateForCurrencyC> Rates { get; set; }
            public override string ToString()
            {
                string ratesList = " ";
                for (int i = 0; i < Rates.LongCount(); i++)
                {
                    ratesList += Rates[i];
                }

                return "Table: " + Table + Environment.NewLine +
                       "Currency: " + Currency + Environment.NewLine +
                       "Code: " + Code + Environment.NewLine + Environment.NewLine +
                       ratesList;
            }
        }
    }
}
