using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    public partial class FrmCalculator : Form
    {
        CalculatorClass cal;  
        double num1, num2;

        public FrmCalculator ()
        {
            InitializeComponent();
            cal = new CalculatorClass();  
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                
                num1 = Convert.ToDouble(txtBoxInput1.Text);
                num2 = Convert.ToDouble(txtBoxInput2.Text);

              
                switch (cbOperator.SelectedItem.ToString())
                {
                    case "+":
                        cal.CalculateEvent += new CalculatorClass.Formula<double>(cal.GetSum);
                        break;
                    case "-":
                        cal.CalculateEvent += new CalculatorClass.Formula<double>(cal.GetDifference);
                        break;
                    case "*":
                        cal.CalculateEvent += new CalculatorClass.Formula<double>(cal.GetProduct);
                        break;
                    case "/":
                        cal.CalculateEvent += new CalculatorClass.Formula<double>(cal.GetQuotient);
                        break;
                }

                
                lblDisplayTotal.Text = cal.PerformCalculation(num1, num2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

