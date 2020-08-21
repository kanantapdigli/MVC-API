using APIPractice3.Abstractions;
using APIPractice3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherController
    {
        private readonly ITeacherRepository teacherRepository_;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            teacherRepository_ = teacherRepository;
        }

        public void CreateTeacher(Teacher teacher)
        {
            teacherRepository_.Create(teacher);
        }

        public List<Teacher> GetAllTeachers()
        {
            var teachers = teacherRepository_.GetAll();
            return teachers;
        }

        public void AddTeacherToGroup(GroupTeachers groupTeacher)
        {
            teacherRepository_.AddTeacherToGroup(groupTeacher);
        }
    }
}
