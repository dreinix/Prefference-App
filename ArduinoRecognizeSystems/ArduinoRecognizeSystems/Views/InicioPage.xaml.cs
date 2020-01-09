using ArduinoRecognizeSystems;
using ArduinoRecognizeSystems2.Data;
using ArduinoRecognizeSystems2.Model;
using SQLite;
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
                Usuario user = new Usuario(entUsuario.Text, entClave.Text, entNombre.Text);
                if (user.Registrar())
                {
                    if (user.LogIn())
                    {
                        if (user.BindDevide())
                        {
                            await Navigation.PushAsync(new Configuracion());
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo vincular la cuenta al dispositivo", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo conectar al servidor", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo registrar el usuario, favor de revisar los datos y su conexión a internet", "OK");
                }
                
            }
            
        }
    }
}