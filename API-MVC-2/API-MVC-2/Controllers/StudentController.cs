using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API_MVC_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace API_MVC_2.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    
        [HttpGet]
        public IActionResult CreateStudent()
        {
            List<Group> groups;

            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:53577/api/Group/GetAllGroups").Result;
                groups = JsonConvert.DeserializeObject<List<Group>>(result.Content.ReadAsStringAsync().Result);
            }

            CreateStudentModel model = new CreateStudentModel()
            {
                Groups = groups
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {

                var data = JsonConvert.SerializeObject(student);

                var content = new StringContent(data, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var resp = client.PostAsync("http://localhost:53577/api/Student/CreateStudent",content).Result;

                    if (resp.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

            }

            return View(student);
        }
    }
}
