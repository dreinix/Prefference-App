using Plugin.Fingerprint;
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
        public LogInPage()
        {
            InitializeComponent();
        }


        private async Task BTLog_Clicked(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync("Toca el Sensor");
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
                Console.WriteLine("No compatible");
            }
        }
    }
}