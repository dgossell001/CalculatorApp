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

            string strNumberName = btn.ToString().Substring(0,3);
            string strNumberDigit = null;

            if (btn == oneButton) { strNumberDigit = "1"; }
            if (btn == twoButton) { strNumberDigit = "2"; }
            if (btn == thrButton) { strNumberDigit = "3"; }
            if (btn == fouButton) { strNumberDigit = "4"; }
            if (btn == fivButton) { strNumberDigit = "5"; }
            if (btn == sixButton) { strNumberDigit = "6"; }
            if (btn == sevButton) { strNumberDigit = "7"; }
            if (btn == eigButton) { strNumberDigit = "8"; }
            if (btn == ninButton) { strNumberDigit = "9"; }
            if (btn == zerButton) { strNumberDigit = "0"; }
            if (btn == decButton) { strNumberDigit = "."; }

            string strDisplay = displayLabel.Text.Trim();

            // if the display is already zero, dump it so we don't end up with a leading zero
            if (strDisplay == "0") { strDisplay = ""; }

            if(strDisplay.Length < 15)
            {
                if(strNumberDigit != "." || strDisplay.IndexOf(".") == 0 )
                {
                    strDisplay += strNumberDigit.Trim();
                }
                
            }

            displayLabel.Text = strDisplay;
        }
    }
}
