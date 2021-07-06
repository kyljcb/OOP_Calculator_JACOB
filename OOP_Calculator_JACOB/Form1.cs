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
        Class1 c = new Class1();
       
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
            if ((resultBox.Text == "") || (c.Operation_Pressed))
            {
                resultBox.Clear();
                c.Operation_Pressed = false;
            }

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
                if (c.Equal_Check == true)
                {
                    resultBox.Clear();
                c.Equal_Check = false;
                    resultBox.Text = resultBox.Text + button.Text;
                }
        }
        private void operator_Click(object sender, EventArgs e) 
        {
            try // try catch so program won't crash if an operator button is pressed first
            {
                Button button = (Button)sender;  
                // code block so that operator buttons would perform themselves if user decides to use multiple operators before pressing the equal button.
                if (c.Result_Value != 0)
                {
                    button_Equals.PerformClick(); // essentially performs the equal button 
                    c.Operation_Pressed = true;
                    c.Operation_Performed = button.Text;
                }
                else
                {
                    c.Operation_Performed = button.Text;
                    c.Result_Value = Double.Parse(resultBox.Text);
                    c.Operation_Pressed = true;
                }
            }
            catch { }
        }
        private void button_Equals_Click(object sender, EventArgs e)
        {
            c.RBox = resultBox.Text;
            c.Solve();
            resultBox.Text = c.RBox;
            c.resetValues();

            // code block for undefined numbers.
                if ((resultBox.Text == "∞") || (resultBox.Text == "NaN"))
                        resultBox.Text = "Undefined";
        }
        private void button_Clear_Click(object sender, EventArgs e)
        {
            c.clear();
            resultBox.Text = c.RBox;
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            c.delete();
            resultBox.Text = c.RBox;
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
