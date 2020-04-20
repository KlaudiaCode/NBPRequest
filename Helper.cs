using System;
using System.Net;
using System.Text;

namespace NBPRequest
{
    public static class Helper
    {
            public static string Client(string letter)
            {

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string website = "https://api.nbp.pl/api/exchangerates/tables/" + letter + "/?format=json";
                return webClient.DownloadString(website);

            }
            public static string Client(string letter, string code)
            {

                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string website = " https://api.nbp.pl/api/exchangerates/rates/" + letter + "/" + code + "/" + "/?format=json";
                return webClient.DownloadString(website);

            }
    }
}
