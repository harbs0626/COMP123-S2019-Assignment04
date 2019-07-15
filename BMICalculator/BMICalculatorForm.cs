using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// 
/// Application Name:   BMI Calculator App
/// 
/// Student Name:       Harbin Ramo
/// Student Number:     301046044
/// 
/// BMI Scale:
/// ----------
/// Underweight     Less than 18.5
/// Normal          Between 18.5 and 24.9
/// Overweight      Between 25 and 29.9
/// Obese           30 or greater
/// 
/// BMI Formula:
/// ------------
/// BMI =           weightInPounds * 703
///           -------------------------------
///           heightInInches * heightInInches
///           
/// BMI =             weightInKilograms
///           -------------------------------
///           heightInMeters * heightInMeters
///           
/// </summary>
namespace BMICalculator
{
    public partial class BMICalculatorForm : Form
    {
        public BMICalculatorForm()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.ImperialRadioButton.Checked = false;
            this.MetricRadioButton.Checked = false;

            this.HeightTextBox.Text = "0";
            this.WeightTextBox.Text = "0";

            this.CalculateBMIButton.Enabled = true;
            this.ResetButton.Enabled = false;

            this.BMITextBox.Text = "0";
            this.BMIResultsTextBox.Text = "BMI Result";

            this.BMIResultsProgressBar.Minimum = 1;
            this.BMIResultsProgressBar.Maximum = 100;
            this.BMIResultsProgressBar.BackColor = ProgressBar.DefaultBackColor;

            MessageBox.Show("Form has been reset.",
                "BMI Calculator", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void CalculateBMIButton_Click(object sender, EventArgs e)
        {
            this.CalculateBMIButton.Enabled = false;
            this.ResetButton.Enabled = true;
        }

        private void ImperialRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ImperialRadioButton.Enabled = false;
            this.MetricRadioButton.Enabled = true;
            this.MetricRadioButton.Checked = false;
        }

        private void MetricRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.MetricRadioButton.Enabled = false;
            this.ImperialRadioButton.Enabled = true;
            this.ImperialRadioButton.Checked = false;
        }
    }
}
