using System.Windows;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    public partial class NotificationWindow : Window
    {
        private NotificationService _notificationService = new NotificationService();
        private User _currentUser;
        public NotificationWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            if (_currentUser.Role == "Citizen")
            {
                MarkAll.Visibility = Visibility.Collapsed;
                CreateNotification.Visibility = Visibility.Collapsed;
            }
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            NotificationsListView.ItemsSource = _notificationService.GetUserNotifications(_currentUser.UserId);
        }

        private void MarkAllReadButton_Click(object sender, RoutedEventArgs e)
        {
            _notificationService.MarkAllNotificationsAsRead(_currentUser.UserId);
            LoadNotifications();
        }

        // Thêm phần tạo thông báo mới
        private void CreateNotificationButton_Click(object sender, RoutedEventArgs e)
        {
            // Mở cửa sổ tạo thông báo mới
            CreateNotificationWindow createNotificationWindow = new CreateNotificationWindow(_currentUser);
            createNotificationWindow.ShowDialog();

            // Làm mới danh sách thông báo sau khi tạo
            LoadNotifications();
        }
           private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Đóng cửa sổ NotificationWindow
        }

    }
}
