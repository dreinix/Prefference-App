using ArduinoRecognizeSystems;
using Rg.Plugins.Popup.Services;
using System;
using System.Diagnostics;
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
            if (string.IsNullOrEmpty(entClave.Text) || string.IsNullOrEmpty(entNombre.Text) || string.IsNullOrEmpty(entUsuario.Text))
            {
                await DisplayAlert("Error", "Campos vacios", "OK");


            }
            else
            {
                Preferences.Set("IS_SET", true);
                await Navigation.PushAsync(new Configuracion());
            }
            
        }
    }
}