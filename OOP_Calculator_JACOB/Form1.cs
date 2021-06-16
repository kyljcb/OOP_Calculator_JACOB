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
            if ((textBox1.Text == "") || (operation_Pressed))
                textBox1.Clear();
            operation_Pressed = false;

            Button button = (Button)sender;

            {
                if (button.Text == ".")
                {
                    if (!textBox1.Text.Contains("."))

                        textBox1.Text = textBox1.Text + ".";
                }

                else
                {
                    textBox1.Text = textBox1.Text + button.Text;
                }

                //if (textBox1.Text.Contains())
                //{
                //    if (textBox1.Text.Contains("÷"))
                //        textBox1.Text = "Undefinded";
                //}

            }


            if (equal_Check == true)
            {
                textBox1.Clear();
                equal_Check = false;
                textBox1.Text = textBox1.Text + button.Text;
            }

        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result_Value != 0)
            {
                button_Equals.PerformClick(); // learned performclick function
                operation_Pressed = true;
                operation_Performed = button.Text; 
            }

            else
            {
                operation_Performed = button.Text;
                result_Value = Double.Parse(textBox1.Text);
                operation_Pressed = true;
            }

            if (textBox1.Text == "0")
            {
                if (operation_Performed == "÷")
                    textBox1.Text = "Undefined";
            }
             
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {

            switch(operation_Performed)
            {
                case "+":
                    textBox1.Text = (result_Value + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (result_Value - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "x":
                    textBox1.Text = (result_Value * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "÷":
                    textBox1.Text = (result_Value / Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
            result_Value = Double.Parse(textBox1.Text);
            operation_Performed = "";

            equal_Check = true;
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            result_Value = 0;
        }

  
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.TextLength - 1);
        }

    }
}
