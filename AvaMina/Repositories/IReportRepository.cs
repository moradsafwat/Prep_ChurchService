using AvaMina.Models;
using AvaMina.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {
       IEnumerable<PersonReportViewModel> GetPersonWithReport(int id);
        PersonReportViewModel GetReportWithPersonByID(int id);


    }
}
