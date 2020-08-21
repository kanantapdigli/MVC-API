using APIPractice3.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private readonly SchoolContext schoolContext_;
        private readonly DbSet<T> dbTable;

        public GeneralRepository(SchoolContext schoolContext)
        {
            schoolContext_ = schoolContext;
            dbTable = schoolContext_.Set<T>();
        }

        public void Create(T data)
        {
            dbTable.Add(data);
            Save();
        }

        public void Delete(int id)
        {
            var data = dbTable.Find(id);
            dbTable.Remove(data);
            Save();
        }

        public void Edit(T data)
        {
            schoolContext_.Update(data);
            Save();
        }

        public T Get(int id)
        {
            var data = dbTable.Find(id);
            return data;
        }

        public List<T> GetAll()
        {
            return dbTable.ToList();
        }

        public void Save()
        {
            schoolContext_.SaveChanges();
        }
    }
}
