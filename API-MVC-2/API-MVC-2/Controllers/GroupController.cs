using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API_MVC_2.Models;
using APIPractice3.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_MVC_2.Controllers
{
    public class GroupController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTeacherToGroup()
        {
            List<Teacher> teachers;
            List<Group> groups;

            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("http://localhost:53577/api/Teacher/GetAllTeachers").Result;

                teachers = JsonConvert.DeserializeObject<List<Teacher>>(result.Content.ReadAsStringAsync().Result);

                var result_ = client.GetAsync("http://localhost:53577/api/Group/GetAllGroups").Result;

                groups = JsonConvert.DeserializeObject<List<Group>>(result_.Content.ReadAsStringAsync().Result);
            }

            AddTeacherToGroupModel model = new AddTeacherToGroupModel()
            {
                Teachers = teachers,
                Groups = groups
            };

            return View(model);

        }

        [HttpPost]
        public IActionResult AddTeacherToGroup(int? TeacherId, int? GroupId)
        {
            if (TeacherId != null && GroupId != null )
            {
                GroupTeachers groupTeacher = new GroupTeachers()
                {
                    TeacherId = TeacherId,
                    GroupId = GroupId
                };

                var data = JsonConvert.SerializeObject(groupTeacher);

                var content = new StringContent(data, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var resp = client.PostAsync("http://localhost:53577/api/Teacher/AddTeacherToGroup", content).Result;

                    if (resp.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View();

        }
    }
}
