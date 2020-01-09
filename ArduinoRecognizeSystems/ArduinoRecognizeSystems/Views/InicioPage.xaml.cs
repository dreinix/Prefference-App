using ArduinoRecognizeSystems;
using ArduinoRecognizeSystems2.Data;
using ArduinoRecognizeSystems2.Model;
using Rg.Plugins.Popup.Services;
using SQLite;
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
        private SQLiteAsyncConnection sqlite;
        public InicioPage()
        {
            InitializeComponent();
            sqlite = DependencyService.Get<ILocalData>().GetConnection();
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



                Usuario user = new Usuario(entNombre.Text, entClave.Text);
                if (user.LogIn())
                {
                    if (user.CreateLocalData(sqlite))
                    {
                        await DisplayAlert("DataSaved", "Se ha vinculado el usuario al teléfono correctamente", "ok");
                    }
                    else
                    {
                        await DisplayAlert("DataSaved", "No se ha podido vincular el usuario", "ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se ha podido vincular el usuario", "ok");
                }

                await Navigation.PushAsync(new Configuracion());
            }

            

        }
    }
}