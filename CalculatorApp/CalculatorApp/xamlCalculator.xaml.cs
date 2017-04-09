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
       
            //clsCalcViewModel cvmCalcViewModel = new clsCalcViewModel();
        }

        /* DELETE ME ----------------------------------------------------
        void OnNumberButtonClick(object sender, EventArgs args)
        {
            if (displayLabel.Text == "OVERFLOW")
            {
                displayLabel.Text = "0";
            }

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
        */

        /*
        void OnClearEntryButtonClick(object sender, EventArgs args)
        {
            displayLabel.Text = "0";
        }
        */

        /*
        void OnOperatorButtonClick(object sender, EventArgs args)
        {
            if(displayLabel.Text == "OVERFLOW")
            {
                resetTheInterface();
            }

            bool booOverflow = false;

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

                    try
                    {
                        dblResult = dblFirstOperand * dblSecondOperand;
                    }
                    catch
                    {
                        booOverflow = true;
                        dblResult = -99999.99999;
                    }

                    // who woulda thunk it. No error, it comes back as infinity
                    if (dblResult.ToString() == "Infinity")
                    {
                        booOverflow = true;
                        dblResult = -99999.99999;
                    }

                    break;

                case "\u00F7":
                    // if we haven't loaded a first operand yet, as at app start-up, we'll just multiply by 1
                    if (Application.Current.Properties["strFirstOperand"].ToString() == "")
                    {
                        dblFirstOperand = 1;
                    }
                    else
                    {
                        dblFirstOperand = Convert.ToDouble(Application.Current.Properties["strFirstOperand"]);
                    }

                    try
                    {
                        dblResult = dblFirstOperand / dblSecondOperand;
                    }
                    catch
                    {
                        booOverflow = true;
                        dblResult = -99999.99999;
                    }

                    // who woulda thunk it. No error, it comes back as infinity
                    if (dblResult.ToString() == "Infinity")
                    {
                        booOverflow = true;
                        dblResult = -99999.99999;
                    }
                    
                    break;

                default:
                    dblFirstOperand = -99999.99999;
                    dblResult = -99999.99999;
                    break;

            }

            string strNewStatus = "";

            if (booOverflow)
            {
                displayLabel.Text = "OVERFLOW";
                strNewStatus = "Overflow";

                scrollUpStatusDisplay(strNewStatus);
            }
            else
            {
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

                // Trying to get the Android to keep the display left-justified but it won't
                displayLabel.HorizontalTextAlignment = TextAlignment.End;
                displayLabel.HorizontalOptions = LayoutOptions.FillAndExpand;

                displayLabel.Text = dblResult.ToString();
            }
        }
        */

        void OnStyleButtonClick(object sender, EventArgs args)
        {
            string strText = styButton.Text;
            string newStyle = strText.Substring(strText.Length-1, 1);

            styButton.Text = "Change to style ";
            switch (newStyle)
            {
                case "1":
                    styButton.Text += "2";
                    Resources["numButtonStyle0"] = Resources["numButtonStyle1"];
                    Resources["opButtonStyle0"] = Resources["opButtonStyle1"];
                    Resources["gridStyle0"] = Resources["gridStyle1"];
                    Resources["statusLabelStyle0"] = Resources["statusLabelStyle1"];
                    Resources["displayLabelStyle0"] = Resources["displayLabelStyle1"];
                    break;
                case "2":
                    styButton.Text += "3";
                    Resources["numButtonStyle0"] = Resources["numButtonStyle2"];
                    Resources["opButtonStyle0"] = Resources["opButtonStyle2"];
                    Resources["gridStyle0"] = Resources["gridStyle2"];
                    Resources["statusLabelStyle0"] = Resources["statusLabelStyle2"];
                    Resources["displayLabelStyle0"] = Resources["displayLabelStyle2"];
                    break;
                case "3":
                    styButton.Text += "1";
                    Resources["numButtonStyle0"] = Resources["numButtonStyle3"];
                    Resources["opButtonStyle0"] = Resources["opButtonStyle3"];
                    Resources["gridStyle0"] = Resources["gridStyle3"];
                    Resources["statusLabelStyle0"] = Resources["statusLabelStyle3"];
                    Resources["displayLabelStyle0"] = Resources["displayLabelStyle3"];
                    break;
            }
        }

        /*
        void OnAllClearButtonClick(object sender, EventArgs args)
        {
            resetTheInterface();
        }
        */

        void resetTheInterface()
        {
            Application.Current.Properties["strOperator"] = "=";
            Application.Current.Properties["strFirstOperand"] = "";
            Application.Current.Properties["strSecondOperand"] = "";
            Application.Current.Properties["strNewEntry"] = "True";

            displayLabel.Text = "0";
        }

        /*
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
        */
    }
}
