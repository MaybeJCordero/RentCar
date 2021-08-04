using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Update(T entity);
    }
}
