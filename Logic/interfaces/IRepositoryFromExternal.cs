using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.interfaces
{
    public interface IRepositoryFromExternal<T> where T : class
    {
       Task<List<T>> GetFromExternalAsyn(string ExternalUrl);
    }
}
