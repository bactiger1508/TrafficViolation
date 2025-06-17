using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    /// <summary>
    /// Interaction logic for UpdateAccountWindow.xaml
    /// </summary>
    public partial class UpdateAccountWindow : Window
    {
        private UserService _service = new();
        public User CurrentUser { get; set; }
        public UpdateAccountWindow()
        {
            InitializeComponent();
        }

        //Load thông tin tk hiện tại
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FullNameTextBox.Text = CurrentUser.FullName;
            EmailTextBox.Text = CurrentUser.Email;
            PhoneTextBox.Text = CurrentUser.Phone;
            AddressTextBox.Text = CurrentUser.Address;

            foreach (ComboBoxItem item in RoleComboBox.Items)
            {
                if (item.Content.ToString() == CurrentUser.Role)
                {
                    RoleComboBox.SelectedItem = item;
                    break;
                }
            }

            // Gọi hàm lấy thông tin từ Vehicles
            var (plateNumber, brand, model) = _service.GetVehicleDetailsByOwnerId(CurrentUser.UserId);

            PlateNumberTextBox.Text = plateNumber ?? "N/A";
            PlateNumberTextBox.IsReadOnly = true;

            VehicleNameTextBox.Text = brand ?? "N/A";
            VehicleNameTextBox.IsReadOnly = true;
            VehicleTypeTextBox.Text = model ?? "N/A";
            VehicleTypeTextBox.IsReadOnly = true;
        }




        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            // Thu thập thông tin từ giao diện
            string email = EmailTextBox.Text.Trim();
            string fullName = FullNameTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string address = AddressTextBox.Text.Trim();

            //Code validation
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng điền vào tất cả các trường", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!_service.IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ", "Lỗi email", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!_service.IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi số điện thoại", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_service.IsPhoneExist(phone) && phone != CurrentUser.Phone)
            {
                MessageBox.Show("Số điện thoại đã được sử dụng", "Lỗi số điện thoại", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            CurrentUser.FullName = fullName;
            CurrentUser.Email = email;
            CurrentUser.Phone = phone;
            CurrentUser.Address = address;

            if (RoleComboBox.SelectedItem != null)
                CurrentUser.Role = (RoleComboBox.SelectedItem as ComboBoxItem).Content.ToString();

            _service.UpdateUser(CurrentUser);

            MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Kiểm tra xem phím được nhấn có phải là Enter không
            {
                SaveChangesButton_Click(sender, e); // Gọi phương thức lưu thay đổi
            }
        }

    }
}
