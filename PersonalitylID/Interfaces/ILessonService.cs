using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Helpers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PersonalityIdentification.Helpers;

namespace PersonalityIdentification.Itrefaces
{
    public interface ILessonService
    {
         Task<Lesson> AddLesson(Lesson newLesson);
         List<String> FindPoint(FindPointHelper findPointHelper);
         List<Lesson> FindTeacherTimeTable(int id);
         List<Lesson> FindPupilTimeTable(int id);
         List<Lesson> FindGroupTimeTable(int id);
         List<Lesson> FindTimeTable(int id);
         Task DeleteLesson(int LessonId);
    }
}