using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Models
{
    public class Event
    {
        //public int EventId { get; set; }
        public int Id { get; set; }

        //[EnumDataType(typeof(EventType))]
        public string Type { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime Date { get; set; }

        public ICollection<Person> People { get; set; }
    }
}
