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
        SQLiteAsyncConnection Database;
        public LoginDatabase()
        {
        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<SessionUser>();
        }

        public async Task<List<SessionUser>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<SessionUser>().ToListAsync();
        }

        //public async Task<List<SessionUser>> GetItemsNotDoneAsync()
        //{
        //    await Init();
        //    return await Database.Table<SessionUser>().Where(t => t.Done).ToListAsync();

        //    // SQL queries are also possible
        //    //return await Database.QueryAsync<SessionUser>("SELECT * FROM [SessionUser] WHERE [Done] = 0");
        //}

        public async Task<SessionUser> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<SessionUser>().Where(i => i.userId == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(SessionUser item)
        {
            await Init();
            if (item.userId != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(SessionUser item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}


