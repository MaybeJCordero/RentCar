using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<int> Update(T entity);
        Task<int> Add(T entity);
    }
}