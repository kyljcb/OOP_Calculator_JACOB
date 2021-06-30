using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Calculator_JACOB
{
    class Class1
    {
        double result_Value = 0;
        string operation_Performed = "";
        bool operation_Pressed = false;
        bool equal_Check = false;

        public double Result_Value { get => result_Value; set => result_Value = value; }
        public string Operation_Performed { get => operation_Performed; set => operation_Performed = value; }
        public bool Operation_Pressed { get => operation_Pressed; set => operation_Pressed = value; }
        public bool Equal_Check { get => equal_Check; set => equal_Check = value; }

        public void Solve()
        {
            // code block for the calculation part. 
            switch (Operation_Performed)
            {
                case "+":
                    resultBox.Text = (Result_Value + Double.Parse(resultBox.Text)).ToString();
                    break;
                case "-":
                    resultBox.Text = (Result_Value - Double.Parse(resultBox.Text)).ToString();
                    break;
                case "x":
                    resultBox.Text = (Result_Value * Double.Parse(resultBox.Text)).ToString();
                    break;
                case "÷":
                    resultBox.Text = (Result_Value / Double.Parse(resultBox.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
        }


    }
}
