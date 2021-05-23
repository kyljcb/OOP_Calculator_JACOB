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
        int result_Value = 0;
        string operation_Performed = "";
        bool operation_Pressed = false;

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

            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
           
        }

        private void operator_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            operation_Performed = button.Text;
            result_Value = int.Parse(textBox1.Text);
            operation_Pressed = true;
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {
            switch(operation_Performed)
            {
                case "+":
                    textBox1.Text = (result_Value + int.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (result_Value - int.Parse(textBox1.Text)).ToString();
                    break;
                case "x":
                    textBox1.Text = (result_Value * int.Parse(textBox1.Text)).ToString();
                    break;
                case "÷":
                    textBox1.Text = (result_Value / int.Parse(textBox1.Text)).ToString();
                    break;

                    operation_Pressed = false;

            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }
    }
}
