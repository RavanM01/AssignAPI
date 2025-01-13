using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Core.Entities.Common;
using TaskVeren.DAL.Context;
using TaskVeren.DAL.Repositories.Interfaces;

namespace TaskVeren.DAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        readonly AppDBContext _context;

        public Repository(AppDBContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> Create(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public async Task<TEntity> GetbyId(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<bool> IsExsist(Expression<Func<TEntity, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
            Table.Update(entity);
        }

        public void Update(TEntity entity)
        {
            Table.Update(entity);
        }
    }
}
