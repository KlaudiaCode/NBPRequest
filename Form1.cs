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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class RateForTable
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public double Mid { get; set; }
            public override string ToString()
            {
                return this.Currency + " " + this.Code + " " + this.Mid + " ";
            }
        }
        public class RequestForTable
        {
            public string Table { get; set; }
            public string No { get; set; }
            public string EffectiveDate { get; set; }
            public List<RateForTable> Rates { get; set; }
            public override string ToString()
            {
                string ratesList = "";

                for(int i=0; i < Rates.LongCount(); i++)
                {
                    ratesList += this.Rates[i] + Environment.NewLine;
                }

                return "Table: " + this.Table + "    No: " + this.No + "    Effective date: " + this.EffectiveDate + Environment.NewLine + Environment.NewLine + ratesList;
            }
        }

        public class RateForCurrency
        {
            public string No { get; set; }
            public string EffectiveDate { get; set; }
            public double Mid { get; set; }
        }
        public class RequestForCurrency
        {
            public string Table { get; set; }
            public string Currency { get; set; }
            public string Code { get; set; }
            public List<RateForCurrency> Rates { get; set; }
        }

        public static class Helper
        {
            public static string client()
            {
            WebClient webClient = new WebClient();
            return webClient.DownloadString("https://api.nbp.pl/api/exchangerates/tables/A/?format=json");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.WordWrap = false;
            RequestForTable[] rft = JsonConvert.DeserializeObject<RequestForTable[]>(Helper.client());
            textBox1.Text = rft[0].ToString();
        }
    }
}
