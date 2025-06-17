using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Security.Cryptography;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    public partial class RegisterWindow : Window
    {
        private UserService _service = new();

        public RegisterWindow()
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

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Thu thập thông tin từ giao diện
            string email = EmailTextBox.Text.Trim();
            string password = Password.Password;
            string confirmPassword = ConfirmPassword.Password;
            string fullName = FullNameTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();


            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền vào tất cả các trường!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!_service.IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi email", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Lỗi mật khẩu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi mật khẩu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!_service.IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi số điện thoại", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_service.IsPhoneExist(phone))
            {
                MessageBox.Show("Số điện thoại đã được sử dụng!", "Lỗi số điện thoại", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mã hóa mật khẩu trước khi lưu
            string hashedPassword = PasswordHelper.HashPassword(password);

            User newUser = new User
            {
                Email = email,
                Password = hashedPassword, // Lưu mật khẩu đã mã hóa
                FullName = fullName,
                Phone = phone,
            };

            string result = _service.RegisterUser(newUser);

            MessageBox.Show(result, "Đăng ký", MessageBoxButton.OK, result == "Đăng ký thành công" ? MessageBoxImage.Information : MessageBoxImage.Warning);

            if (result == "Đăng ký thành công")
            {
                LoginWindow login = new LoginWindow();
                login.Show();
                this.Close();
            }
        }

        private void LoginTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow login = new();
            login.Show();
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterButton_Click(sender, e); // Gọi phương thức xử lý đăng ký
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
