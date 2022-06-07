using AvaMina.Models;
using AvaMina.Repositories;
using AvaMina.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IReportRepository _report;
        public ReportsService(IReportRepository report)
        {
            _report = report;
        }
        public IEnumerable<PersonReportViewModel> GetAllPersonReports(int id)
        {
            return _report.GetPersonWithReport(id).OrderByDescending(c => c.CreatedOn);
        }
        public Report GetReportById(int id)
        {
            return _report.Find(id);
        }
        public Report AddReport(int id, Report report)
        {
            report.Id = 0;
            report.CreatedOn = DateTime.Now;
            report.PersonId = id;
            //report.Deacon = false;

            _report.Add(report);
            return report;
        }
        public Report UpdateReport(int id, Report report)
        {
            report.CreatedOn = DateTime.Now;
            //report.PersonId = id;
            //report.Deacon = false;

            _report.Update(id, report);
            return report;
        }
        public Report DeleteReport(Report report)
        {
            _report.Remove(report);
            return report;
        }
        public PersonReportViewModel GetPersonReport(int id)
        {
            return _report.GetReportWithPersonByID(id);
        }
    }
}
    