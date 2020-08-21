using APIPractice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice3.Abstractions
{
    public interface IGroupRepository : IGeneralRepository<Group>
    {
        void AddTeacherToGroup(int TeacherId, int GroupId);

        void DeleteTeacherFromGroup(int TeacherId, int GroupId);
    }
}
