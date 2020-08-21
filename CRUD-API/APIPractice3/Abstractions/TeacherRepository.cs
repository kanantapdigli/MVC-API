using APIPractice3.Contexts;
using APIPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public class TeacherRepository : GeneralRepository<Teacher>, ITeacherRepository
    {
        private readonly SchoolContext schoolContext_;
        public TeacherRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            schoolContext_ = schoolContext;
        }

        public void AddTeacherToGroup(GroupTeachers groupTeacher)
        {
            schoolContext_.GroupTeachers.Add(groupTeacher);
            Save();
        }
    }
}
