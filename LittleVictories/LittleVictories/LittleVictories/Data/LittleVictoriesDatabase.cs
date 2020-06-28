using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using LittleVictories.Models;

namespace LittleVictories.Data
{
    public class LittleVictoriesDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public LittleVictoriesDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Victory>().Wait();
        }

        public Task<List<Victory>> GetVictoriesAsync()
        {
            return _database.Table<Victory>().ToListAsync();
        }

        public Task<Victory> GetVictoryAsync(int id)
        {
            return _database.Table<Victory>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveVictoryAsync(Victory victory)
        {
            if (victory.ID != 0)
            {
                return _database.UpdateAsync(victory);
            }
            else
            {
                return _database.InsertAsync(victory);
            }
        }

        public Task<int> DeleteVictoryAsync(Victory victory)
        {
            return _database.DeleteAsync(victory);
        }
    }
}