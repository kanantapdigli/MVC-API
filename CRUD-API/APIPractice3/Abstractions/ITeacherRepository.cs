using APIPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public interface ITeacherRepository : IGeneralRepository<Teacher>
    {
        void AddTeacherToGroup(GroupTeachers groupTeacher);
    }
}
