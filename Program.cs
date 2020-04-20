using System;
using System.Net;
using System.Windows.Forms;

namespace NBPRequest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormForCurrency());

        }
    }
}
