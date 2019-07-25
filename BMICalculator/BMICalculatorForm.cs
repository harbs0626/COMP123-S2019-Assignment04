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
            this.ResetForm();
        }

        /// <summary>
        /// This method clears the values from the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearForm()
        {
            this.HeightTextBox.Text = "0";
            this.WeightTextBox.Text = "0";
            this.HeightTextBox.Enabled = false;
            this.WeightTextBox.Enabled = false;
            this.BMITextBox.Text = "0";
            this.BMIResultsTextBox.Text = "BMI Result";
            this.BMIResultsTextBox.ForeColor = Color.Gray;
            this.BMIResultsTextBox.BackColor = Color.FromName("Control");
            this.BMIResultsProgressBar.Minimum = 0;
            this.BMIResultsProgressBar.Maximum = 100;
            this.BMIResultsProgressBar.Value = 0;
            this.BMIResultsProgressBar.BackColor = Color.WhiteSmoke;
        }

        /// <summary>
        /// This method resets the controls from the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetForm()
        {
            this.ImperialRadioButton.Checked = false;
            this.MetricRadioButton.Checked = false;
            this.CalculateBMIButton.Enabled = false;
            this.ResetButton.Enabled = false;
            this.ClearForm();
            this.ApplicationMessage("Form has been reset.", "BMI Calculator");
        }

        private void CalculateBMIButton_Click(object sender, EventArgs e)
        {
            this.CalculateBMIButton.Enabled = false;
            this.ResetButton.Enabled = true;
            if (this.ImperialRadioButton.Checked)
            {
                this.CalculateBMI("Imperial", 
                    double.Parse(this.WeightTextBox.Text),
                    double.Parse(this.HeightTextBox.Text));
            }
            else if (this.MetricRadioButton.Checked)
            {
                this.CalculateBMI("Metric",
                    double.Parse(this.WeightTextBox.Text),
                    double.Parse(this.HeightTextBox.Text));
            }
        }

        private double _weightInPounds;
        private double _heightInInches;
        private double _weightInKilograms;
        private double _heightInMeters;
        private double _result;

        /// <summary>
        /// This method handles calculation of BMI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateBMI(string mode, double weight, double height)
        {
            this._weightInPounds = 0.0;
            this._heightInInches = 0.0;
            this._weightInKilograms = 0.0;
            this._heightInMeters = 0.0;
            this._result = 0.0;

            switch (mode)
            {
                case "Imperial":
                    this._weightInPounds = weight;
                    this._heightInInches = height;
                    this._result = (_weightInPounds * 703.0) / (_heightInInches * _heightInInches);
                    this.BMIResultsScale(this._result);
                    this.BMITextBox.Text = this._result.ToString("F");
                    break;
                case "Metric":
                    this._weightInKilograms = weight;
                    this._heightInMeters = height;
                    this._result = _weightInKilograms / (_heightInMeters * _heightInMeters);
                    this.BMIResultsScale(this._result);
                    this.BMITextBox.Text = this._result.ToString("F");
                    break;
            }
        }

        /// <summary>
        /// This method handles both BMIResultsScaleChange and ProgressBarChange
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMIResultsScale(double _result)
        {
            if (_result < 18.5)
            {
                this.BMIResultsScaleChange(ScaleMessage.Underweight.ToString(), "Black", "Yellow");
                this.ProgressBarChange("Yellow", 30);
            }
            else if ((_result >= 18.5) && (_result <= 24.9))
            {
                this.BMIResultsScaleChange(ScaleMessage.Normal.ToString(), "White", "Green");
                this.ProgressBarChange("Green", 50);
            }
            else if ((_result >= 25) && (_result <= 29.9))
            {
                this.BMIResultsScaleChange(ScaleMessage.Overweight.ToString(), "White", "Orange");
                this.ProgressBarChange("Orange", 70);
            }
            else if (_result >= 30)
            {
                this.BMIResultsScaleChange(ScaleMessage.Obese.ToString(), "White", "Red");
                this.ProgressBarChange("Red", 100);
            }
        }
        private void ProgressBarChange(string foreColorName, int value)
        {
            this.BMIResultsProgressBar.ForeColor = Color.FromName(foreColorName);
            this.BMIResultsProgressBar.Value = value;
        }
        private void BMIResultsScaleChange(string message, 
            string foreColorName, string backColorName)
        {
            this.BMIResultsTextBox.Text = "You are " + message;
            this.BMIResultsTextBox.ForeColor = Color.FromName(foreColorName);
            this.BMIResultsTextBox.BackColor = Color.FromName(backColorName);
        }

        private void BMICalculatorForm_Load(object sender, EventArgs e) { }

        /// <summary>
        /// This method handles both ImperialRadioButton and MetricRadioButton checked change events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            this.CalculateBMIButton.Enabled = false;
            this.ClearForm();
            this.HeightTextBox.Enabled = true;
            this.WeightTextBox.Enabled = true;
        }

        /// <summary>
        /// This method handles both HeightTextBox and WeightTextBox text changed events
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void HeightTextBox_TextChanged(object sender, EventArgs e)
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
        private void WeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((this.WeightTextBox.Text == "0") || 
                (this.HeightTextBox.Text == "0"))
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

        private void BMICalculatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This method handles both HeightTextBox and WeightTextBox key press events
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                this.ApplicationMessage("Numeric values only for height.", "BMI Calculator");
                e.Handled = true;
            }
        }
        private void WeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                this.ApplicationMessage("Numeric values only for weight.", "BMI Calculator");
                e.Handled = true;
            }
        }

        /// <summary>
        /// This method handles application message boxes
        /// <param name="message"></param>
        /// <param name="title"></param>
        private void ApplicationMessage(string message, string title)
        {
            MessageBox.Show(message, title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
        }

        /// <summary>
        /// This method handles both HeightTextBox and WeightTextBox click events
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeightTextBox_Click(object sender, EventArgs e)
        {
            this.HeightTextBox.SelectAll();
        }
        private void WeightTextBox_Click(object sender, EventArgs e)
        {
            this.WeightTextBox.SelectAll();
        }
    }
}
