using ArduinoRecognizeSystems2.Model;
using ArduinoRecognizeSystems2.Views;
using Plugin.Fingerprint;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArduinoRecognizeSystems
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {   
        
        public MainPage()
        {
            InitializeComponent();
            if (Usuario.GetLocalUser() == null)
            {
                //Application.Current.MainPage = new InicioPage();
                Navigation.PushAsync(new InicioPage());
            } 
        }

        [Obsolete]
        private async void settingbtn_Clicked(object sender, EventArgs e)
        {
            if (!await AutAsync())
            {
                await DisplayAlert("Error", "Reconocimiento fallido", "ok");
                return;
            }
            await Navigation.PushAsync(new Configuracion());
        }
        private async Task<bool> AutAsync()
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync("Toca el Sensor");

                int rowVal = auth.GetHashCode();
                if (auth.Authenticated)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                await DisplayAlert("ooh oh", "Su telefono no tiene lector de huellas", "ok");
                return false;
            }
        }
        private async Task sendDataAsync()
        {
            try
            {
                if (!await AutAsync())
                {
                    await DisplayAlert("Error", "Reconocimiento fallido", "ok");
                    return;
                }
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress iPAddress = IPAddress.Parse("192.168.1.112");
                IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 8888);
                Usuario LocalUser = Usuario.GetLocalUser();
                string[] msg = new string[5];
                List<UserConfiguration> UserConf = LocalUser.GetConfiguration();
                for (int i = 0; i < UserConf.Count; i++)
                {
                    UserConfiguration uc = UserConf[i];
                    string code = "2_";
                    code += i.ToString() + "_" + uc.Value;
                    msg[i] = code;
                }
                UserConfiguration ucm = UserConf[4];
                string codem = "1_";
                codem += ucm.Value;
                msg[4] = codem;

                foreach (string command in msg)
                {
                    byte[] sendBuffer = Encoding.ASCII.GetBytes(command);
                    socket.SendTo(sendBuffer, iPEndPoint);
                } 
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        private async void SendButtom_Clicked(object sender, EventArgs e)
        {
            await sendDataAsync();
        }

        private async void btLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }
    }
}
