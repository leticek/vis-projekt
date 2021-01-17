using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ISQLDataMapper<T>
    {
        T GetById(int id);
        bool Insert(T value);
        bool Update(T value);
        bool Delete(int id);
    }
}
