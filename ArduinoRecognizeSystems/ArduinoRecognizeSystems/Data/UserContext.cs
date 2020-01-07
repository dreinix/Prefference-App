using ArduinoRecognizeSystems2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ArduinoRecognizeSystems2.Data
{
    class UserContext: DbContext
    {

        public UserContext()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-V2MPCEE\XINISERVER;Initial Catalog=ARSDB;
                                                                +User ID=ARSUser;Password=ars123");
        }
    }
}
