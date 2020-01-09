using ArduinoRecognizeSystems2.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduinoRecognizeSystems2.Model
{
    class Usuario
    {
        private int _ID;
        private string _Username;
        private string _Pass;
        private string _Name;
        private string _St;


        private static String conectionString = @"Data Source=148.103.246.141;Initial Catalog=ARSDB;Persist Security Info=True;User ID=ARSUser;Password=ars123";
        [PrimaryKey, AutoIncrement]
        public int ID { get { return _ID; } }
        [MaxLength(150), Unique]
        public string Username { get { return _Username; } set { _Pass = value; } }
        [MaxLength(150)]
        public string Name { get { return _Name; } set {_Name=value; } }
        [MaxLength(150)]
        public string Pass { get { return _Pass; }}

        public string Status { get { return _St; } set { _St= value; } }
        public Usuario(String User, string pass)
        {
            _Username = User;
            _Pass = pass;
        }
        public bool LogIn()
        {
            try
            {
                bool exist = false;
                using (SqlConnection con = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Connection.Open();
                        cmd.CommandText = "select ID,Pass from tblUser where (UserName=@user and Pass=@pas) and [Status]='act'";

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
            catch
            {
                return false;
            }
                 
        }
        public bool BindDevide()
        {
            try
            {
                var DevideID = Preferences.Get("my_id", string.Empty);
                if (string.IsNullOrWhiteSpace(DevideID))
                {
                    DevideID = System.Guid.NewGuid().ToString();
                    Preferences.Set("my_id", DevideID);
                }
                /*
                var UserData = new Usuario { Name = Name, Username = Username, Pass = _Pass, Status="lin" };
                sqlite.InsertAsync(UserData);
                return true;*/

                try
                {
                    using (SqlConnection con = new SqlConnection(conectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.Connection.Open();
                            cmd.CommandText = "Update TblUser set [BindedDevice] = @device,[Status]='lin' where [Username]=@user";

                            cmd.Parameters.AddWithValue("@user", _Username);
                            cmd.Parameters.AddWithValue("@device", DevideID);
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
            catch (Exception e)
            {
                string error = e.Message;
                Console.WriteLine(error);
                return false;

            }
        }

        public void CleanConfiguration()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Connection.Open();
                        cmd.CommandText = "Delete from tblConfiguration where [UserID]=@user";
                        cmd.Parameters.AddWithValue("@user", ID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string hola = ex.Message;
            }
        }
        public List<UserConfiguration> GetConfiguration()
        {
            List<UserConfiguration> conf = new List<UserConfiguration>();
            try
            {
                using (SqlConnection con = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Connection.Open();
                        cmd.CommandText = "Select * from TblConfiguration where [UserID]=@user and [Status]='act'";
                        cmd.Parameters.AddWithValue("@user", ID);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            UserConfiguration c = new UserConfiguration(ID, reader[2].ToString(), reader[3].ToString(), int.Parse(reader[4].ToString()), reader[5].ToString());
                            conf.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string hola = ex.Message;
            }
            return conf;
        }
        private static void tblnames(SQLiteConnection sqlite)
        {
            var tables = sqlite.TableMappings;
            foreach (var item in tables)
            {   
                string name = item.TableName;
                Console.WriteLine(name);
            }

        }
        private static IEnumerable<Usuario> SelectUser(SQLiteConnection sqlite)
        {
            return sqlite.Query<Usuario>("Select * from Usuario where [Status]='lin'");

        }
        public static Usuario GetLocalUser()
        {
            try
            {
                var DevideID = Preferences.Get("my_id", string.Empty);
                if (string.IsNullOrWhiteSpace(DevideID))
                {
                    DevideID = System.Guid.NewGuid().ToString();
                    Preferences.Set("my_id", DevideID);
                }
                using (SqlConnection con = new SqlConnection(conectionString))
                {
                    Usuario User=null;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.Connection.Open();
                        cmd.CommandText = "select * from tblUser where [Status]='lin' and [BindedDevice]=@BD";
                        cmd.Parameters.AddWithValue("@BD", DevideID);
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            User = new Usuario
                            {
                                _ID = int.Parse(reader[0].ToString()),
                                _Username = reader[1].ToString(),
                                _Pass = reader[2].ToString(),
                                Name = reader[3].ToString(),
                                Status = reader[4].ToString()
                            };
                        }
                    }
                    return User;
                }
            }
            catch(Exception ex)
            {
                string a = ex.Message;
                return null;
            }

        }
    }
}
