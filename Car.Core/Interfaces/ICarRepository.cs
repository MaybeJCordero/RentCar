using CarCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarCore.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<int> UpdateByClient (int clientID, string clientName);
    }
}
