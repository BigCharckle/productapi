using System.Collections.Generic;
using Models.products;
namespace Logic.interfaces
{
    /// <summary>
    /// generic interface providing readonly data. Implement it if you want to get dictionary data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepositoryrReadable<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
    }
}
