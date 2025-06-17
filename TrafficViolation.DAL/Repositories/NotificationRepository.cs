using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficViolation.DAL.Entities;

namespace TrafficViolation.DAL.Repositories
{
    public class NotificationRepository
    {
        private PrnProjectContext _context;

        public List<Notification> GetNotificationsByUser(int userId)
        {
            _context = new();
            return _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.SentDate)
                .ToList();
        }

        public void Add(Notification notification)
        {
            _context = new();
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public void MarkAsRead(int notificationId)
        {
            _context = new();
            var notification = _context.Notifications.Find(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                _context.SaveChanges();
            }
        }

        public int GetUnreadNotificationsCount(int userId)
        {
            _context = new();
            return _context.Notifications
                .Count(n => n.UserId == userId && n.IsRead == false);
        }

        public void MarkAllAsRead(int userId)
        {
            // Triển khai logic đánh dấu tất cả thông báo của người dùng là đã đọc

            _context = new();
            var unreadNotifications = _context.Notifications
                .Where(n => n.UserId == userId && n.IsRead == false)
                .ToList();

            foreach (var notification in unreadNotifications)
            {
                notification.IsRead = true;
            }

            _context.SaveChanges();

        }
        public Notification CreateNotification(Notification notification)
        {
            if (_context == null)
            {
                _context = new PrnProjectContext();
            }
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return notification;

        }
    }
}
