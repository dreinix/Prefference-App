using ArduinoRecognizeSystems2.Model;
using ArduinoRecognizeSystems2.Views;
using Rg.Plugins.Popup.Pages;
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
    public partial class PopUpRegistro : PopupPage
    {
        public PopUpRegistro()
        {
            InitializeComponent();
        }

        private async void confirmarbtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nametxt.Text) || string.IsNullOrEmpty(usertxt.Text) || string.IsNullOrEmpty(clavetxt.Text))
            {
                await DisplayAlert("Error", "Campos vacios", "OK");

            }
            else
            {

                Usuario user = new Usuario(usertxt.Text, clavetxt.Text, nametxt.Text);
                if (user.Registrar())
                {
                    if (user.LogIn())
                    {
                        if (user.BindDevide())
                        {
                            this.IsVisible = false;
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