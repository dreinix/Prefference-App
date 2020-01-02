using ArduinoRecognizeSystems;
using ArduinoRecognizeSystems.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduinoRecognizeSystems2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }

        private async void signinbtn_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("IS_SET", true);
            Debug.WriteLine("Preferece IS_SET, ha cambiado a TRUE");
            await Navigation.PushAsync(new MainPage());
        }

        private void signup_Clicked(object sender, EventArgs e)
        {
            entClave.IsVisible = true;
            entUsuario.IsVisible = true;
            entNombre.IsVisible = true;
            confirmarbtn.IsVisible = true;
        }

        private async void confirmarbtn_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new PopUpSettings());
        }
    }
}