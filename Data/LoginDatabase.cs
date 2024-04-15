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
        public static SQLiteAsyncConnection Database;
        public LoginDatabase() { }
        public static void InitializeDatabase()
        {
            try
            {
                if (Database is not null)
                    return;

                Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                var result = Database.CreateTableAsync<SessionUser>();
            }
            catch (Exception ex)
            {

                return;
            }

        }

        public async Task<SessionUser> GetItemAsync()
        {
            InitializeDatabase();
            return await Database.Table<SessionUser>().FirstOrDefaultAsync();
        }
        public async Task<int> SaveItemAsync(LoginResponse item)
        {
            InitializeDatabase();
            SessionUser obj = new SessionUser();
            obj.userId = item.result.userId;
            obj.email = item.result.email;
            if (item.success)
            {
                return await Database.UpdateAsync(obj);
            }
            else
            {
                return await Database.InsertAsync(obj);
            }

            //public static int SaveUser(SessionUser model)
            //{
            //    Database.DeleteAllAsync<SessionUser>();
            //    return await Database.Insert(model);
            //}

            //public static SessionUser GetUser()
            //{
            //    return Database.Table<SessionUser>().FirstOrDefault();
            //}
            //async Task Init()
            //{
            //    if (Database is not null)
            //        return;

            //    Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            //    var result = await Database.CreateTableAsync<SessionUser>();
            //
            //}
        }
        public async Task<int> DeleteAllItemsAsync()
        {
            InitializeDatabase();

            try
            {
                return await Database.DeleteAllAsync<SessionUser>();
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                Console.WriteLine($"Error deleting all items: {ex.Message}");
                return -1; // Return -1 to indicate failure
            }
        }

    }
}


