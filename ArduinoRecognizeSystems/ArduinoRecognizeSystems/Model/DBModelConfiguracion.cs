using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace ArduinoRecognizeSystems2.Model
{
    class DBModelConfiguracion
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int UserID { get; set; }

        public string Item { get; set; }
        public string Value { get; set; }
        public int Time { get; set; }
        
        public char[] Status { get; set; }
    }
}
