using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public string Elements { get; set; }
        public string Verse { get; set; }
        public string reference { get; set; }     
        public string training1 { get; set; }     
        public string training2 { get; set; }     
    }
}
