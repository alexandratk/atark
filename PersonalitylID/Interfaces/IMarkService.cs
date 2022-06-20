using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Helpers;
using System.Collections.Generic;
using System;

namespace PersonalityIdentification.Itrefaces
{
    public interface IMarkService
    {
        Task<Mark> AddMark(Mark newMark);
        Task<Mark> UpdateMark(Mark newMark);
        Task DeleteMark(MarkDto markDto);
        Task<Mark> GetsMarkById(int id);
        Task<List<Mark>> FindMarks(AcademicPerformance academicPerformance);
        Task<List<Pupil>> FindMarksPupils(AcademicPerformance academicPerformance);
        Task<List<Lesson>> FindMarksLessons(AcademicPerformance academicPerformance);
    }
}