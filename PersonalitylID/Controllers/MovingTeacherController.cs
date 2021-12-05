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
    public class MovingTeacherController: ControllerBase 
    {
        private readonly IMovingTeacherService MovingTeacherService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public MovingTeacherController(MyDataContext context, IMovingTeacherService MovingTeacherService,
         IMapper mapper) {
             this.context = context;
             this.MovingTeacherService = MovingTeacherService;
             this.mapper = mapper;
         }

        [HttpPost("addmovteach")]
        public async Task<IActionResult> RegisterMovingTeacher([FromBody] MovingTeacherDto movingTeacherDto)
        {
            Device timeDevice = context.Device.Where(c => c.Id == movingTeacherDto.DeviceId).FirstOrDefault();
            Teacher timeTeacher = context.Teacher.Where(c => c.Id == movingTeacherDto.TeacherId).FirstOrDefault();
            MovingTeacher newMovingTeacher = mapper.Map<MovingTeacher>(movingTeacherDto);
            newMovingTeacher.Device = timeDevice;
            newMovingTeacher.Teacher = timeTeacher;
            newMovingTeacher = await MovingTeacherService.AddMovingTeacher(newMovingTeacher);
            return Ok(newMovingTeacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovingTeacher(int id)
        {
            await MovingTeacherService.DeleteMovingTeacher(id);
            return Ok(new
            {
               Response = "MovingTeacher is deleted successfully"
            });
        }
    }
}