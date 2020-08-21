using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MVC_2.Models
{
    public class CreateStudentModel
    {
        public Student Student { get; set; }

        public List<Group> Groups { get; set; }
    }
}
