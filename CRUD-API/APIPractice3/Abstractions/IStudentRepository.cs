using APIPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public interface IStudentRepository : IGeneralRepository<Student>
    {
        void AddStudentToGroup(int StudentId,int GroupId);
        void DeleteStudentFromGroup(int StudentId);
    }
}
