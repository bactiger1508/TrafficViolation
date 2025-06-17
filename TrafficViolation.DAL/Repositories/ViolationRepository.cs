using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TrafficViolation.DAL.Entities;

namespace TrafficViolation.DAL.Repositories
{
    public class ViolationRepository
    {
        private readonly PrnProjectContext _context;

        public ViolationRepository()
        {
            _context = new PrnProjectContext();
        }

        public List<Violation> GetAll()
        {
            return _context.Violations
                .Include(v => v.PlateNumberNavigation)
                .Include(v => v.Violator)
                .ToList();
        }

        public List<Violation> GetViolationsByPlateNumber(string plateNumber)
        {
            return _context.Violations
                .Where(v => v.PlateNumber.ToLower() == plateNumber.ToLower())
                .Include(v => v.PlateNumberNavigation)
                .Include(v => v.Violator)
                .ToList();
        }

        public void Add(Violation violation)
        {
            _context.Violations.Add(violation);
            _context.SaveChanges();
        }

        public decimal GetUnpaidFinesByUser(int userId)
        {
            return _context.Violations
                .Where(v => v.ViolatorId == userId && v.PaidStatus == false)
                .Sum(v => v.FineAmount);
        }

        // Cập nhật trạng thái thanh toán
        public void Update(Violation violation)
        {
            _context.Violations.Attach(violation);
            _context.Entry(violation).Property(v => v.PaidStatus).IsModified = true;
            _context.SaveChanges();
        }

        // Chỉ lấy vi phạm của chính người dùng (Your Violations)
        public List<Violation> GetViolationsByUserId(int userId)
        {
            return _context.Violations
                .Where(v => v.ViolatorId == userId && v.Report.Status == "Approved")
                .Include(v => v.Violator)
                .Include(v => v.PlateNumberNavigation)
                .ToList();
        }

        public decimal GetTotalUnpaidFines()
        {
            return _context.Violations
                .Where(v => v.PaidStatus == false)
                .Sum(v => v.FineAmount);
        }

        public decimal GetPaidFinesByUser(int userId)
        {
            return _context.Violations
                .Where(v => v.ViolatorId == userId && v.PaidStatus == true)
                .Sum(v => v.FineAmount);
        }

        public decimal GetTotalPaidFines()
        {
            return _context.Violations
                .Where(v => v.PaidStatus == true)
                .Sum(v => v.FineAmount);
        }

        public List<Violation> GetViolationsByPlateNumberAndDate(string plateNumber, DateTime fromDate, DateTime toDate)
        {
            return _context.Violations
                .Include(v => v.Violator)
                .Include(v => v.PlateNumberNavigation)
                .Include(v => v.Report)
                .Where(v => v.PlateNumber.ToLower() == plateNumber.ToLower() &&
                            v.FineDate >= fromDate &&
                            v.FineDate <= toDate)
                .ToList();
        }

        public List<Violation> GetUserViolationsByPlateNumberAndDate(int userId, string plateNumber, DateTime fromDate, DateTime toDate)
        {
            var violations = _context.Violations
                .Include(v => v.Violator)
                .Include(v => v.PlateNumberNavigation)
                .Include(v => v.Report)
                .Where(v => v.ViolatorId == userId &&
                            v.PlateNumber.ToLower() == plateNumber.ToLower() &&
                            v.FineDate >= fromDate &&
                            v.FineDate <= toDate)
                .ToList();

            if (!violations.Any())
            {
                throw new InvalidOperationException("Bạn không có xe nào có biển số này!");
            }

            return violations;
        }

    }
}
