using System;
using System.Collections.Generic;
using System.Linq;
using TrafficViolation.DAL.Entities;
using TrafficViolation.DAL.Repositories;

namespace TrafficViolation.BLL.Services
{
    public class NotificationService
    {
        private NotificationRepository _repo = new();
        private VehicleRepository _vehicleRepo = new();
        private UserRepository _userRepo = new();
        // Các phương thức hiện có
        public List<Notification> GetUserNotifications(int userId)
        {
            return _repo.GetNotificationsByUser(userId);
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            _repo.MarkAsRead(notificationId);
        }

        public void MarkAllNotificationsAsRead(int userId)
        {
            _repo.MarkAllAsRead(userId);
        }

        public int GetUnreadNotificationsCount(int userId)
        {
            return _repo.GetUnreadNotificationsCount(userId);
        }

        // Phương thức mới để tạo thông báo
        public Notification CreateNotification(int userId, string message, string plateNumber)
        {
            // Kiểm tra tính hợp lệ của thông báo
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Nội dung thông báo không được để trống.");
            }

            // Nếu plate number được cung cấp, kiểm tra tính hợp lệ
            if (!string.IsNullOrEmpty(plateNumber))
            {
                // Kiểm tra xem phương tiện có thuộc về người dùng không
                var vehicle = _vehicleRepo.GetVehicleByPlateNumber(plateNumber);
                if (vehicle == null || vehicle.OwnerId != userId)
                {
                    throw new InvalidOperationException("Phương tiện không hợp lệ.");
                }
            }

            // Tạo thông báo mới
            var notification = new Notification
            {
                UserId = userId,
                Message = message,
                PlateNumber = plateNumber,
                SentDate = DateTime.Now,
                IsRead = false
            };

            // Lưu thông báo
            return _repo.CreateNotification(notification);
        }


        // Phương thức lấy danh sách phương tiện của người dùng
        public List<Vehicle> GetUserVehicles(int userId)
        {
            return _vehicleRepo.GetVehiclesByOwner(userId);
        }

        // Phương thức mới để gửi thông báo cho tất cả người dùng
        public void CreateNotificationForAllUsers(string message)
        {
            // Lấy danh sách tất cả người dùng
            var allUsers = _userRepo.GetAllUsers();

            foreach (var user in allUsers)
            {
                CreateNotification(user.UserId, message, null);
            }
        }

        // Phương thức mới để gửi thông báo cho các người dùng cụ thể
        public void CreateNotificationForSpecificUsers(List<User> users, string message)
        {
            foreach (var user in users)
            {
                CreateNotification(user.UserId, message, null);
            }
        }
    }
}