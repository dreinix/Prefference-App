using ArduinoRecognizeSystems2.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduinoRecognizeSystems
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            bool isSet = Preferences.Get("IS_SET", false);

            if (isSet == false)
            {
                MainPage = new NavigationPage(new InicioPage());

            }
            else if (isSet == true)
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
