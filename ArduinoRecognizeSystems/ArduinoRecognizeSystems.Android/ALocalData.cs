using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using ArduinoRecognizeSystems2.Data;
using ArduinoRecognizeSystems.Droid;

[assembly: Dependency(typeof(ALocalData))]
namespace ArduinoRecognizeSystems.Droid
{
    public class ALocalData : ILocalData
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var DocPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(DocPath, "ARSLocalData.db3");
            return new SQLiteAsyncConnection(path);
        }
        public ALocalData()
        {

        }
    }
}