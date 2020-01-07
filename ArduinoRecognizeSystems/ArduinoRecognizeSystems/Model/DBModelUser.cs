using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoRecognizeSystems2.Model
{
    class DBModelUser
    {

        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [MaxLength(150),Unique] 
        public string Username { get; set; }
        [MaxLength(150)]
        public string Password { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

    }
}
