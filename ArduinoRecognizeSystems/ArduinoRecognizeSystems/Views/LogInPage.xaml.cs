using ArduinoRecognizeSystems2.Data;
using ArduinoRecognizeSystems2.Model;
using Plugin.Fingerprint;
using SQLite;
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
    public partial class LogInPage : ContentPage
    {

        private SQLiteAsyncConnection sqlite;
        public LogInPage()
        {
            InitializeComponent();
            sqlite = DependencyService.Get<ILocalData>().GetConnection();
        }


        private async void btAuth_ClickedAsync(object sender, EventArgs e)
        {
            Usuario user = new Usuario(txtUser.Text, txtPass.Text);
            if (user.LogIn())
            {
                TestLabel.Text = "¡Autenticado!";
                
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
                TestLabel.Text = "Fail";
            }
            /*
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync("Toca el Sensor");
                
                int rowVal=auth.GetHashCode();

                await DisplayAlert("Conversion", rowVal.ToString(), "Next");
                
                if (auth.Authenticated)
                {
                    TestLabel.Text = "¡Autenticado!";
                }
                else
                {
                    TestLabel.Text = "Huella digital no reconocida.";
                }
            }
            else
            {
                await DisplayAlert("ooh oh", "Su telefono no tiene lector de huellas", "ok");
            }*/
        }
    }
}