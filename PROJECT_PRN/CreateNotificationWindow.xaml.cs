using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    public partial class CreateNotificationWindow : Window
    {
        private readonly NotificationService _notificationService = new NotificationService();
        private readonly UserService _userService = new UserService();
        private readonly User _currentUser;
        private List<User> _allUsers;
        private List<User> _filteredUsers;

        public CreateNotificationWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            InitializeNotificationOptions();
        }

        private void InitializeNotificationOptions()
        {
            RbAllUsers.IsChecked = true;
            UserSearchPanel.Visibility = Visibility.Collapsed;
            _allUsers = _userService.GetAllUsers();
        }

        private void RbAllUsers_Checked(object sender, RoutedEventArgs e)
        {
            UserSearchPanel.Visibility = Visibility.Collapsed;
            UserListView.ItemsSource = null;
        }

        private void RbSpecificUser_Checked(object sender, RoutedEventArgs e)
        {
            UserSearchPanel.Visibility = Visibility.Visible;
            UserListView.ItemsSource = _allUsers;
        }

        private void UserSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = UserSearchTextBox.Text.ToLower();
            _filteredUsers = _allUsers
                .Where(u => u.FullName.ToLower().Contains(searchText) ||
                            u.Email.ToLower().Contains(searchText))
                .ToList();
            UserListView.ItemsSource = _filteredUsers;
        }

        private void SendNotificationButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung thông báo.", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (RbAllUsers.IsChecked == true)
                {
                    _notificationService.CreateNotificationForAllUsers(MessageTextBox.Text);
                }
                else
                {
                    var selectedUsers = UserListView.SelectedItems.Cast<User>().ToList();
                    if (selectedUsers.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một người dùng.", "Lỗi",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    _notificationService.CreateNotificationForSpecificUsers(selectedUsers, MessageTextBox.Text);
                }

                MessageBox.Show("Thông báo đã được gửi thành công.", "Thành Công",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi thông báo: {ex.Message}", "Lỗi",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}