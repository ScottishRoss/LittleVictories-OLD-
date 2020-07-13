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
            _database.CreateTableAsync<TheVictory>().Wait();
        }

        public Task<List<TheVictory>> GetVictoriesAsync()
        {
            return _database.Table<TheVictory>().OrderByDescending(x => x.Date).ToListAsync();
        }

        public Task<int> SaveVictoryAsync(TheVictory victory)
        {
            if (victory.Id != 0)
            {
                return _database.UpdateAsync(victory);
            }
            else
            {
                return _database.InsertAsync(victory);
            }
        }

        public Task<int> DeleteVictoryAsync(TheVictory victory)
        {
            return _database.DeleteAsync(victory);
        }
    }
}