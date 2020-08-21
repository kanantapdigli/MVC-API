using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API_MVC_2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_MVC_2.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(teacher);

                var content = new StringContent(data, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var resp = client.PostAsync("http://localhost:53577/api/Teacher/CreateTeacher", content).Result;

                    if (resp.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(teacher);
        }
    }
}
