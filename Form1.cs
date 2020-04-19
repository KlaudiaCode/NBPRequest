using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NBPRequest
{
    public partial class FormForCurrency : Form
    {
        public FormForCurrency()
        {
            InitializeComponent();
        }
        /// <summary>
        /// TABLES MODELS
        /// </summary>
        public class RateForTableAB
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public double Mid { get; set; }
            public override string ToString()
            {
                return "Currency: " + this.Currency + Environment.NewLine + 
                       "Code: " + this.Code + Environment.NewLine +
                       "Mid: " + this.Mid + Environment.NewLine;
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

                for(int i=0; i < Rates.LongCount(); i++)
                {
                    ratesList += this.Rates[i] + Environment.NewLine;
                }

                return "Table: " + this.Table + Environment.NewLine +
                       "No: " + this.No + Environment.NewLine +
                       "Effective date: " + this.EffectiveDate + Environment.NewLine + Environment.NewLine + 
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
                return "Currency: " + this.Currency + Environment.NewLine +
                       "Code: " + this.Code + Environment.NewLine +
                       "Bid: " + this.Bid + Environment.NewLine +
                       "Ask: " + this.Ask + Environment.NewLine;
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
                    ratesList += this.Rates[i] + Environment.NewLine;
                }

                return "Table: " + this.Table + Environment.NewLine +
                       "No: " + this.No + Environment.NewLine +
                       "TradingDate: " + this.TradingDate + Environment.NewLine +
                       "Effective date: " + this.EffectiveDate + Environment.NewLine + Environment.NewLine + 
                       ratesList;
            }
        }

        /// <summary>
        /// CURRENCY MODELS
        /// </summary>

        public class RateForCurrencyAB
        {
            public string No { get; set; }
            public string EffectiveDate { get; set; }
            public double Mid { get; set; }
            public override string ToString()
            {
                return "No: " + this.No + Environment.NewLine + 
                       "Effective date: " +  this.EffectiveDate + Environment.NewLine +
                       "Mid: " + this.Mid;
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
                return "No: " + this.No + Environment.NewLine +
                       "Effective date: " + this.EffectiveDate + Environment.NewLine +
                       "Bid: " + this.Bid + Environment.NewLine +
                       "Ask: " + this.Ask + Environment.NewLine;

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
                 
                return "Table: " + this.Table + Environment.NewLine +
                       "Currency: " + this.Currency + Environment.NewLine +
                       "Code: " + this.Code + Environment.NewLine + Environment.NewLine + 
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

                return "Table: " + this.Table + Environment.NewLine +
                       "Country: " + this.Country + Environment.NewLine +
                       "Symbol: " + this.Symbol + Environment.NewLine +
                       "Currency: " + this.Currency + Environment.NewLine +
                       "Code: " + this.Code + Environment.NewLine + Environment.NewLine +
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

                return "Table: " + this.Table + Environment.NewLine +
                       "Currency: " + this.Currency + Environment.NewLine +
                       "Code: " + this.Code + Environment.NewLine + Environment.NewLine +
                       ratesList;
            }
        }
        /// <summary>
        /// /////////////////////////
        /// </summary>
        public static class Helper
        {
            public static string Client(string letter)
            {

                WebClient webClient = new WebClient();

                string website = "https://api.nbp.pl/api/exchangerates/tables/" + letter + "/?format=json";
                return webClient.DownloadString(website);

            }
            public static string Client(string letter, string code)
            {

                WebClient webClient = new WebClient();

                string website = " https://api.nbp.pl/api/exchangerates/rates/" + letter + "/" + code + "/" + "/?format=json";
                return webClient.DownloadString(website);

            }
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            string letter = "A";
            string code = comboBoxCash.Text;

            if (radioButtonB.Checked == true)
            {
                letter = "B";
            }
            else if (radioButtonC.Checked == true)
            {
                letter = "C"; 
            }


            if (letter == "A" && code == "<- - - -TABLE- - - ->" || letter == "B" && code == "<- - - -TABLE- - - ->")
            {
                RequestForTableAB[] rft = JsonConvert.DeserializeObject<RequestForTableAB[]>(Helper.Client(letter));
                textBoxWindow.Text = rft[0].ToString();
            }
            else if (letter == "C" && code == "<- - - -TABLE- - - ->")
            {
                RequestForTableC[] rft = JsonConvert.DeserializeObject<RequestForTableC[]>(Helper.Client(letter));
                textBoxWindow.Text = rft[0].ToString();
            }
            else if (letter == "A")
            {
                try
                {
                    RequestForCurrencyA rfc = JsonConvert.DeserializeObject<RequestForCurrencyA>(Helper.Client(letter, code));
                    textBoxWindow.Text = rfc.ToString();
                }
                catch (Exception)
                {
                    textBoxWindow.Text = "There is no such currency in this table." + Environment.NewLine + "Please make sure you choose the right currency/table.";
                }
            }
            else if (letter == "B")
            {
                try
                {
                    RequestForCurrencyB rfc = JsonConvert.DeserializeObject<RequestForCurrencyB>(Helper.Client(letter, code));
                    textBoxWindow.Text = rfc.ToString();
                }
                catch (Exception)
                {
                    textBoxWindow.Text = "There is no such currency in this table." + Environment.NewLine + "Please make sure you choose the right currency/table.";
                }
            }
            else if (letter == "C")
            { 
                try
                {
                    RequestForCurrencyC rfc = JsonConvert.DeserializeObject<RequestForCurrencyC>(Helper.Client(letter, code));
                    textBoxWindow.Text = rfc.ToString();
                }
                catch (Exception)
                {
                    textBoxWindow.Text = "There is no such currency in this table." + Environment.NewLine + "Please make sure you choose the right currency/table.";
                }
            }

            textBoxWindow.ScrollBars = ScrollBars.Both;
            textBoxWindow.WordWrap = false;
        }
    }
}
