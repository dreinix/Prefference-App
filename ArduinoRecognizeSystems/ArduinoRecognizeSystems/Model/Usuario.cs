using ArduinoRecognizeSystems2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Text;

namespace ArduinoRecognizeSystems2.Model
{
    class Usuario
    {
        private int _ID;
        private string _Username;
        private string _Pass;
        private string _Name;

        String conectionString = @"Data Source=148.103.246.141;Initial Catalog=ARSDB;Persist Security Info=True;User ID=ARSUser;Password=ars123";
        public int ID { get; }
        
        public string Username { get;}
        public string Name { get; set; }

        public Usuario(String User, string pass)
        {
            _Username = User;
            _Pass = pass;
        }
        public bool LogIn()
        {
            bool exist=false;  
            using (SqlConnection con = new SqlConnection(conectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.Connection.Open();
                    cmd.CommandText = "select ID,Pass from tblUser where UserName=@user and Pass=@pas";
                                       
                    cmd.Parameters.AddWithValue("@user", _Username);
                    cmd.Parameters.AddWithValue("@pas", _Pass);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        exist = true;
                    }
                }
                if (exist)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            

        }
    }
}
