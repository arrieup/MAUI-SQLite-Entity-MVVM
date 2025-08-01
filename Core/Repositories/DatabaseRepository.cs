using MAUI_Core.Models;
using Microsoft.EntityFrameworkCore;
using SQLite;

namespace MAUI_Core.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Template> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public interface IDatabaseRepository<T> where T : class, new()
    {
        Task CreateAsync(T item);
        void DeleteAll();
        Task DeleteAsync(int id);
        Task DeleteAsync(T item);
        Task<List<T>> ReadAllAsync();
        Task<T?> ReadAsync(int id);
        Task UpdateAsync(int id);
        Task UpdateAsync(T item);
    }

    public class DatabaseRepository<T> : IDatabaseRepository<T> where T : class, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _set;

        public DatabaseRepository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
            _set.Add(item);
            await _context.SaveChangesAsync();
        }

        public void DeleteAll()
        {
            _set.RemoveRange(_set);
        }

        public async Task DeleteAsync(int id)
        {
            if (await _set.FindAsync(id) is T item)
            {
                await DeleteAsync(item);
            }
            else
            {
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            }
        }

        public async Task DeleteAsync(T item)
        {
            _set.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> ReadAllAsync() => await _set.ToListAsync();

        public async Task<T?> ReadAsync(int id) => await _set.FindAsync(id);

        public async Task UpdateAsync(int id)
        {
            if (await _set.FindAsync(id) is T item)
            {
                await UpdateAsync(item);
            }
            else
            {
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            }
        }

        public async Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
