using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace ArduinoRecognizeSystems2.Model
{
    class DBModelConfiguracion
    {
        public DBModelConfiguracion(int userID, string item, string value, int time, string status)
        {
            UserID = userID;
            Item = item;
            Value = value;
            Time = time;
            Status = status;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int UserID { get; set; }

        public string Item { get; set; }
        public string Value { get; set; }
        public int Time { get; set; }
        
        public string Status { get; set; }

        public bool SaveConfig(Usuario user, SQLiteAsyncConnection sqlite)
        {
            try
            {
                DBModelConfiguracion Conf = new DBModelConfiguracion(user.ID,this.Item,this.Value,this.Time,this.Status);
                sqlite.InsertAsync(Conf);
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                Console.WriteLine(error);
                return false;

            }
        }
    }
}
