using APIPractice3.Contexts;
using APIPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public class StudentRepository : GeneralRepository<Student>, IStudentRepository
    {
        private readonly SchoolContext schoolContext_;
        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            schoolContext_ = schoolContext;
        }

        public void AddStudentToGroup(int StudentId, int GroupId)
        {
            var student = schoolContext_.Students.Find(StudentId);

            student.GroupId = GroupId;

            Save();
        }

        public void DeleteStudentFromGroup(int StudentId)
        {
            var student = schoolContext_.Students.Find(StudentId);

            student.GroupId = null;

            Save();
        }
    }
}
