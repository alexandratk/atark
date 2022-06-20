using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class GroupController: ControllerBase 
    {
        private readonly IGroupService groupService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public GroupController(MyDataContext context, IGroupService GroupService,
         IMapper mapper) {
             this.context = context;
             this.groupService = GroupService;
             this.mapper = mapper;
         }

        [Authorize(Roles = "Administrator")]
        [HttpPost("addgroup")]
        public async Task<IActionResult> RegisterGroup([FromBody] GroupDto groupDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == groupDto.EducationalInstitutionId).FirstOrDefault();
            Teacher timeTeacher = context.Teacher.Where(c => c.Id == groupDto.TeacherId).FirstOrDefault();
            Group newGroup = mapper.Map<Group>(groupDto);
            newGroup.EducationalInstitution = timeEducationalInstitution;
            newGroup.Teacher = timeTeacher;
            newGroup = await groupService.AddGroup(newGroup);
            return Ok(newGroup);
        }


        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await groupService.DeleteGroup(id);
            return Ok(new
            {
               Response = "Group is deleted successfully"
            });
        }

        [Authorize(Roles = "Administrator, Teacher")]
        [HttpGet("listgroup/{id}")]
        public async Task<IActionResult> WriteListGroup(int id)
        {
            var list = await groupService.ListGroup(id);
            return Ok(list);
        }
    }
}