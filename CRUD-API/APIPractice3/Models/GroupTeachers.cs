using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Models
{
    public class GroupTeachers
    {
        public Group Group { get; set; }
        [ForeignKey("Group")]
        public int? GroupId { get; set; }

        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
    }
}
