using MAUI_SQLite_Entity_MVVM.Models;
using MAUI_SQLite_Entity_MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_SQLite_Entity_MVVM.Services
{
    public class BaseService<T> where T : new()
    {
        public DatabaseRepository Database { get; set; }
        public BaseService(DatabaseRepository databaseRepository)
        {
            Database = databaseRepository;
        }

        public async Task<List<T>> GetAll()
        {
            return await BaseRepository<T>.ReadAllAsync();
        }

        public async Task Add(T item)
        {
            await BaseRepository<T>.CreateAsync(item);
        }
    }
}
