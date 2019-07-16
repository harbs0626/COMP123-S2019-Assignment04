using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMICalculator
{
    static class Program
    {
        public static BMICalculatorForm bmiCalculatorForm;
        public static SplashScreenForm splashScreenForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            splashScreenForm = new SplashScreenForm();
            Application.Run(splashScreenForm);
        }
    }
}
