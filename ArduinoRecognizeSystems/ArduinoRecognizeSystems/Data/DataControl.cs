using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ArduinoRecognizeSystems2.Data
{
    class DataControl
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DataControl()
        {
            Open();
        }

        private void Open()
        {
            try
            {
                con.Close();
                String conectionString = @"Data Source=INIX-PC\INIX;Initial Catalog=ARSDB;Persist Security Info=True;User ID=ARSUser;Password=ars123";
                con.ConnectionString = conectionString;
                con.Open();
            }
            catch (Exception) {  };
        }
        public void Close() => con.Close();


        
    }
}
