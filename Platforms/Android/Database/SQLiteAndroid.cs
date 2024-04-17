using Android.Database.Sqlite;
using MauiTestApp.Database;
using MauiTestApp.Platforms.Android.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: Dependency(typeof(SQLiteAndroid))]
namespace MauiTestApp.Platforms.Android.Database
{
    public class SQLiteAndroid : ISQLiteDatabase
    {
        public SQLiteConnection GetConnection()
        {

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(documentsPath, "mydatabase.db");
            return new SQLiteConnection(path);
        }

    }
}
