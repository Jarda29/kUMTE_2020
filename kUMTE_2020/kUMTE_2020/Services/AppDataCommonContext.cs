using System.IO;
using System.Linq;
using kUMTE_2020.Models;
using SQLite;

namespace kUMTE_2020.Services
{
    public class AppDataCommonContext
    {
        private SQLiteConnection _connection;
        public string AppDataCommonDbPath { get; private set; }
        public AppDataCommonContext()
        {
            AppDataCommonDbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "AppDataComon.sqlite");
            _connection = new SQLiteConnection(AppDataCommonDbPath);
            _connection.CreateTable<AppDataCommon>();
        }

        public AppDataCommon Get(string key)
        {
            var data = _connection.Table<AppDataCommon>().FirstOrDefault(x=>x.Key.Equals(key));
            return data;
        }

        public void SetValue(string key, int value)
        {
            if (_connection.Table<AppDataCommon>().Any(x => x.Key.Equals(key)))
            {
                var data = _connection.Table<AppDataCommon>().First(x => x.Key.Equals(key));
                data.Value = value;
                _connection.Update(data);
            }
            else
            {
                _connection.Insert(new AppDataCommon()
                {
                    Key = key,
                    Value = value
                });
            }
        }
    }
}
