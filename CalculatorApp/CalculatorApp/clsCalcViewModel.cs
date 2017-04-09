using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculatorApp
{
    public class clsCalcViewModel : INotifyPropertyChanged
    {
        // constructors
        public clsCalcViewModel()
        {
            // create commands linked to the ICommand interfaces
            CommandEnterDigit = new Command<string>(
                execute: (string strDigit) =>
                {
                    updateDisplayText(strDigit);
                });
            CommandEnterOperator = new Command<string>(
                execute: (string strOperator) =>
                {
                    performOperation(strOperator);
                });
            CommandClearDisplay = new Command(
                execute: () =>
                {
                    strDisplayText = "0";
                });
            CommandClearAll = new Command(
                execute: () =>
                {
                    clearAll();
                });
        }

        // events
        public event PropertyChangedEventHandler PropertyChanged;

        // private backing properties
        private string displayText = "0";
        private double dblFirstOperand = 0;
        private double dblSecondOperand = 0;
        private string strOperator = "=";
        private string statusText;
        private string[] strStatusLines = new string[4];
        private bool booMakingNewEntry = true;
        private bool booOverflow = false;

        // public properties
        public string strDisplayText
        {
            private set
            {
                if (displayText != value)
                {
                    displayText = value;

                    PropertyChangedEventHandler hndDisplayChanged = PropertyChanged;
                    if(hndDisplayChanged != null)
                    {
                        hndDisplayChanged(this, new PropertyChangedEventArgs("strDisplayText"));
                    }
                }
            }

            get { return displayText; }
        }

        public string strStatusText
        {
            private set
            {
                if (statusText != value)
                {
                    statusText = value;

                    PropertyChangedEventHandler hndStatusChanged = PropertyChanged;
                    if (hndStatusChanged != null)
                    {
                        hndStatusChanged(this, new PropertyChangedEventArgs("strStatusText"));
                    }
                }
            }

            get { return statusText; }
        }

        // methods
        // internal private method
        private void updateDisplayText(string strDigit)
        {
            if (strDisplayText == "OVERFLOW")
            {
                strDisplayText = "0";
            }

            // if this is a new entry (we just displayed a calculation result)
            //  then set the display value to zero so we start entering a brand new number
            if (booMakingNewEntry) { strDisplayText = "0"; }

            // if the display is already zero, dump it so we don't end up with a leading zero
            // unless we are entering a decimal point, then leave the leading zero
            if (strDisplayText == "0" && strDigit != ".") { strDisplayText = ""; }

            if (strDisplayText.Length < 15)
            {
                if (strDigit != "." || strDisplayText.IndexOf(".") == -1)
                {
                    strDisplayText += strDigit;
                }

            }

            booMakingNewEntry = false;
        }

        private void performOperation(string strNextOperator)
        {
            double dblResult;

            if (strDisplayText == "OVERFLOW")
            {
                strDisplayText = "0";
            }

            booOverflow = false;
            dblSecondOperand = Convert.ToDouble(strDisplayText);

            switch (strOperator)
            {
                case "=":
                    dblFirstOperand = dblSecondOperand;
                    dblResult = dblSecondOperand;
                    break;

                case "+":
                    dblResult = dblFirstOperand + dblSecondOperand;
                    break;

                case "-":
                    dblResult = dblFirstOperand - dblSecondOperand;
                    break;

                case "X":
                    try
                    {
                        dblResult = dblFirstOperand * dblSecondOperand;
                    }
                    catch
                    {
                        booOverflow = true;
                        dblResult = 0;
                    }

                    // who woulda thunk it. No error, it comes back as infinity
                    if (dblResult.ToString() == "Infinity" || dblResult.ToString() == "-Infinity")
                    {
                        booOverflow = true;
                        dblResult = 0;
                    }

                    break;

                case "\u00F7":
                    try
                    {
                        dblResult = dblFirstOperand / dblSecondOperand;
                    }
                    catch
                    {
                        booOverflow = true;
                        dblResult = 0;
                    }

                    // who woulda thunk it. No error, it comes back as infinity
                    if (dblResult.ToString() == "Infinity" || dblResult.ToString() == "-Infinity")
                    {
                        booOverflow = true;
                        dblResult = 0;
                    }

                    break;


                default:
                    // we shouldn't ever get this, just put it in so compiler wouldn't think the variable could be unassigned
                    dblResult = 0;
                    break;
            }

            string strNewStatus = "";

            if (booOverflow)
            {
                strDisplayText = "OVERFLOW";
                strNewStatus = "Overflow";

                dblResult = 0;
                dblSecondOperand = 0;
            }
            else
            {
                if (strOperator != "=")
                {
                    strNewStatus += dblFirstOperand.ToString()
                    + " " + strOperator + " "
                    + dblSecondOperand.ToString()
                    + " = " + dblResult.ToString();
                }

                strDisplayText = dblResult.ToString();
            }

            // get ready for next entry or operator
            dblFirstOperand = dblResult;
            if (strOperator != "=") { scrollUpStatusDisplay(strNewStatus); }
            strOperator = strNextOperator;
            booMakingNewEntry = true;
        }

        private void clearAll()
        {
            strDisplayText = "0";
            dblFirstOperand = 0;
            dblSecondOperand = 0;
            strOperator = "=";
            booMakingNewEntry = true;
    }

        private void scrollUpStatusDisplay(string strNewStatus)
        {
            strStatusLines[3] = strStatusLines[2];
            strStatusLines[2] = strStatusLines[1];
            strStatusLines[1] = strStatusLines[0];
            strStatusLines[0] = strNewStatus;

            string strMyStatus = "";
            for (int i = 3; i > -1; i--)
            {
                strMyStatus += strStatusLines[i];
                if (i > 0) { strMyStatus += "\n"; }
            }

            strStatusText = strMyStatus;
        }

        public ICommand CommandEnterDigit { private set; get; }
        public ICommand CommandEnterOperator { private set; get; }
        public ICommand CommandClearDisplay { private set; get; }
        public ICommand CommandClearAll { private set; get; }
    }
}
