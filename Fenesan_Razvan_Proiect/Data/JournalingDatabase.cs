using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Fenesan_Razvan_Proiect.Models;

namespace Fenesan_Razvan_Proiect.Data
{
    public class JournalingDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public JournalingDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Journal>().Wait();
            _database.CreateTableAsync<Mood>().Wait();
            _database.CreateTableAsync<ListMood>().Wait();
        }
        public Task<List<Journal>> GetJournalsAsync()
        {
            return _database.Table<Journal>().ToListAsync();
        }
        public Task<Journal> GetJournalAsync(int id)
        {
            return _database.Table<Journal>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveJournalAsync(Journal jtoday)
        {
            if (jtoday.ID!=0)
            {
                return _database.UpdateAsync(jtoday);
            }
            else
            {
                return _database.InsertAsync(jtoday);
            }
        }
        public Task<int> DeleteJournalAsync(Journal jtoday)
        {
            return _database.DeleteAsync(jtoday);
        }

        public Task<int> SaveMoodAsync(Mood mood)
        {
            if (mood.ID != 0)
            {
                return _database.UpdateAsync(mood);
            }
            else
            {
                return _database.InsertAsync(mood);
            }
        }
        public Task<int> DeleteMoodAsync(Mood mood)
        {
            return _database.DeleteAsync(mood);
        }
        public Task<List<Mood>> GetMoodsAsync()
        {
            return _database.Table<Mood>().ToListAsync();
        }
        public Task<int> SaveListMoodAsync(ListMood listm)
        {
            if (listm.ID!=0)
            {
                return _database.UpdateAsync(listm);
            }
            else
            {
                return _database.InsertAsync(listm);
            }
        }
        public Task<List<Mood>> GetListMoodsAsync(int journalid)
        {
            return _database.QueryAsync<Mood>(
                "select M.ID, M.Description from Mood M"
                + " inner join ListMood LM"
                + " on M.ID=LM.MoodID where LM.JournalID = ?",
                journalid);
        }
    }
}

