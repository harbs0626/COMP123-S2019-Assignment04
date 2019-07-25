using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMICalculator
{
    static class Program
    {
        public static Dictionary<string, Form> Forms;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Forms = new Dictionary<string, Form>();
            Forms.Add("BMICalculatorForm", new BMICalculatorForm());
            Forms.Add("SplashScreenForm", new SplashScreenForm());

            Application.Run(Forms[FormName.SplashScreenForm.ToString()]);
        }
    }
}
