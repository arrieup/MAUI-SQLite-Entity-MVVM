using MAUI_Core.Repositories;

namespace MAUI_Core.Services
{
    public interface IDatabaseService<T> where T : class, new()
    {
        DatabaseRepository<T> Repository { get; set; }

        Task Create(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<List<T>> GetAll();
        void RemoveAll();
    }

    public class DatabaseService<T>(DatabaseRepository<T> databaseRepository) : IDatabaseService<T> where T : class, new()
    {
        public DatabaseRepository<T> Repository { get; set; } = databaseRepository;

        public async Task<List<T>> GetAll()
        {
            return await Repository.ReadAllAsync();
        }

        public void RemoveAll()
        {
            Repository.DeleteAll();
        }

        // TODO : Create item locally to update the view then add it to database
        public async Task Create(T item)
        {
            await Repository.CreateAsync(item);
        }

        public async Task Update(T item)
        {
            await Repository.UpdateAsync(item);
        }

        public async Task Delete(T item)
        {
            await Repository.DeleteAsync(item);
        }
    }
}
