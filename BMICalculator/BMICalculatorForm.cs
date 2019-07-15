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
/// Imperial
/// BMI =           weightInPounds * 703
///           -------------------------------
///           heightInInches * heightInInches
/// 
/// Metric
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
            this.CalculateBMIButton.Enabled = false;
            this.ResetButton.Enabled = false;

            this.ClearForm();

            MessageBox.Show("Form has been reset.",
                "BMI Calculator", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void ClearForm()
        {
            this.HeightTextBox.Text = "0";
            this.WeightTextBox.Text = "0";

            this.HeightTextBox.Enabled = false;
            this.WeightTextBox.Enabled = false;

            this.BMITextBox.Text = "0";
            this.BMIResultsTextBox.Text = "BMI Result";

            this.BMIResultsProgressBar.Minimum = 0;
            this.BMIResultsProgressBar.Maximum = 100;
            this.BMIResultsProgressBar.Value = 0;
            this.BMIResultsProgressBar.BackColor = Color.WhiteSmoke;
        }

        private double _weightInPounds = 0.0;
        private double _heightInInches = 0.0;
        private double _weightInKilograms = 0.0;
        private double _heightInMeters = 0.0;

        private void CalculateBMIButton_Click(object sender, EventArgs e)
        {
            this.CalculateBMIButton.Enabled = false;
            this.ResetButton.Enabled = true;

            if (this.ImperialRadioButton.Checked)
            {
                this._weightInPounds = double.Parse(this.WeightTextBox.Text);
                this._heightInInches = double.Parse(this.HeightTextBox.Text);

                double _result = 0.0;
                _result = (_weightInPounds * 703.0) / (_heightInInches * _heightInInches);

                this.BMIResultsScale(_result);

                this.BMITextBox.Text = _result.ToString("F");
            }
            else if (this.MetricRadioButton.Checked)
            {
                this._weightInKilograms = double.Parse(this.WeightTextBox.Text);
                this._heightInMeters = double.Parse(this.HeightTextBox.Text);

                double _result = 0.0;
                _result = _weightInKilograms / (_heightInMeters * _heightInMeters);

                this.BMIResultsScale(_result);

                this.BMITextBox.Text = _result.ToString("F");
            }
        }

        private void BMIResultsScale(double _result)
        {
            this.BMIResultsProgressBar.Minimum = 0;
            this.BMIResultsProgressBar.Maximum = 100;

            if (_result < 18.5)
            {
                this.BMIResultsTextBox.Text = "You are Underweight";
                //yellow
                this.BMIResultsProgressBar.BackColor = Color.Yellow;
                this.BMIResultsProgressBar.Value = (int)_result;
            }
            else if ((_result >= 18.5) && (_result <= 24.9))
            {
                this.BMIResultsTextBox.Text = "You are Normal";
                //green
                this.BMIResultsProgressBar.BackColor = Color.Green;
                this.BMIResultsProgressBar.Value = (int)_result;
            }
            else if ((_result >= 25) && (_result <= 29.9))
            {
                this.BMIResultsTextBox.Text = "You are Overweight";
                //orange
                this.BMIResultsProgressBar.BackColor = Color.Orange;
                this.BMIResultsProgressBar.Value = (int)_result;
            }
            else if (_result >= 30)
            {
                this.BMIResultsTextBox.Text = "You are Obese";
                //red
                this.BMIResultsProgressBar.BackColor = Color.Red;
                this.BMIResultsProgressBar.Value = (int)_result;
            }
        }

        private void BMICalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void BMICalculatorMode_CheckedChange(object sender, EventArgs e)
        {
            if (this.ImperialRadioButton.Checked)
            {
                this.MetricRadioButton.Checked = false;
            }
            else if (this.MetricRadioButton.Checked)
            {
                this.ImperialRadioButton.Checked = false;
            }

            this.CalculateBMIButton.Enabled = true;
            this.ClearForm();
            this.HeightTextBox.Enabled = true;
            this.WeightTextBox.Enabled = true;

            this.HeightAndWeightTextBox_TextChanged(sender, e);
        }

        private void HeightAndWeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((this.HeightTextBox.Text == "0") && 
                (this.WeightTextBox.Text == "0"))
            {
                this.CalculateBMIButton.Enabled = false;
                this.ResetButton.Enabled = true;
            }
            else
            {
                if ((this.HeightTextBox.Text == "0") || 
                    (this.WeightTextBox.Text == "0"))
                {
                    this.CalculateBMIButton.Enabled = false;
                    this.ResetButton.Enabled = true;
                }
                else
                {
                    this.CalculateBMIButton.Enabled = true;
                    this.ResetButton.Enabled = false;
                }
            }
        }
    }
}
