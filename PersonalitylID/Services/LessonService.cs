using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using PersonalityIdentification.Dtos;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PersonalityIdentification.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace PersonalityIdentification.Services
{
    public class LessonService: ILessonService
    {
        private readonly MyDataContext database;

        public LessonService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Lesson> AddLesson(Lesson newLesson)
        {
            await database.Lesson.AddAsync(newLesson);
            await database.SaveChangesAsync();
            var groups = newLesson.Groups;
            var pupils = (from item in database.Pupil.Include("Group")
                         where groups.Contains(item.Group)
                          select item).ToList();
            for (int i = 0; i < pupils.Count; i++) {
                Mark newMark = new Mark();
                newMark.Lesson = newLesson;
                newMark.Pupil = pupils[i];
                newMark.Description = newLesson.Description;
                newMark.LessonMark = "";
                newMark.DateTimeMark = newLesson.Dateoffinish;
                await database.Mark.AddAsync(newMark);
                await database.SaveChangesAsync();
            }
            return newLesson;
        }

        public List<Lesson> FindTeacherTimeTable(int id) {
            List<Lesson> lessonsTeacher = (from user in database.Lesson.Include("Teacher").Include("Groups")
                where user.Teacher.Id == id orderby user.Dateofstart
                    select user).ToList();
            return lessonsTeacher;
        }

        public List<Lesson> FindPupilTimeTable(int id) {
            Pupil pupil = (from user in database.Pupil.Include("Group")
                where user.Id == id
                    select user).ToList()[0];
            List<Lesson> lessonsTeacher = (from user in database.Lesson
                where user.Groups.Contains(pupil.Group)
                    select user).ToList();
            return lessonsTeacher;
        }

        public List<Lesson> FindGroupTimeTable(int id) {
            Group pupil = (from user in database.Group
                where user.Id == id
                    select user).ToList()[0];
            List<Lesson> lessonsTeacher = (from user in database.Lesson.Include("Teacher").Include("Groups")
                where user.Groups.Contains(pupil) orderby user.Dateofstart
                    select user).ToList();
            return lessonsTeacher;
        }

        public List<Lesson> FindTimeTable(int id) {
            List<Lesson> lessonsTeacher = (from user in database.Lesson.Include("Teacher").Include("Groups")
                              where user.EducInstId == id 
                              orderby user.Dateofstart  
                        select user).ToList();
            return lessonsTeacher;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public List<String> sort_lessons(List<String> lessons, List<int> window) {
            bool flag = true;
            while (flag) {
                flag = false;
                for (int i = 1; i < lessons.Count; i++) {
                    if (window[i] < window[i - 1]) {
                        String t = lessons[i];
                        lessons[i] = lessons[i - 1];
                        lessons[i - 1] = t;
                        int t1 = window[i];
                        window[i] = window[i - 1];
                        window[i - 1] = t1;
                        flag = true;
                    }
                }
            }
            for (int i = 0; i < lessons.Count; i++) {
                lessons[i] = lessons[i] + " " + window[i].ToString();
            }
            return lessons;
        }

        public List<String> findLessonsTeacher(FindPointHelper findPointHelper) {
            List<Lesson> lessonsTeacherL = (from user in database.Lesson
                            where user.Teacher.Id == findPointHelper.TeacherId &
                             user.Dateofstart >= findPointHelper.Dateofstart &
                              user.Dateoffinish <= findPointHelper.Dateoffinish.AddDays(1)
                             select user).ToList();
            List<String> lessonsTeacher = new List<String>();
            foreach(Lesson element in lessonsTeacherL) {
                String str = element.Dateofstart.ToString() + "-" + element.Dateoffinish.TimeOfDay.ToString();
                lessonsTeacher.Add(str);
            }
            return lessonsTeacher;
        }

        public List<String> FindPoint(FindPointHelper findPointHelper) {
            findPointHelper.GroupsId = new List<int>();
            if (findPointHelper.strGroupsId != "") {
                string[] temp = findPointHelper.strGroupsId.Split('$');
                for (int i = 0; i < temp.Length; i++){
                findPointHelper.GroupsId.Add(Convert.ToInt32(temp[i]));
                }
            }
            List<Group> groups = (from user in database.Group.Include("EducationalInstitution")
                            where findPointHelper.GroupsId.Contains(user.Id)
                             select user).ToList();
            List<String> lessonsTeacher = findLessonsTeacher(findPointHelper);
            List<List<Lesson>> lessonsGroups = new List<List<Lesson>>();
            List<List<DateTime>> lessonsGroupsDate = new List<List<DateTime>>();
            foreach (Group element in groups) {
                lessonsGroups.Add(new List<Lesson>());
                lessonsGroupsDate.Add(new List<DateTime>());
                int index = lessonsGroups.Count - 1;
                lessonsGroups[index] = (from user in database.Lesson
                            where user.Groups.Contains(element) &
                             user.Dateofstart >= findPointHelper.Dateofstart &
                              user.Dateoffinish <= findPointHelper.Dateoffinish.AddDays(1)
                             select user).ToList();
                foreach(Lesson elementLesson in lessonsGroups[index]) {
                    lessonsGroupsDate[index].Add(elementLesson.Dateofstart);
                }
            }

            
            EducationalInstitution timeEducationalInstitution = database.EducationalInstitution.Where(c => c.Id == findPointHelper.EducInstId).FirstOrDefault();
            String[] daysweek = timeEducationalInstitution.Timetable.Split('#');
            List<List<String>> daysWeekTableStart = new List<List<String>>();
            List<List<String>> daysWeekTableFinish = new List<List<String>>();
            for(int i = 0; i < daysweek.Length; i++) {
                daysWeekTableStart.Add(new List<String>());
                daysWeekTableFinish.Add(new List<String>());
                foreach(String t in daysweek[i].Split("/")) {
                    if (t != "") {
                        daysWeekTableStart[i].Add((t.Split("-"))[0]);
                        daysWeekTableFinish[i].Add((t.Split("-"))[1]);
                    }
                }
            }

            List<List<String>> freeLessonsPupil = new List<List<String>>();
            List<List<int>> freeLessonsPupilWindow = new List<List<int>>();
            for (int i = 0; i < lessonsGroups.Count; i++) {
                freeLessonsPupil.Add(new List<String>());
                freeLessonsPupilWindow.Add(new List<int>());
                foreach (DateTime day in EachDay(findPointHelper.Dateofstart, findPointHelper.Dateoffinish)) {
                    int indexDayWeek = ((int)day.DayOfWeek + 6) % 7;
                    int counter_window = 0;
                    for (int j = 0; j < daysWeekTableStart[indexDayWeek].Count; j++) {
                        string s = day.ToString("d") + " " + daysWeekTableStart[indexDayWeek][j];
                        DateTime t = DateTime.Parse(s);
                        if (!lessonsGroupsDate[i].Contains(t)) {
                            freeLessonsPupilWindow[i].Add(counter_window);
                            freeLessonsPupil[i].Add(t.ToString() + "-" + daysWeekTableFinish[indexDayWeek][j]);
                            Console.WriteLine(t.ToString() + "-" + daysWeekTableFinish[indexDayWeek][j] + " " + counter_window);
                            Console.WriteLine("////////");
                            counter_window++;
                        }
                    }
                }
            }
            List<String> result = new List<String>();
            List<int> resultWindow = new List<int>();
            if (freeLessonsPupil.Count > 1) {
                for(int i = 0; i < freeLessonsPupil[0].Count; i++) {
                    bool flagFirst = true;
                    int counterWindow = 0;
                    for (int j = 1; j < freeLessonsPupil.Count & flagFirst; j++) {
                        bool flagSecond = false;
                        for (int k = 0; k < freeLessonsPupil[j].Count & !flagSecond; k++) {
                            if (freeLessonsPupil[j][k] == freeLessonsPupil[0][i]) {
                                flagSecond = true;
                                counterWindow += freeLessonsPupilWindow[j][k];
                            }
                        }
                        if (!flagSecond) {
                            flagFirst = false;
                        }
                    }
                    if (flagFirst) {
                        result.Add(freeLessonsPupil[0][i]);
                        resultWindow.Add(counterWindow);
                    }
                }
            } else {
                result = freeLessonsPupil[0];
                resultWindow = freeLessonsPupilWindow[0];
            }
            
            for (int i = 0; i < result.Count; i++) {
                if (lessonsTeacher.Contains(result[i])) {
                    result.RemoveAt(i);
                    resultWindow.RemoveAt(i);
                    i--;
                }
            }
            result = sort_lessons(result, resultWindow);
            return result;
        }

        public async Task DeleteLesson(int LessonId)
        {
            var deletingLessonDescription =
             await database.Lesson.FirstOrDefaultAsync(p => p.Id == LessonId);

            if (deletingLessonDescription is null)
                throw new System.Exception("No proper Lesson found");

            database.Lesson.Remove(deletingLessonDescription);
            await database.SaveChangesAsync();

        }
    }
}