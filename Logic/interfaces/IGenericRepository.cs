using System.Collections.Generic;
namespace Logic.interfaces
{
    /// <summary>
    /// generic interface providing CRUD data. Implement it in your class if you want to have full operations to this entity. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
