using APIPractice3.Contexts;
using APIPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public class GroupRepository : GeneralRepository<Group>, IGroupRepository
    {
        private readonly SchoolContext schoolContext_;
        public GroupRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            schoolContext_ = schoolContext;
        }

        public void AddTeacherToGroup(int TeacherId, int GroupId)
        {
            schoolContext_.GroupTeachers.Add(new GroupTeachers() { TeacherId = TeacherId, GroupId = GroupId });
            Save();
        }

        public void DeleteTeacherFromGroup(int TeacherId, int GroupId)
        {
            var groupTeacher = schoolContext_.GroupTeachers.FirstOrDefault(gt => gt.TeacherId == TeacherId && gt.GroupId == GroupId);

            schoolContext_.GroupTeachers.Remove(groupTeacher);
            Save();
        }
    }
}
