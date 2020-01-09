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
            this.IsVisible = false;
            await Navigation.PushAsync(new MainPage());
        }
    }
}