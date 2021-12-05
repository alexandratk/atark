using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using System.Linq;
using System;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class PupilParentController: ControllerBase 
    {
        private readonly IPupilParentService PupilParentService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public PupilParentController(MyDataContext context, IPupilParentService PupilParentService,
         IMapper mapper) {
             this.context = context;
             this.PupilParentService = PupilParentService;
             this.mapper = mapper;
         }

        [HttpPost("addpupilparent")]
        public async Task<IActionResult> RegisterPupilParent([FromBody] PupilParentDto pupilParentDto)
        {
            Pupil timePupil = context.Pupil.Where(c => c.Id == pupilParentDto.PupilId).FirstOrDefault();
            Parent timeParent = context.Parent.Where(c => c.Id == pupilParentDto.ParentId).FirstOrDefault();
            PupilParent newPupilParent = mapper.Map<PupilParent>(pupilParentDto);
            newPupilParent.Pupil = timePupil;
            newPupilParent.Parent = timeParent;
            newPupilParent = await PupilParentService.AddPupilParent(newPupilParent);
            return Ok(newPupilParent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePupilParent(int id)
        {
            await PupilParentService.DeletePupilParent(id);
            return Ok(new
            {
               Response = "PupilParent is deleted successfully"
            });
        }
    }
}