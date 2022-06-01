using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public interface ILessonsService
    {
        IEnumerable<Lesson> GetAll();
        Lesson GetById(int id);
        Lesson Add(Lesson lesson);
        Lesson Delete(Lesson lesson);
        Lesson Update(int id, Lesson lesson);
    }
}
