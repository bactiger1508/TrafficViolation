using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolation.DAL.Entities;

namespace TrafficViolation.DAL.Repositories
{
    //GUI-UI <-> SERVICES <-> REPO <-> DBCONTEXT <-> TABLE IN SQLSERVER, MYSQL...
    // L1           L2         L3 
    // UI           BLL        DAL
    public class UserRepository
    {
        private PrnProjectContext _context;

        // Lấy thông tin tài khoản chỉ bằng email
        public User? GetOneByEmail(string email)
        {
            _context = new();
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        // Kiểm tra email và mật khẩu
        public User? GetOne(string email, string password)
        {
            _context = new();
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
        }
        public List<User> GetAllUsers()
        {
            _context = new();
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            _context = new();
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            _context = new();
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUser(User user)
        {
            _context = new();
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public bool IsEmailExist(string email)
        {
            _context = new();
            return _context.Users.Any(x => x.Email.ToLower() == email.ToLower());
        }
        public bool IsPhoneExist(string phone)
        {
            _context = new();
            return _context.Users.Any(x => x.Phone == phone);
        }

        public (string? PlateNumber, string? Brand, string? Model) GetVehicleDetailsByOwnerId(int ownerId)
        {
            _context = new PrnProjectContext();
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.OwnerId == ownerId);
            if (vehicle == null)
                return (null, null, null);

            return (vehicle.PlateNumber, vehicle.Brand, vehicle.Model);
        }

        public List<string> GetDistinctAddresses()
        {
            using (var _context = new PrnProjectContext())
            {
                return _context.Users.Select(u => u.Address).Distinct().ToList();
            }
        }

    }

}
