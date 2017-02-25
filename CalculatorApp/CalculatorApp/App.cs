using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CalculatorApp
{
    public class App : Application
    {
        public App()
        {
            MainPage = new xamlCalculator();
        }

        protected override void OnStart()
        {
            Properties["strOperator"] = "=";
            Properties["strFirstOperand"] = "";
            Properties["strSecondOperand"] = "";
            Properties["strNewEntry"] = "True";

            Properties["strStatus1"] = "";
            Properties["strStatus2"] = "";
            Properties["strStatus3"] = "";
            Properties["strStatus4"] = "";
        }

        protected override void OnSleep()
        {
            // Handle when my app goes to sleep
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
