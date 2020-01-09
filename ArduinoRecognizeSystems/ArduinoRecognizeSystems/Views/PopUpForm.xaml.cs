using ArduinoRecognizeSystems2.Model;
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
    public partial class PopUpForm : PopupPage
    {
        public PopUpForm()
        {
            InitializeComponent();
        }

        private async void ingresar_Clicked(object sender, EventArgs e)
        {
            
            string user = usertxt.Text, pass = clavetxt.Text;

            Usuario us = new Usuario(user, pass);
            if (us.LocalLogin())
            {
                this.IsVisible = false;
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                if (us.LogIn())
                {
                    bool ans = await DisplayAlert("Inconveniente", "Se ha encontrado otra cuenta vinculada, desea vincularse aquí?", "si","no");
                    if (ans)
                    {
                        if (us.BindDevide())
                        {
                            this.IsVisible = false;
                            await Navigation.PushAsync(new MainPage());
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se pudo vincular la cuenta", "OK");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se puede iniciar sesion", "OK");
                }
                
            }
            
        }
    }
}