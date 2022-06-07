using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        
        //public string FullName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        
        public string PhoneNum { get; set; }
        public string FatherPhoneNum { get; set; }
        public string MotherPhoneNum { get; set; }
        public string BuildNum { get; set; }
        public string FloorNum { get; set; }
        public string ApartemntNum { get; set; }
        public string StreetName { get; set; }
        public string School { get; set; }
        public string Area { get; set; }
        public string Notes { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Report> Reports { get; set; }

    }
}
