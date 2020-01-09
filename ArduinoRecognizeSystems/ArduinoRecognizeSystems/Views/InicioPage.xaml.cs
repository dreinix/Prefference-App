using ArduinoRecognizeSystems;
using ArduinoRecognizeSystems.Views;
using ArduinoRecognizeSystems2.Data;
using ArduinoRecognizeSystems2.Model;
using Rg.Plugins.Popup.Services;
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

        [Obsolete]
        private void signinbtn_Clicked(object sender, EventArgs e)
        {          
        
             PopupNavigation.PushAsync(new PopUpForm());
        }

        [Obsolete]
        private void signup_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new PopUpRegistro());
        }

        private async void confirmarbtn_Clicked(object sender, EventArgs e)
        {
            
            
        }
    }
}