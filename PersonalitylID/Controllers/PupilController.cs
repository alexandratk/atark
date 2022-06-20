using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Helpers;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class PupilController: ControllerBase 
    {
        private readonly IPupilService PupilService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public PupilController(MyDataContext context, IPupilService PupilService,
         IMapper mapper) {
             this.context = context;
             this.PupilService = PupilService;
             this.mapper = mapper;
         }

        [Authorize(Roles = "Administrator")]
        [HttpPost("addpupil")]
        public async Task<IActionResult> RegisterPupil([FromBody] PupilDto pupilDto)
        {
            Group timeGroup = context.Group.Where(c => c.Id == pupilDto.GroupId).FirstOrDefault();
            Pupil newPupil = mapper.Map<Pupil>(pupilDto);
            newPupil.Group = timeGroup;
            newPupil = await PupilService.AddPupil(newPupil);
            return Ok(newPupil);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("listpupil/{id}")]
        public async Task<IActionResult> WriteListPupil(int id)
        {
            var list = await PupilService.ListPupil(id);
            return Ok(list);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("getpupil/{id}")]
        public async Task<IActionResult> WritePupil(int id)
        {
            var list = await PupilService.GetPupil(id);
            return Ok(list);
        }

        [HttpGet("listpupilfromparent/{id}")]
        public async Task<IActionResult> WriteListPupilFromParent(int id)
        {
            Console.WriteLine(id + "");
            var list = await PupilService.ListPupilFromParent(id);
            return Ok(list);
        }

        [HttpGet("listpupilfromgroup/{id}")]
        public async Task<IActionResult> WriteListPupilFromGroup(int id)
        {
            var list = await PupilService.ListPupilFromGroup(id);
            return Ok(list);
        }

        [HttpPost("listabsentpupileduc")]
        public async Task<IActionResult> WriteListAbsentPupilEduc([FromBody] DateAbsentPupil dateAbsentPupil)
        {
            var list = await PupilService.ListAbsentPupilsEduc(dateAbsentPupil.Date, dateAbsentPupil.EducationalInstitutionId);
            Console.WriteLine(dateAbsentPupil.Date);
            return Ok(list);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdatePupilProfileGroup(int id, [FromBody] PupilDto pupilDto)
        {
            var pupil = await PupilService.GetsPupilById(id);
            pupil.Group = await PupilService.GetsGroupById(pupilDto.GroupId);
            var updatedPupil = await PupilService.UpdatePupil(pupil, id);
            return Ok(updatedPupil);
        }

        [HttpPost("updatepupil/{id}")]
        public async Task<IActionResult> UpdatePupilProfile(int id, [FromBody] PupilDto pupilDto)
        {
            var pupil = await PupilService.GetsPupilById(id);
            pupil.Name = pupilDto.Name;
            pupil.Login = pupilDto.Login;
            pupil.Dateofbirth = pupilDto.Dateofbirth;
            pupil.Password = HashHelper.ComputeSha256Hash(pupilDto.Password);
            var updatedPupil = await PupilService.UpdatePupil(pupil, id);
            return Ok(updatedPupil);
        }

        [HttpGet("listpupilonlesson/{id}")]
        public async Task<IActionResult> CheckPupilOnLesson(int id) {
            Console.WriteLine("11");
            var list = await PupilService.ListPupilOnLesson(id);
            Console.WriteLine("22");
            return Ok(list);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePupil(int id)
        {
            await PupilService.DeletePupil(id);
            return Ok(new
            {
               Response = "Pupil is deleted successfully"
            });
        }
    }
}