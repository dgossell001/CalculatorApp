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
            // Add the digit pushed to the right-most position of the display
            Button btn = (Button)sender;

            string strNumberDigit = btn.Text.Trim();
            string strDisplay = displayLabel.Text.Trim();

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

            displayLabel.Text = strDisplay.Trim();
        }

        void OnClearEntryButtonClick(object sender, EventArgs args)
        {
            displayLabel.Text = "0";
        }

        void OnOperatorButtonClick(object sender, EventArgs args)
        {
            displayLabel.Text = "99999.9999";
        }
    }
}
