using System;
using System.Collections.Generic;
using SQLite;
using System.Text;
using System.Data.SqlClient;

namespace ArduinoRecognizeSystems2.Model
{
    class UserConfiguration
    {
        private static String conectionString = @"Data Source=148.103.246.141;Initial Catalog=ARSDB;Persist Security Info=True;User ID=ARSUser;Password=ars123";
        public UserConfiguration(int userID, string item, string value, int time, string status)
        {
            UserID = userID;
            Item = item;
            Value = value;
            Time = time;
            Status = status;
        }
        public int ID { get; set; }

        public int UserID { get; set; }

        public string Item { get; set; }
        public string Value { get; set; }
        public int Time { get; set; }

        public string Status { get; set; }

        public bool SaveConfig(Usuario user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Connection.Open();
                        cmd.CommandText = "Insert into TblConfiguration values (@user,@item,@val,0,'act')";
                        cmd.Parameters.AddWithValue("@user", user.ID);
                        cmd.Parameters.AddWithValue("@item", Item);
                        cmd.Parameters.AddWithValue("@val", Value);
                        int val = cmd.ExecuteNonQuery();
                        if (val == 1)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                string hola = ex.Message;
                return false;
            }
        }
    }
}
