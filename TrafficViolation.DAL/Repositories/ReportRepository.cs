using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrafficViolation.DAL.Entities;

namespace TrafficViolation.DAL.Repositories
{
    //GUI-UI <-> SERVICES <-> REPO <-> DBCONTEXT <-> TABLE IN SQLSERVER, MYSQL...
    // L1           L2         L3 
    // UI           BLL        DAL
    public class ReportRepository
    {
        private PrnProjectContext _context;

        //Hàm CRUD ứng với 4 lệnh sql cơ bản: INSERT, SELECT, UPDATE, DELETE
        public List<Report> GetAll()
        {
            _context = new();
            return _context.Reports.Include("PlateNumberNavigation").ToList();
        }

        public List<Report> GetReportsByReporterID(int reporterID)
        {
            _context = new();
            return _context.Reports
                .Include("PlateNumberNavigation")
                .Where(r => r.ReporterId == reporterID)
                .ToList();
        }

        public void Add(Report x)
        {
            _context = new();
            _context.Reports.Add(x);
            _context.SaveChanges();
        }

        public void Update(Report x)
        {
            _context = new();
            _context.Reports.Update(x);
            _context.SaveChanges();
        }

        public void Delete(Report x)
        {
            _context = new();
            _context.Reports.Remove(x);
            _context.SaveChanges();
        }

        public List<Report> GetPendingReports()
        {
            _context = new();
            return _context.Reports
                .Where(r => r.Status == "Pending")
                .Include("PlateNumberNavigation")
                .ToList();
        }

        public bool DoesPlateNumberExist(string plateNumber)
        {
            _context = new PrnProjectContext();
            return _context.Vehicles.Any(v => v.PlateNumber == plateNumber);
        }

        public bool ReportExists(int reportId)
        {
            _context = new();
            return _context.Reports.Any(r => r.ReportId == reportId);
        }
    }
}
