using APIPractice3.Abstractions;
using APIPractice3.Contexts;
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
    public class GroupController
    {
        private readonly IGroupRepository groupRepository_;
        public GroupController(IGroupRepository groupRepository)
        {
            groupRepository_ = groupRepository;
        }

        public string GetAllGroups()
        {
           var groups = groupRepository_.GetAll();


            var serializedGroups = JsonConvert.SerializeObject(groups);

            return serializedGroups;
        }

        [HttpPost]
        public void AddGroup(Group group)
        {
            groupRepository_.Create(group);
        }

        [HttpPost("{id}")]
        public void EditGroup(int id, Group group)
        {
            var group_ = groupRepository_.Get(id);

            group_.Name = group.Name;

            groupRepository_.Edit(group_);
        }

        [HttpPost("{id}")]
        public void DeleteGroup(int id)
        {
            groupRepository_.Delete(id);
        }

        [HttpGet("{id}")]
        public Group GetGroup(int id)
        {
            var group = groupRepository_.Get(id);
            return group;
        }

        [HttpGet]
        public void AddTeacherToGroup(int TeacherId,int GroupId)
        {
            groupRepository_.AddTeacherToGroup(TeacherId, GroupId);
        }

        [HttpGet]
        public void DeleteTeacherFromGroup(int TeacherId, int GroupId)
        {
            groupRepository_.DeleteTeacherFromGroup(TeacherId, GroupId);
        }
    }
}
