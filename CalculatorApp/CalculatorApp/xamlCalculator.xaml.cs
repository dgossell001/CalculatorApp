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
    }
}
