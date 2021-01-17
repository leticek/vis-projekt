using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IFSDataMapper<T>
    {
        Task<T> GetById(int id);
        Task<bool> Insert(T value);
        Task<bool> Update(T value);
        Task<bool> Delete(int id);
    }
}
