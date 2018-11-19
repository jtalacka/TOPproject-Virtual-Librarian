using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace VLibrarian.Resources.Data
{
    public class VLDatabase
    {
     /*   readonly SQLiteAsyncConnection database;
        public VLDatabase(string dbPath) 
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<User>().Wait();
            }

            public Task<List<User>> GetItemsAsync()
            {
                return database.Table<User>().ToListAsync();
            }

            public Task<List<User>> GetItemsNotDoneAsync()
            {
                return database.QueryAsync<User>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            }

            public Task<User> GetItemAsync(string username)
            {
                return database.Table<User>().Where(i => i.username == username).FirstOrDefaultAsync();
            }

            public Task<int> SaveItemAsync(User item)
            {
                if (item.username != "")
                {
                    return database.UpdateAsync(item);
                }
                else
                {
                    return database.InsertAsync(item);
                }
            }

            public Task<int> DeleteItemAsync(User item)
            {
                return database.DeleteAsync(item);
            }
            */
        }
}