using AvaMina.Data;
using AvaMina.Models;
using AvaMina.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext _db) : base(_db)
        {
        }

        public IEnumerable<PersonReportViewModel> GetPersonWithReport(int id)
        {
            var report = db.Reports.Include(p => p.Person).Select(p => new PersonReportViewModel 
            {
              Id = p.Id,
              FirstName = p.Person.FirstName,
              SecondName = p.Person.SecondName,
              Name = p.Name,
              CreatedOn = p.CreatedOn,
              FatherJob = p.FatherJob,
              MotherJob = p.MotherJob,
              FatherOfConfession = p.FatherOfConfession,
              Attendance = p.Attendance,
              FinancialLevel = p.FinancialLevel,
              Deacon = p.Deacon,
              Hobbies = p.Hobbies,
              NumberOfBrothers = p.NumberOfBrothers,
              Reports = p.Reports,
              PersonId = p.PersonId
            }).Where(r => r.PersonId == id).ToList();
            return report;
        }

        public PersonReportViewModel GetReportWithPersonByID(int id)
        {
            return db.Reports.Include(p => p.Person).Select(p => new PersonReportViewModel
            {
                Id = p.Id,
                FirstName = p.Person.FirstName,
                SecondName = p.Person.SecondName,
                Name = p.Name,
                CreatedOn = p.CreatedOn,
                FatherJob = p.FatherJob,
                MotherJob = p.MotherJob,
                FatherOfConfession = p.FatherOfConfession,
                Attendance = p.Attendance,
                FinancialLevel = p.FinancialLevel,
                Deacon = p.Deacon,
                Hobbies = p.Hobbies,
                NumberOfBrothers = p.NumberOfBrothers,
                Reports = p.Reports,
                PersonId = p.PersonId
            }).Where(r => r.Id == id).SingleOrDefault();
        }
    }
}
