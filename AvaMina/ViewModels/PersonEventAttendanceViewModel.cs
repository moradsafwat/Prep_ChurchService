using AvaMina.Models;
using System;
using System.Collections.Generic;

namespace AvaMina.ViewModels
{
    public class PersonEventAttendanceViewModel
    {
        public Person Person { get; set; }
        public bool currentIsAttendent { get; set; }
        public bool previousIsAttendent { get; set; }
    }
}
