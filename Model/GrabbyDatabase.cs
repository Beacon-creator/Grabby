using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grabby_Two.Model
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<GrabbyPerson>();
            //_database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<GrabbyPerson>> GetPeopleAsync()
        {
            return _database.Table<GrabbyPerson>().ToListAsync();
        }

        public Task<int> SavePersonAsync(GrabbyPerson person)
        {
            return _database.InsertAsync(person);
        }
    }
}
