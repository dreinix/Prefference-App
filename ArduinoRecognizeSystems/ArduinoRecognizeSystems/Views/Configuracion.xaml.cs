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
            await Navigation.pop(new MainPage());
        }
    }
}