using ArduinoRecognizeSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduinoRecognizeSystems2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracion : ContentPage
    {
        
        public Configuracion()
        {
            InitializeComponent();
            
        }

        private async void guardarbtn_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Correcto", "Configuracion guardada", "ok");
            Application.Current.MainPage = new MainPage();
        }

        private void greenbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void yellowbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void redbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void bluebtn_Clicked(object sender, EventArgs e)
        {

        }

        private void blinkbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void staticbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void ciclebtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}