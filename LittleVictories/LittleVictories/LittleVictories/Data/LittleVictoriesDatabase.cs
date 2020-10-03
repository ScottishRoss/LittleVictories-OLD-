using LittleVictories.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public Task<List<QuickVictories>> GetQuickVictoriesEditableAsync()
        {
            return _database.QueryAsync<QuickVictories>("select * from QuickVictories where Id != ?", 0);
        }
        public Task<List<QuickVictories>> GetQuickVictoriesAsync()
        {
            return _database.Table<QuickVictories>().OrderByDescending(x => x.DisplaySeq).ToListAsync();
        }
        public Task<List<TheVictory>> GetVictoriesAsync()
        {
            return _database.Table<TheVictory>().OrderByDescending(x => x.Date).ToListAsync();
        }

        public Task<int> SaveVictoryAsync(TheVictory victory)
        {
            return victory.Id != 0 ? _database.UpdateAsync(victory) : _database.InsertAsync(victory);
        }

        public Task<int> DeleteVictoryAsync(TheVictory victory)
        {
            return _database.DeleteAsync(victory);
        }

        public Task<int> SaveQuickVictoryAsync (QuickVictories quickVictories)
        {
            return quickVictories.Id != 0 ? _database.UpdateAsync(quickVictories) : _database.InsertAsync(quickVictories);
        }
        public Task<int> DeleteQuickVictoryAsync(QuickVictories quickVictories)
        {
            return _database.DeleteAsync(quickVictories);
        }
    }
}