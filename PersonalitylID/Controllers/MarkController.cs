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
using System.Collections.Generic;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class MarkController: ControllerBase 
    {
        private readonly IMarkService MarkService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public MarkController(MyDataContext context, IMarkService MarkService,
         IMapper mapper) {
             this.context = context;
             this.MarkService = MarkService;
             this.mapper = mapper;
         }

        [HttpPost("addmark")]
        public async Task<IActionResult> AddMark([FromBody] MarkDto markDto)
        {
            Lesson timeLesson = context.Lesson.Where(c => c.Id == markDto.LessonId).FirstOrDefault();
            Pupil timePupil = context.Pupil.Where(c => c.Id == markDto.PupilId).FirstOrDefault();
            Mark newMark = mapper.Map<Mark>(markDto);
            newMark.Lesson = timeLesson;
            newMark.Pupil = timePupil;
            newMark.Description = markDto.Description;
            newMark.LessonMark = markDto.LessonMark;
            newMark.DateTimeMark = DateTime.Now;
            newMark = await MarkService.AddMark(newMark);
            return Ok(newMark);
        }

        [HttpGet("getmark/{id}")]
        public async Task<IActionResult> WriteMark(int id)
        {
            var list = await MarkService.GetsMarkById(id);
            return Ok(list);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateMark(int id, [FromBody] MarkDto markDto)
        {
            var mark = await MarkService.GetsMarkById(id);
            mark.LessonMark = markDto.LessonMark;
            var updatedMark = await MarkService.UpdateMark(mark);
            return Ok(updatedMark);
        }

        [HttpPost("listmarkspupils")]
        public async Task<IActionResult> ListMarksPupils([FromBody] AcademicPerformance academicPerformance)
        {
            var listMarks = await MarkService.FindMarksPupils(academicPerformance);
            return Ok(listMarks);
        }

        [HttpPost("listmarkslessons")]
        public async Task<IActionResult> ListMarksLessons([FromBody] AcademicPerformance academicPerformance)
        {
            var listMarks = await MarkService.FindMarksLessons(academicPerformance);
            return Ok(listMarks);
        }

        [HttpPost("listmarksss")]
        public async Task<IActionResult> ListMarks([FromBody] AcademicPerformance academicPerformance)
        {
            Console.WriteLine("11");
            var listMarks = await MarkService.FindMarks(academicPerformance);
            for (int i = 0; i < listMarks.Count; i++) {
                Console.WriteLine(listMarks[i].Id);
            }
            Console.WriteLine("44");
            Console.WriteLine(listMarks.Count);
            int t = 123;
            foreach (var item in listMarks)
            {
                Console.WriteLine(item);
            }
            return Ok(listMarks);
        }

        [HttpPost("deletemark")]
        public async Task<IActionResult> DeleteMark([FromBody] MarkDto markDto)
        {
            await MarkService.DeleteMark(markDto);
            return Ok(new
            {
               Response = "Mark is deleted successfully"
            });
        }
    }
}