using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Calculator_JACOB
{
    public partial class Form1 : Form
    {
        double result_Value = 0;
        string operation_Performed = "";
        bool operation_Pressed = false;
        bool equal_Check = false;
       
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button_Click(object sender, EventArgs e)
        {
            // clears the textbox if there is no text or if an operation is pressed. 
            if ((resultBox.Text == "") || (operation_Pressed))
                resultBox.Clear();

         operation_Pressed = false;

            Button button = (Button)sender;
            {
                // code block for preventing repeating decimal points
                if (button.Text == ".")
                {
                    if (!resultBox.Text.Contains("."))
                        resultBox.Text = resultBox.Text + "."; 
                }
                else
                {
                    resultBox.Text = resultBox.Text + button.Text;
                }
            }
                 // code block so that when a number is pressed after pressing equals, resultbox would be cleared.
                if (equal_Check == true)
                {
                    resultBox.Clear();
                    equal_Check = false;
                    resultBox.Text = resultBox.Text + button.Text;
                }
        }
        private void operator_Click(object sender, EventArgs e) 
        {
            try // try catch so program won't crash if an operator button is pressed first
            {
                Button button = (Button)sender;
                
                // code block so that operator buttons would perform themselves if user decides to use multiple operators before pressing the equal button.
                if (result_Value != 0)
                {
                    button_Equals.PerformClick(); // essentially performs the equal button 
                    operation_Pressed = true;
                    operation_Performed = button.Text;
                }
                else
                {
                    operation_Performed = button.Text;
                    result_Value = Double.Parse(resultBox.Text);
                    operation_Pressed = true;
                }
            }
            catch { }
        }
        private void button_Equals_Click(object sender, EventArgs e)
        {
            // code block for the calculation part. 
            switch(operation_Performed)
            {
                case "+":
                    resultBox.Text = (result_Value + Double.Parse(resultBox.Text)).ToString();
                    break;
                case "-":
                    resultBox.Text = (result_Value - Double.Parse(resultBox.Text)).ToString();
                    break;
                case "x":
                    resultBox.Text = (result_Value * Double.Parse(resultBox.Text)).ToString();
                    break;
                case "÷":
                    resultBox.Text = (result_Value / Double.Parse(resultBox.Text)).ToString();
                    break;
                default:
                    break;
            }
                // resets the values
                result_Value = Double.Parse(resultBox.Text);
                operation_Performed = "";
                equal_Check = true;

                // code block for undefined numbers.
                if ((resultBox.Text == "∞") || (resultBox.Text == "NaN"))
                        resultBox.Text = "Undefined";
        }
        private void button_Clear_Click(object sender, EventArgs e)
        {
                // button to reset the value of the result box. 
                resultBox.Text = "";
                result_Value = 0;
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
                // button that acts as the backspace key
                if (resultBox.TextLength > 0)
                    resultBox.Text = resultBox.Text.Remove(resultBox.TextLength - 1);
        }
        private void negativeButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // codeblock for the negative button. 
            if (!resultBox.Text.Contains("-") && resultBox.Text != "0")
            { 
                resultBox.Text = resultBox.Text.Insert(0, "-"); 
            }
            else
            {
                if (resultBox.Text != "0")
                {
                    resultBox.Text = resultBox.Text.Remove(0, 1);
                }
            }
        }
    }
}
