    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaMina.Models;
using AvaMina.Repositories;
using AvaMina.Services;
using AvaMina.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AvaMina.Controllers
{
    [Authorize(Roles = "User")]
    public class ReportController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IReportsService _reportsService;

        public ReportController(ILogger<EventController> logger,
            IReportsService reportsService)
        {
            _logger = logger;
            _reportsService = reportsService;
        }
        // GET: ReportController
        public ActionResult Reports(int id)
        {
            var reprots = _reportsService.GetAllPersonReports(id);
            if(reprots.Any()) { 
                return View(reprots);
            }
            else
            {
                return View();
                //return RedirectToAction("People", "People");
            }
        }

        // GET: ReportController/Create
        public ActionResult CreateReport(int id)
        {
            return View();
        }

        // POST: ReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReport(int id, Report report)
        {
            _reportsService.AddReport(id, report);
            return RedirectToAction("People", "People");
        }

        // GET: ReportController/Edit/5
        public ActionResult EditReport(int id)
        {
            var report = _reportsService.GetReportById(id);
            return View(report);
        }

        // POST: ReportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReport(int id, Report report)
        {
            _reportsService.UpdateReport(id, report);
            return RedirectToAction("People", "People");
        }

        // GET: ReportController/Delete/5
        public ActionResult DeleteReport(int id)
        {
            var reprots = _reportsService.GetPersonReport(id);
            if (reprots != null)
            {
                return View(reprots);
            }
            else
            {
                return RedirectToAction("People", "People");
            }
        }

        // POST: ReportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReport(int id, Report report)
        {
            _reportsService.DeleteReport(report);
            return RedirectToAction("People", "People");
        }
    }
}
