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
    public class UserService
    {
        private UserRepository _repo = new();

        // Xác thực toàn bộ thông tin đăng nhập
        public User Authenticate(string email, string password)
        {
            var user = _repo.GetOneByEmail(email);
            if (user == null) return null;

            return user.Password == password ? user : null;
        }
        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
        public void UpdateUser(User user)
        {
            _repo.UpdateUser(user);
        }

        public void DeleteUser(User user)
        {
            _repo.DeleteUser(user);
        }


        public bool IsEmailExist(string email)
        {
            return _repo.IsEmailExist(email);
        }

        public bool IsPhoneExist(string phone)
        {
            return _repo.IsPhoneExist(phone);
        }

        public string RegisterUser(User user)
        {
            if (_repo.IsEmailExist(user.Email))
            {
                return "Email đã tồn tại. Vui lòng sử dụng email khác.";
            }
            if (_repo.IsPhoneExist(user.Phone))
            {
                return "Số điện thoại đã được sử dụng. Vui lòng sử dụng số khác.";
            }
            _repo.AddUser(user);
            return "Đăng ký thành công";
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPhoneNumber(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 9 && phone.Length <= 12;
        }

        public (string? PlateNumber, string? Brand, string? Model) GetVehicleDetailsByOwnerId(int ownerId)
        {
            return _repo.GetVehicleDetailsByOwnerId(ownerId);
        }
        public List<string> GetDistinctAddresses()
        {
            return _repo.GetDistinctAddresses();
        }


    }

}
