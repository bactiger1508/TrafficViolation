using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolation.DAL;
using TrafficViolation.DAL.Entities;
using TrafficViolation.DAL.Repositories;

namespace TrafficViolation.BLL.Services
{
    //GUI-UI <-> SERVICES <-> REPO <-> DBCONTEXT <-> TABLE IN SQLSERVER, MYSQL...
    // L1           L2         L3 
    // UI           BLL        DAL
    public class ReportService
    {
        private ReportRepository _repo = new();
        private NotificationRepository _notificationRepo = new();
        private ViolationRepository _violationRepo = new();
        private VehicleRepository _vehicleRepo = new();
        //Hàm CRUD++
        public List<Report> GetAllReports()
        {
            return _repo.GetAll();
        }
        public List<Report> GetReportsByReporterID(int reporterID)
        {
            return _repo.GetReportsByReporterID(reporterID);
        }

        public void AddReport(Report x)
        {
            _repo.Add(x);
        }

        public void UpdateReport(Report x)
        {
            _repo.Update(x);
        }

        public void DeleteReport(Report x)
        {
            _repo.Delete(x);
        }

        public List<Report> GetPendingReports()
        {
            return _repo.GetPendingReports();
        }

        public void UpdateReportStatus(Report report)
        {
            _repo.Update(report);
        }

        public void CreateNotification(Notification notification)
        {
            _notificationRepo.Add(notification);
        }

        // Updated CreateViolation method with proper error handling
        public void CreateViolation(Violation violation)
        {
            if (violation == null)
                throw new ArgumentNullException(nameof(violation));

            // Check if the report exists
            if (!_repo.ReportExists(violation.ReportId))
                throw new InvalidOperationException("Invalid report referenced.");

            try
            {
                // Use the ViolationRepository to add the violation
                _violationRepo.Add(violation);
            }
            catch (Exception ex)
            {
                // Log the exception (you might want to use a logging framework)
                throw new ApplicationException("Error creating violation", ex);
            }
        }

        public int? GetVehicleOwnerIdByPlateNumber(string plateNumber)
        {
            using var context = new PrnProjectContext();
            var vehicle = context.Vehicles.FirstOrDefault(v => v.PlateNumber == plateNumber);

            return vehicle?.OwnerId;
        }
        public bool CheckPlateNumberExists(string plateNumber)
        {
            ReportRepository repo = new();
            return repo.DoesPlateNumberExist(plateNumber);
        }
        public List<Report> SearchReports(string plateNumber, DateTime? fromDate, DateTime? toDate)
        {
            using var context = new PrnProjectContext();
            var query = context.Reports.Include(r => r.PlateNumberNavigation).AsQueryable();

            if (!string.IsNullOrWhiteSpace(plateNumber))
            {
                query = query.Where(r => r.PlateNumber.Contains(plateNumber));
            }

            if (fromDate.HasValue && toDate.HasValue)
            {
                if (fromDate > toDate)
                    throw new ArgumentException("From date must be earlier than To date.");

                query = query.Where(r => r.ReportDate >= fromDate && r.ReportDate <= toDate);
            }
            else if (fromDate.HasValue)
            {
                query = query.Where(r => r.ReportDate >= fromDate);
            }
            else if (toDate.HasValue)
            {
                query = query.Where(r => r.ReportDate <= toDate);
            }

            return query.ToList();
        }


    }
}
