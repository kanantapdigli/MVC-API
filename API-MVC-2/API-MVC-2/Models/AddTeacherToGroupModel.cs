using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MVC_2.Models
{
    public class AddTeacherToGroupModel
    {
        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
    }
}
