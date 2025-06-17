using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;
using System.Security.Cryptography;

namespace PROJECT_PRN
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserService _service = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm hỗ trợ mã hóa mật khẩu bằng SHA-256
        /// </summary>
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Thu thập thông tin từ giao diện
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;

            // Kiểm tra tính hợp lệ của dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng điền vào tất cả các trường!", "Trường trống", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!_service.IsValidEmail(email))
            {
                MessageBox.Show("Định dạng email không hợp lệ!", "Lỗi email", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!_service.IsEmailExist(email))
            {
                MessageBox.Show("Email không tồn tại!", "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Mã hóa mật khẩu trước khi kiểm tra
            string hashedPassword = PasswordHelper.HashPassword(password);
            User account = _service.Authenticate(email, hashedPassword);

            if (account == null)
            {
                MessageBox.Show("Mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Lưu thông tin tài khoản vào Properties
            Application.Current.Properties["UserId"] = account.UserId;
            if (account.Role == "TrafficPolice")
            {
                TrafficPolice trafficPolice = new(account);
                trafficPolice.CurrentAccount = account;
                trafficPolice.Show();
            }
            else
            {
                MainWindow main = new();
                main.CurrentAccount = account;
                main.Show();
            }
            this.Close();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RegisterTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            this.Close();
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPassword.Text = PasswordBox.Password;
            txtPassword.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Collapsed;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = txtPassword.Text;
            PasswordBox.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender, e); // Gọi phương thức xử lý đăng nhập
            }
        }
    }
}
