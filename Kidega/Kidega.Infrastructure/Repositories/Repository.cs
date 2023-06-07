using Kidega.Domain.Entities;
using Kidega.Domain.RepositoryContracts;
using Kidega.Infrastructure.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kidega.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        internal readonly ApplicationDbContext db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            this.db = db;
            this.dbSet = db.Set<T>();
        }
        public async Task Add(T entity)
        {
            dbSet.Add(entity);
            await db.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAll(string? includeProperties = null, bool tracked = false) // Comma separated, Case Sensitive (e.g. "Category,Product") include properties
        {
            IQueryable<T> dbSetQuery = tracked ? dbSet : dbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dbSetQuery = dbSetQuery.Include(includeProperty);
                }
            }
            return await dbSetQuery.ToListAsync();
        }

        public async Task<T?> Get(int id, string? includeProperties = null, bool tracked = false)
        {

            IQueryable<T> dbSetQuery = tracked ? dbSet : dbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dbSetQuery = dbSetQuery.Include(includeProperty);
                }
            }
            return await dbSetQuery.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            dbSet.Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
