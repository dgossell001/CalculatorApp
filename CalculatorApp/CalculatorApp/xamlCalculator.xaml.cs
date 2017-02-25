using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CalculatorApp
{
    public partial class xamlCalculator : ContentPage
    {
        public xamlCalculator()
        {
            InitializeComponent();
        }

        void OnNumberButtonClick(object sender, EventArgs args)
        {
            Button btn = (Button)sender;

            string strNumberDigit = btn.Text.Trim();
            string strDisplay = displayLabel.Text.Trim();

            // if this is a new entry (we just displayed a calculation result)
            //  then set the display value to zero so we start entering a brand new number
            bool booNewEntry = Convert.ToBoolean(Application.Current.Properties["strNewEntry"].ToString());
            if (booNewEntry) { strDisplay = "0"; }

            // if the display is already zero, dump it so we don't end up with a leading zero
            // unless we are entering a decimal point, then leave the leading zero
            if (strDisplay == "0" && strNumberDigit != ".") { strDisplay = ""; }

            if(strDisplay.Length < 15)
            {
                if (strNumberDigit != "." || strDisplay.IndexOf(".") == -1)
                {
                    strDisplay += strNumberDigit.Trim();
                }
                
            }

            // we have a digit so it's not a new entry anymore
            Application.Current.Properties["strNewEntry"] = "False";
            displayLabel.Text = strDisplay.Trim();
        }

        void OnClearEntryButtonClick(object sender, EventArgs args)
        {
            displayLabel.Text = "0";
        }

        void OnOperatorButtonClick(object sender, EventArgs args)
        {
            Button btn = (Button)sender;

            string strNextOperator = btn.Text;
            string strOperator = Application.Current.Properties["strOperator"].ToString();

            double dblFirstOperand;
            double dblSecondOperand = Convert.ToDouble(displayLabel.Text);

            double dblResult;

            switch (strOperator)
            {
                case "=":
                    dblFirstOperand = dblSecondOperand;
                    dblResult = dblSecondOperand;
                    break;

                case "+":
                    // if we haven't loaded a first operand yet, as at app start-up, we'll use 0 as our first number to add
                    if (Application.Current.Properties["strFirstOperand"].ToString()=="")
                    {
                        dblFirstOperand = 0;
                    }
                    else
                    {
                        dblFirstOperand =  Convert.ToDouble(Application.Current.Properties["strFirstOperand"]);
                    }

                    dblResult = dblFirstOperand + dblSecondOperand;
                    break;

                case "-":
                    // if we haven't loaded a first operand yet, as at app start-up, we'll use 0 as our first number to add
                    if (Application.Current.Properties["strFirstOperand"].ToString() == "")
                    {
                        dblFirstOperand = 0;
                    }
                    else
                    {
                        dblFirstOperand = Convert.ToDouble(Application.Current.Properties["strFirstOperand"]);
                    }

                    dblResult = dblFirstOperand - dblSecondOperand;
                    break;

                case "X":
                    // if we haven't loaded a first operand yet, as at app start-up, we'll just multiply by 1
                    if (Application.Current.Properties["strFirstOperand"].ToString() == "")
                    {
                        dblFirstOperand = 1;
                    }
                    else
                    {
                        dblFirstOperand = Convert.ToDouble(Application.Current.Properties["strFirstOperand"]);
                    }

                    dblResult = dblFirstOperand * dblSecondOperand;
                    break;

                default:
                    dblFirstOperand = -99999.99999;
                    dblResult = -99999.99999;
                    break;

            }

            string strNewStatus = "";
            if (strOperator != "=")
            {
                strNewStatus += dblFirstOperand.ToString()
                + " " + strOperator + " "
                + dblSecondOperand.ToString()
                + " = " + dblResult.ToString();

                scrollUpStatusDisplay(strNewStatus);
            }

            Application.Current.Properties["strOperator"] = strNextOperator;
            Application.Current.Properties["strFirstOperand"] = dblResult.ToString();
            Application.Current.Properties["strNewEntry"] = "True";

            displayLabel.Text = dblResult.ToString();
        }

        void resetTheInterface(object sender, EventArgs args)
        {
            Application.Current.Properties["strOperator"] = "=";
            Application.Current.Properties["strFirstOperand"] = "";
            Application.Current.Properties["strSecondOperand"] = "";
            Application.Current.Properties["strNewEntry"] = "True";

            displayLabel.Text = "0";
        }

        void scrollUpStatusDisplay(string strNewStatus)
        {
            Application.Current.Properties["strStatus1"] = Application.Current.Properties["strStatus2"];
            Application.Current.Properties["strStatus2"] = Application.Current.Properties["strStatus3"];
            Application.Current.Properties["strStatus3"] = Application.Current.Properties["strStatus4"];
            Application.Current.Properties["strStatus4"] = strNewStatus;

            statusLabel.Text = Application.Current.Properties["strStatus1"] + "\n"
                + Application.Current.Properties["strStatus2"] + "\n"
                + Application.Current.Properties["strStatus3"] + "\n"
                + Application.Current.Properties["strStatus4"];
        }
    }
}
