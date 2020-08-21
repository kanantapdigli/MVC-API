using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public interface IGeneralRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        void Edit(T data);
        void Create(T data);
        void Delete(int id);
    }
}
