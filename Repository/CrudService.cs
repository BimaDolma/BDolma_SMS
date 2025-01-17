﻿using BDolma_SMS.Data;
using BDolma_SMS.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace BDolma_SMS.Repository
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public CrudService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Delete(T entity)
        {
            var result = _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public T Get(int? id)
        {
            var result = _context.Set<T>().Find(id);
            return result;
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).SingleOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsyncIncludingProperties(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);

            foreach (var include in includes)
            {
                query = Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.Include(query, include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).SingleOrDefaultAsync();

        }

        public int Insert(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public async Task<int> InsertAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<T> QueryAsync(string commandText, object param = null, CommandType commandType = CommandType.Text)
        {
            var result = await _context.Set<T>().FromSqlRaw(commandText, param).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<object>> QueryListAsync(string commandText, object param = null, CommandType commandType = CommandType.Text)
        {
            var result = await _context.Set<T>().FromSqlRaw(commandText, param).ToListAsync();

            // Manually convert each item to an object

            var resultList = new List<object>();
            foreach (var item in result)
            {
                resultList.Add(item);
            }

            return resultList;
        }

        public int Update(T entity)
        {
            var result = _context.Set<T>().Update(entity).Property(p => p.Id);
            _context.SaveChanges();
            return entity.Id;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var result = _context.Set<T>().Update(entity).Property(p => p.Id);
            await _context.SaveChangesAsync();
            return entity.Id;
        }
    }
}
