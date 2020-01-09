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
        private SQLiteAsyncConnection sqlite;
        Usuario LocalUser;
        public Configuracion()
        {
            InitializeComponent();
            sqlite = DependencyService.Get<ILocalData>().GetConnection();
            LocalUser = Usuario.GetLocalUser();
            List<UserConfiguration> UserConf = LocalUser.GetConfiguration();
            Button[] buttons = new Button[4] { bluebtn, redbtn, yellowbtn, greenbtn };
            for (int i = 0; i < UserConf.Count; i++)
            {
                UserConfiguration uc = UserConf[i];
                if (uc.Value == "-1")
                {
                    buttons[i].BackgroundColor = Color.White;
                }
            }

        }
        int[] colors = new int[4] { 1, 1, 1, 1 };
        
        private async void guardarbtn_Clicked(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                string err = ex.Message;
                await DisplayAlert("Error", "No se pudo guardar la configuración", "ok");
            }
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ARSLocalData.db3");
            SQLiteConnection sQLiteConnection = new SQLiteConnection(dbpath);
            //user.GetConfiguration();
            UserConfiguration[] conf = new UserConfiguration[4];
            LocalUser.CleanConfiguration();
            for (int i = 0; i < 4; i++)
            {
                 conf[i] = new UserConfiguration(LocalUser.ID, "led", colors[i].ToString(),0,"act");
            }
            foreach (UserConfiguration item in conf)
            {
                item.SaveConfig(LocalUser);
            }
            await DisplayAlert("Correcto", "Configuracion guardada", "ok");
            await Navigation.PopAsync();
        }

        private void bluebtn_Clicked(object sender, EventArgs e)
        {   
            int val = colors[0]*-1;
            colors[0] = val;
            if (val == 1)
                bluebtn.BackgroundColor = Color.Blue;
            else
                bluebtn.BackgroundColor = Color.White;
        }

        private void redbtn_Clicked(object sender, EventArgs e)
        {   
            int val = colors[1] * -1;
            colors[1] = val;
            if (val == 1)
                redbtn.BackgroundColor = Color.Red;
            else
                redbtn.BackgroundColor = Color.White;
        }

        private void yellowbtn_Clicked(object sender, EventArgs e)
        {   
            int val = colors[2] * -1;
            colors[2] = val;
            if (val == 1)
                yellowbtn.BackgroundColor = Color.Yellow;
            else
                yellowbtn.BackgroundColor = Color.White;
        }

        private void greenbtn_Clicked(object sender, EventArgs e)
        {   
            int val = colors[3] * -1;
            colors[3] = val;
            if (val == 1)
            {
                greenbtn.BackgroundColor = Color.Green;
            }
            else
                greenbtn.BackgroundColor = Color.White;
        }
    }
}