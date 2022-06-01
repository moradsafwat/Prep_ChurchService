using AvaMina.Models;
using AvaMina.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonRepository _lesson;

        public LessonsService(ILessonRepository lesson)
        {
            _lesson = lesson;
        }

        public IEnumerable<Lesson> GetAll()
        {
            return _lesson.List().OrderBy(d => d.Date);
        }
        public Lesson GetById(int id)
        {
            return _lesson.Find(id);
        }
        public Lesson Add(Lesson lesson)
        {
            _lesson.Add(lesson);
            return lesson;
        }

        public Lesson Delete(Lesson lesson)
        {
            _lesson.Remove(lesson);
            return lesson;
        }



        public Lesson Update(int id, Lesson lesson)
        {
            _lesson.Update(id, lesson);
            return lesson;
        }
    }
}
