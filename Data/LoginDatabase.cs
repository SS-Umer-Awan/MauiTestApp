using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiTestApp.Models;
using MauiTestApp.Models.Login;

namespace MauiTestApp.Data
{
    public class LoginDatabase
    {
        SQLiteConnection Database;
        public LoginDatabase()
        {
        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            var result = Database.CreateTable<SessionUser>();
        }

        public async Task<List<SessionUser>> GetItemsAsync()
        {
            await Init();
            return Database.Table<SessionUser>().ToList();
        }


        public async Task<SessionUser> GetItemAsync(int id)
        {
            await Init();
            return Database.Table<SessionUser>().Where(i => i.userId == id).FirstOrDefault();
        }

        public async Task<int> SaveItemAsync(SessionUser item)
        {
            await Init();
            if (item.userId != 0)
            {
                return Database.Update(item);    
            }
            else
            {
                return Database.Insert(item);
            }
        }

        public async Task<int> DeleteItemAsync()
        {
            await Init();
            return Database.DeleteAll<SessionUser>();
        }
    }
}


