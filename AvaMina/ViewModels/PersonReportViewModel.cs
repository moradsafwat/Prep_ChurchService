using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.ViewModels
{
    public class PersonReportViewModel
    {
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string FatherJob { get; set; }
        public string MotherJob { get; set; }
        public string FinancialLevel { get; set; }
        public string FatherOfConfession { get; set; }
        public bool Deacon { get; set; }
        public string NumberOfBrothers { get; set; }
        public string Attendance { get; set; }
        public string Hobbies { get; set; }
        public string Reports { get; set; }

        public int PersonId { get; set; }
    }
}
