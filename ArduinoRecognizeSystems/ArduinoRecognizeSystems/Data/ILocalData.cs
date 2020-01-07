using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoRecognizeSystems2.Data
{
    public interface ILocalData
    {
        SQLiteAsyncConnection GetConnection();
    }
}
