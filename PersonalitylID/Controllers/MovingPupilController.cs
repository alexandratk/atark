using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    public class MovingPupilController: ControllerBase 
    {
        private readonly IMovingPupilService MovingPupilService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public MovingPupilController(MyDataContext context, IMovingPupilService MovingPupilService,
         IMapper mapper) {
             this.context = context;
             this.MovingPupilService = MovingPupilService;
             this.mapper = mapper;
         }

        [HttpPost("addmovpupil")]
        public async Task<IActionResult> RegisterMovingPupil([FromBody] MovingPupilDto movingPupilDto)
        {
            Device timeDevice = context.Device.Where(c => c.Id == movingPupilDto.DeviceId).FirstOrDefault();
            Pupil timePupil = context.Pupil.Where(c => c.Id == movingPupilDto.PupilId).FirstOrDefault();
            MovingPupil newMovingPupil = mapper.Map<MovingPupil>(movingPupilDto);
            newMovingPupil.Device = timeDevice;
            newMovingPupil.Pupil = timePupil;
            newMovingPupil.Time = DateTime.Now;
            newMovingPupil = await MovingPupilService.AddMovingPupil(newMovingPupil);
            if (timeDevice.Number.Contains("e")) {
                List<MovingPupil> movepupils = (from user in context.MovingPupil.Include("Pupil").Include("Device")
                            where user.Pupil == timePupil & user.Device.Number.Contains("e")
                             select user).ToList();
                String message = newMovingPupil.Time.ToString() + " ";
                if (movepupils.Count % 2 == 0) {
                    message += "exit";
                } else {
                    message += "entry";
                }
                return Ok("message for parent: " + message);
            }
            return Ok(newMovingPupil);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovingPupil(int id)
        {
            await MovingPupilService.DeleteMovingPupil(id);
            return Ok(new
            {
               Response = "MovingPupil is deleted successfully"
            });
        }
    }
}