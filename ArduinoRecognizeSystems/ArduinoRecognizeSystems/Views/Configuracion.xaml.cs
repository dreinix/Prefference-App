using ArduinoRecognizeSystems;
using ArduinoRecognizeSystems2.Data;
using ArduinoRecognizeSystems2.Model;
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
    public partial class Configuracion : ContentPage
    {
        private SQLiteAsyncConnection sqlite;
        public Configuracion()
        {
            InitializeComponent();
            sqlite = DependencyService.Get<ILocalData>().GetConnection();
        }
        int[] colors = new int[5] {0,0,0,0,0};
        private async void guardarbtn_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Correcto", "Configuracion guardada", "ok");
            
            Usuario user = new Usuario();
            DBModelConfiguracion[] conf;
            for (int i = 0; i < 5; i++)
            {
                 conf[i] = new DBModelConfiguracion(user.ID, "led", colors[i].ToString(),0,"act");
            }
            

            await Navigation.PopAsync();
        }

        private void bluebtn_Clicked(object sender, EventArgs e)
        {
            colors[0] = 1;
        }

        private void redbtn_Clicked(object sender, EventArgs e)
        {
            colors[1] = 1;
        }

        private void yellowbtn_Clicked(object sender, EventArgs e)
        {
            colors[2] = 1;
        }

        private void greenbtn_Clicked(object sender, EventArgs e)
        {
            colors[3] = 1;
        }
    }
}