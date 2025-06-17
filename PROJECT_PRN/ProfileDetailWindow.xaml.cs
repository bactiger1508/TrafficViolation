using System.Text;
using System.Windows;
using System.Windows.Input;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;
using System.Security.Cryptography;

namespace PROJECT_PRN
{
    public partial class ProfileDetailWindow : Window
    {
        public static class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(bytes);
                }
            }
        }
        public User CurrentUser { get; set; }
        private readonly UserService _service = new(); 

        public ProfileDetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser != null)
            {
                FullNameTextBox.Text = CurrentUser.FullName;
                EmailTextBox.Text = CurrentUser.Email;
                PhoneTextBox.Text = CurrentUser.Phone;
                AddressTextBox.Text = CurrentUser.Address;
            }
            else
            {
                MessageBox.Show("Không thể tải dữ liệu người dùng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveChangesButton_Click(sender, e); // Gọi phương thức xử lý cập nhật tài khoản khi nhấn Enter
            }
        }

        private void ChangePasswordTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PasswordFields.Visibility = Visibility.Visible;
            CancelTextBlock.Visibility = Visibility.Visible;
            ChangePasswordTextBlock.Visibility = Visibility.Collapsed;

            this.Height = 500;
        }

        private void CancelTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PasswordFields.Visibility = Visibility.Collapsed;
            CancelTextBlock.Visibility = Visibility.Collapsed;
            ChangePasswordTextBlock.Visibility = Visibility.Visible;

            this.Height = 400;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string address = AddressTextBox.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng điền vào tất cả các trường thông tin cá nhân!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PasswordFields.Visibility == Visibility.Visible)
            {
                string currentPassword = CurrentPasswordBox.Password;
                string newPassword = NewPasswordBox.Password;
                string confirmPassword = ConfirmPasswordBox.Password;

                if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin các trường mật khẩu!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (PasswordHelper.HashPassword(currentPassword) != CurrentUser.Password)
                {
                    MessageBox.Show("Mật khẩu hiện tại không chính xác!", "Lỗi mật khẩu", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu mới không khớp!", "Lỗi mật khẩu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (newPassword.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi mật khẩu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                CurrentUser.Password = PasswordHelper.HashPassword(newPassword); // Lưu mật khẩu đã mã hóa
            }

            CurrentUser.FullName = fullName;
            CurrentUser.Email = email;
            CurrentUser.Phone = phone;
            CurrentUser.Address = address;

            _service.UpdateUser(CurrentUser);

            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
