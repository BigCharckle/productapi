using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Logic.interfaces;
namespace Logic.repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            //this._context = new DbContext();
            table = _context.Set<T>();
        }
        public GenericRepository(DbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.AsQueryable();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
