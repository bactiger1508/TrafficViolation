using System.Windows;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{

    public partial class MainWindow : Window
    {

        private ReportService _service = new();
        public User CurrentAccount { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow c = new();
            c.ShowDialog();
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Report? selected = ReportDataGrid.SelectedItem as Report;
            if(selected == null)
            {              
                MessageBox.Show("Vui lòng chọn 1 báo cáo đẻ cập nhật!", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (selected.Status == "Approved")
            {
                MessageBox.Show("Không thẻ thay đổi báo cáo đã được duyệt!", "Choose another row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            DetailWindow u = new();
            u.EditedReport = selected;
            u.ShowDialog();
            FillDataGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
            HelloMsgLabel.Content = $"Xin chào, {CurrentAccount.FullName}!";
            RoleMsgLabel.Content = $"Vai trò: {CurrentAccount.Role}";

            if (CurrentAccount.Role == "Citizen")
            {
                ManageAccountButton.Visibility = Visibility.Hidden;
                UserViolation.Content = "My violations";
            }
            if (CurrentAccount.Role == "Admin")
            {
                NotificationButton.Visibility = Visibility.Collapsed;
                ProfileButton.Visibility = Visibility.Collapsed;
                UserViolation.Content = "List violations";

                return;
            }

        }

        private void FillDataGrid()
        {
            ReportDataGrid.ItemsSource = null;
            if(CurrentAccount.Role == "Citizen")
            {
                ReportDataGrid.ItemsSource = _service.GetReportsByReporterID(CurrentAccount.UserId);
                return;
            }
            ReportDataGrid.ItemsSource = _service.GetAllReports();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void ManageAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentAccount.Role != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng Quản lý tài khoản!",
                                "Truy cập bị từ chối", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Mở cửa sổ ManageAccountWindow và truyền CurrentAccount
            ManageAccountWindow ma = new ManageAccountWindow
            {
                CurrentAccount = CurrentAccount
            };
            ma.Show();
            this.Close();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileDetailWindow profileDetailWindow = new ProfileDetailWindow
            {
                CurrentUser = CurrentAccount
            };

            profileDetailWindow.ShowDialog();
        }

        private void ManageVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            UserVehicleWindow userVehicleWindow = new UserVehicleWindow
            {
                CurrentUser = CurrentAccount
            };

            userVehicleWindow.Show();
        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UserViolation_Click(object sender, RoutedEventArgs e)
        {
            ViolationListWindow violationWindow = new ViolationListWindow();

            violationWindow.CurrentUser = this.CurrentAccount;

            violationWindow.ShowDialog();
        }

        private void NotificationButton_Click_1(object sender, RoutedEventArgs e)
        {
            NotificationWindow notificationWindow = new NotificationWindow(CurrentAccount);
            notificationWindow.ShowDialog();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string plateNumber = PlateNumberTextBox.Text;
            DateTime? fromDate = FromDatePicker.SelectedDate;
            DateTime? toDate = ToDatePicker.SelectedDate?.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_service == null)
                return;

            List<Report> reports;

            // Chỉ lấy báo cáo của riêng người dùng nếu là Citizen
            if (CurrentAccount.Role == "Citizen")
            {
                reports = _service.GetReportsByReporterID(CurrentAccount.UserId);
            }
            else
            {
                reports = _service.GetAllReports();
            }

            var filteredReports = reports.Where(r =>
                (string.IsNullOrEmpty(plateNumber) || r.PlateNumber.Contains(plateNumber)) &&
                (!fromDate.HasValue || r.ReportDate >= fromDate.Value) &&
                (!toDate.HasValue || r.ReportDate <= toDate.Value))
            .ToList();

            ReportDataGrid.ItemsSource = filteredReports;
        }


        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            PlateNumberTextBox.Clear();
            FromDatePicker.SelectedDate = null;
            ToDatePicker.SelectedDate = null;
            FillDataGrid();
        }
    }
}