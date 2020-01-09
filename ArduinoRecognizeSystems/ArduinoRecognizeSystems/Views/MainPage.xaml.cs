using ArduinoRecognizeSystems2.Model;
using ArduinoRecognizeSystems2.Views;
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
            await Navigation.PushAsync(new Configuracion());
        }

        private void sendData()
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress iPAddress = IPAddress.Parse("192.168.0.112");
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

                    byte[] recBuffer = new byte[1024];
                    int bytesrec = socket.Receive(recBuffer);
                } 
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        private void SendButtom_Clicked(object sender, EventArgs e)
        {
            sendData();
        }

        private async void btLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInPage());
        }
    }
}
