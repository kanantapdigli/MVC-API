using APIPractice3.Abstractions;
using APIPractice3.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController
    {
        private readonly IStudentRepository studentRepository_;

        public StudentController(IStudentRepository studentRepository)
        {
            studentRepository_ = studentRepository;
        }

        public string GetAllStudents()
        {
            var students = studentRepository_.GetAll();

            var serializedStudents = JsonConvert.SerializeObject(students);

            return serializedStudents;
        }

        public void CreateStudent(Student student)
        {
            studentRepository_.Create(student);
        }


        [HttpPost("{id}")]
        public void EditStudent(int id, Student student)
        {
            var student_ = studentRepository_.Get(id);

            student_.Name = student.Name;
            student_.Email = student.Email;
            student_.GroupId = student.GroupId;

            studentRepository_.Edit(student_);
        }

        [HttpPost("{id}")]
        public void DeleteStudent(int id)
        {
            studentRepository_.Delete(id);
        }

        public void AddStudentToGroup(int StudentId, int GroupId)
        {
            studentRepository_.AddStudentToGroup(StudentId, GroupId);
        }

        public void DeleteStudentFromGroup(int StudentId)
        {
            studentRepository_.DeleteStudentFromGroup(StudentId);
        }
    }
}
