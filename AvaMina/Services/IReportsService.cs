using AvaMina.Models;
using AvaMina.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public interface IReportsService
    {
        IEnumerable<PersonReportViewModel> GetAllPersonReports(int id);
       PersonReportViewModel GetPersonReport(int id);

        Report AddReport(int id, Report report);
        Report GetReportById(int id);
        Report UpdateReport(int id, Report report);
        Report DeleteReport(Report report);


    }
}
