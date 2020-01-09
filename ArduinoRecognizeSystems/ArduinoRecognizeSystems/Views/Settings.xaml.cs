using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduinoRecognizeSystems.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void bluebtn_Clicked(object sender, EventArgs e)
        {

        }

        private void redbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void yellowbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void greenbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void staticbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void blinkbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void ciclebtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void guardarbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}