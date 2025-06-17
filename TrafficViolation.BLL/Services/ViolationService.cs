using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolation.DAL.Entities;
using TrafficViolation.DAL.Repositories;

namespace TrafficViolation.BLL.Services
{
    public class ViolationService
    {
        private ViolationRepository _repo = new();

        public List<Violation> GetAllViolations()
        {
            return _repo.GetAll();
        }

        public List<Violation> GetViolationsByPlateNumber(string plateNumber)
        {
            return _repo.GetViolationsByPlateNumber(plateNumber);
        }
      
        public void AddViolation(Violation violation)
        {
            _repo.Add(violation);
        }

        public void UpdateViolation(Violation violation)
        {
            _repo.Update(violation);
        }

        public decimal CalculateTotalUnpaidFines(int userId)
        {
            return _repo.GetUnpaidFinesByUser(userId);
        }


       //Mới thêm
        public List<Violation> GetViolationsByUserId(int userId)
        {
            return _repo.GetViolationsByUserId(userId);
        }
        public decimal CalculateTotalUnpaidFinesForAllUsers()
        {
            return _repo.GetTotalUnpaidFines();
        }

        public decimal CalculateTotalPaidFines(int userId)
        {
            return _repo.GetPaidFinesByUser(userId);
        }

        public decimal CalculateTotalPaidFinesForAllUsers()
        {
            return _repo.GetTotalPaidFines();
        }
        public List<Violation> GetViolationsByPlateNumberAndDate(string plateNumber, DateTime fromDate, DateTime toDate)
        {
            return _repo.GetViolationsByPlateNumberAndDate(plateNumber, fromDate, toDate);
        }

        public List<Violation> GetUserViolationsByPlateNumberAndDate(int userId, string plateNumber, DateTime fromDate, DateTime toDate)
        {
            return _repo.GetUserViolationsByPlateNumberAndDate(userId, plateNumber, fromDate, toDate);
        }

    }
}
