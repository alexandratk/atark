using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class LessonController: ControllerBase 
    {
        private readonly ILessonService LessonService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public LessonController(MyDataContext context, ILessonService lessonService,
         IMapper mapper) {
             this.context = context;
             this.LessonService = lessonService;
             this.mapper = mapper;
         }


        [Authorize(Roles = "Administrator")]
        [HttpPost("addlesson")]
        public async Task<IActionResult> RegisterLesson([FromBody] LessonDto lessonDto)
        {
            List<Group> groups = (from user in context.Group.Include("EducationalInstitution")
                            where lessonDto.GroupId.Contains(user.Id)
                             select user).ToList();
            List<Lesson> lessons = (from user in context.Lesson
                            where user.Teacher.Id == lessonDto.TeacherId
                             select user).ToList();
            List<Lesson> free_lesson = new List<Lesson>();
            foreach (Group element in groups) {
                List<Lesson> lessons1 = (from user in context.Lesson
                            where user.Groups.Contains(element)
                             select user).ToList();
                lessons.AddRange(lessons1);
            }
            List<DateTime> date_start = new List<DateTime>();
            foreach(Lesson less in lessons) {
                date_start.Add(less.Dateofstart);
            }
            var users = (from user in context.Teacher.Include("EducationalInstitution")
                            where user.Id == lessonDto.TeacherId
                             select user).ToList();
            Teacher timeTeacher = users[0];
            List<Group> timeGroup = groups;
            Lesson newLesson = mapper.Map<Lesson>(lessonDto);
            newLesson.Teacher = timeTeacher;
            newLesson.Groups = timeGroup;
            newLesson.EducInstId = timeTeacher.EducationalInstitution.Id;
            if (date_start.Contains(newLesson.Dateofstart)) {
                return Ok("error, this lesson is busy");
            }
            newLesson = await LessonService.AddLesson(newLesson);
            return Ok(newLesson);
        }


        [Authorize(Roles = "Administrator")]
        [HttpPost("findpoint")]
        public async Task<IActionResult> FindPoint([FromBody] FindPointHelper findPointHelper)
        {
            var result = LessonService.FindPoint(findPointHelper);
            return Ok(result);
        }


        [HttpGet("teacher/timetable/{id}")]
        public async Task<IActionResult> TeacherTimeTable(int id)
        {
            var result = LessonService.FindTeacherTimeTable(id);
            return Ok(result);
        }


        [HttpGet("pupil/timetable/{id}")]
        public async Task<IActionResult> PupilTimeTable(int id)
        {
            var result = LessonService.FindPupilTimeTable(id);
            return Ok(result);
        }



        [Authorize(Roles = "Teacher, Administrator")]
        [HttpPost("lessonmovpupil")]
        public async Task<IActionResult> AttendanceAtLesson([FromBody] AttendanceLesson attendanceLesson)
        {
            Lesson lesson = (from user in context.Lesson.Include("Groups")
                    where user.Teacher.Id == attendanceLesson.TeacherId & user.Dateofstart == attendanceLesson.Dateofstart
                    select user).ToList()[0];
            var groupOnLesson = lesson.Groups;
            List<Pupil> pupilAllGroup = new List<Pupil>();
            foreach(Group element in groupOnLesson){
                List<Pupil> pupil = (from user in context.Pupil
                    where user.Group.Id == element.Id
                    select user).ToList();
                pupilAllGroup.AddRange(pupil);
            }
            List<Pupil> pupilOnLesson = new List<Pupil>();
            List<Pupil> pupilNotOnLesson = new List<Pupil>();
            foreach(Pupil element in pupilAllGroup) {
                Console.WriteLine(attendanceLesson.Dateofstart + "//////");
                List<MovingPupil> movepupil = (from user in context.MovingPupil
                    where user.Pupil == element & user.Time <= attendanceLesson.Dateofstart
                    select user).ToList();
                    if (movepupil == null || movepupil.Count % 2 == 0) {
                        pupilNotOnLesson.Add(element);
                    } else {
                        pupilOnLesson.Add(element);
                    }
                
            }
            return Ok(pupilNotOnLesson);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await LessonService.DeleteLesson(id);
            return Ok(new
            {
               Response = "Lesson is deleted successfully"
            });
        }
    }
}