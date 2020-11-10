
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totalview.Models;

namespace Totalview.Services
{
    public class DataDummy
    {
        readonly SQLiteAsyncConnection _database;
        public DataDummy(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserModel>().Wait();
        }

        public Task<List<UserModel>> GetUserAsync()
        {
            return _database.Table<UserModel>().ToListAsync();
        }

        public Task<int> SaveUserAsync(UserModel user)
        {
            return _database.InsertAsync(user);
        }
    }
}
