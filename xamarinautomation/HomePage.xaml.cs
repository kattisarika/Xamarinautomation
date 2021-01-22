using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xamarinautomation
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string ccText = entryCC.Text;
          
            if (ccText.Length < 0)
            {
                await DisplayAlert("Validate CC Result", "Please Enter a number", "OK");
            }
            else if(ccText.Length < 5)
            {
                await DisplayAlert("Validate CC Result", "Wrong", "OK");
            }
            else
            {
                await DisplayAlert("Validate CC Result", "Correct", "OK");
            }
        }
    }
}
