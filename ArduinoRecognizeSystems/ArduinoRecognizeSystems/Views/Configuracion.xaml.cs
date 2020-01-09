using ArduinoRecognizeSystems;
using ArduinoRecognizeSystems2.Data;
using ArduinoRecognizeSystems2.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduinoRecognizeSystems2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracion : ContentPage
    {
<<<<<<<<< Temporary merge branch 1
        
        public Configuracion()
        {
            InitializeComponent();
            
=========
        private SQLiteAsyncConnection sqlite;
        public Configuracion()
        {
            InitializeComponent();
            sqlite = DependencyService.Get<ILocalData>().GetConnection();
>>>>>>>>> Temporary merge branch 2
        }
        int[] colors = new int[5] {0,0,0,0,0};
        private async void guardarbtn_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Correcto", "Configuracion guardada", "ok");
<<<<<<<<< Temporary merge branch 1
            Application.Current.MainPage = new MainPage();
        }

        private void greenbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void yellowbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void redbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void bluebtn_Clicked(object sender, EventArgs e)
        {

        }

        private void blinkbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void staticbtn_Clicked(object sender, EventArgs e)
        {

        }

        private void ciclebtn_Clicked(object sender, EventArgs e)
        {

=========
            
            Usuario user = new Usuario();
            DBModelConfiguracion[] conf;
            for (int i = 0; i < 5; i++)
            {
                greenbtn.BackgroundColor = Color.Green;
            }
            

            await Navigation.PopAsync();
>>>>>>>>> Temporary merge branch 2
        }

        private void blinkbtn_Clicked(object sender, EventArgs e)
        {
            mod = 2;
            blinkbtn.TextColor = Color.Black;
            staticbtn.TextColor = Color.White;
            ciclebtn.TextColor = Color.White;
        }
        private void staticbtn_Clicked(object sender, EventArgs e)
        {
            mod = 1;
            blinkbtn.TextColor = Color.White;
            staticbtn.TextColor = Color.Black;
            ciclebtn.TextColor = Color.White;
        }
        private void ciclebtn_Clicked(object sender, EventArgs e)
        {
            mod = 3;
            blinkbtn.TextColor = Color.White;
            staticbtn.TextColor = Color.White;
            ciclebtn.TextColor = Color.Black;

        }
    }
}