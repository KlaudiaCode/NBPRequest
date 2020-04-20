using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using static NBPRequest.Models;

namespace NBPRequest
{
    public partial class FormForCurrency : Form
    {
        public FormForCurrency()
        {
            InitializeComponent();
        }

        private void ButtonDownload_Click(object sender, EventArgs e)
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
                    textBoxWindow.Text = "There is no such currency in this table." + Environment.NewLine + 
                                         "Please make sure you choose the right currency/table.";
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
                    textBoxWindow.Text = "There is no such currency in this table." + Environment.NewLine + 
                                         "Please make sure you choose the right currency/table.";
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
                    textBoxWindow.Text = "There is no such currency in this table." + Environment.NewLine + 
                                         "Please make sure you choose the right currency/table.";
                }
            }

            textBoxWindow.ScrollBars = ScrollBars.Both;
            textBoxWindow.WordWrap = false;
        }
    }
}
