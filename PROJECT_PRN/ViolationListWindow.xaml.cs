using System.Windows;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    public partial class ViolationListWindow : Window
    {
        private readonly ViolationService _violationService = new();
        public User CurrentUser { get; set; }

        public ViolationListWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.Role == "Admin" || CurrentUser.Role == "TrafficPolice")
            {
                AllViolationsTab.Visibility = Visibility.Visible;
                YourViolationsTab.Visibility = Visibility.Visible;

                AllViolationsDataGrid.ItemsSource = GetProcessedViolations(_violationService.GetAllViolations());
                YourViolationsDataGrid.ItemsSource = GetProcessedViolations(_violationService.GetViolationsByUserId(CurrentUser.UserId));

                ViolationTabControl.SelectedIndex = 0;

                // Hiển thị tổng tiền chưa thanh toán cho tất cả người dùng
                UpdateTotalUnpaidFinesForAllUsersLabel();
            }
            else if (CurrentUser.Role == "Citizen")
            {
                AllViolationsTab.Visibility = Visibility.Collapsed;
                YourViolationsTab.Visibility = Visibility.Visible;

                YourViolationsDataGrid.ItemsSource = GetProcessedViolations(_violationService.GetViolationsByUserId(CurrentUser.UserId));

                ViolationTabControl.SelectedIndex = 1;

                // Hiển thị tổng tiền phạt chưa thanh toán cho Citizen
                UpdateTotalUnpaidFinesLabel(CurrentUser.UserId);
            }
        }

        private void UpdateTotalUnpaidFinesLabel(int userId)
        {
            decimal totalUnpaidFines = _violationService.CalculateTotalUnpaidFines(userId);
            TotalUnpaidFinesLabel.Content = $"Tổng tiền phạt chưa nộp của bạn: {totalUnpaidFines:C}";
        }

        private void UpdateTotalUnpaidFinesForAllUsersLabel()
        {
            decimal totalUnpaidFinesForAll = _violationService.CalculateTotalUnpaidFinesForAllUsers();
            TotalUnpaidFinesForAllUsersLabel.Content = $"Tổng hợp tất cả tiền phạt chưa nộp: {totalUnpaidFinesForAll:C}";
            TotalUnpaidFinesForAllUsersLabel.Visibility = Visibility.Visible; // Hiển thị Label
        }

        private void UpdateTotalPaidFinesLabel(int userId)
        {
            decimal totalPaidFines = _violationService.CalculateTotalPaidFines(userId);
            TotalPaidFinesLabel.Content = $"Tổng tiền phạt đã nộp của bạn: {totalPaidFines:C}";
        }

        private void UpdateTotalPaidFinesForAllUsersLabel()
        {
            decimal totalPaidFinesForAll = _violationService.CalculateTotalPaidFinesForAllUsers();
            TotalPaidFinesForAllUsersLabel.Content = $"Tổng hợp tất cả tiền phạt đã nộp: {totalPaidFinesForAll:C}";
            TotalPaidFinesForAllUsersLabel.Visibility = Visibility.Visible;
        }

        private void ViolationTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ViolationTabControl.SelectedItem == AllViolationsTab)
            {
                UpdateTotalUnpaidFinesForAllUsersLabel();
                UpdateTotalPaidFinesForAllUsersLabel();
                TotalUnpaidFinesLabel.Visibility = Visibility.Collapsed;
                TotalPaidFinesLabel.Visibility = Visibility.Collapsed;
                PayButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                UpdateTotalUnpaidFinesLabel(CurrentUser.UserId);
                UpdateTotalPaidFinesLabel(CurrentUser.UserId);
                TotalUnpaidFinesLabel.Visibility = Visibility.Visible;
                TotalPaidFinesLabel.Visibility = Visibility.Visible;
                TotalUnpaidFinesForAllUsersLabel.Visibility = Visibility.Collapsed;
                TotalPaidFinesForAllUsersLabel.Visibility = Visibility.Collapsed;
                PayButton.Visibility = Visibility.Visible;
            }
        }


        private List<dynamic> GetProcessedViolations(List<Violation> violations)
        {
            return violations.Select(v => new
            {
                ViolationId = v.ViolationId, // Đảm bảo ID tồn tại
                UserName = v.Violator?.FullName ?? "Unknown",
                PlateNumber = v.PlateNumber,
                FineAmount = v.FineAmount,
                FineDate = v.FineDate.HasValue
                            ? v.FineDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")
                            : "N/A",
                FineStatus = v.PaidStatus == true ? "Paid" : "Unpaid"
            }).ToList<dynamic>();
        }




        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedViolation = YourViolationsDataGrid.SelectedItem;

            if (selectedViolation == null)
            {
                MessageBox.Show("Vui lòng chọn một vi phạm để thanh toán.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra xem selectedViolation có ViolationId không
            if (!selectedViolation.GetType().GetProperty("ViolationId")?.CanRead ?? true)
            {
                MessageBox.Show("Không thể truy xuất ViolationId từ dữ liệu đã chọn.", "Lỗi hệ thống", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int violationId = selectedViolation.ViolationId;

            // Làm mới danh sách từ cơ sở dữ liệu
            var updatedViolations = _violationService.GetViolationsByUserId(CurrentUser.UserId);

            // Tìm lại vi phạm bằng ViolationId
            var originalViolation = updatedViolations.FirstOrDefault(v => v.ViolationId == violationId);

            if (originalViolation == null)
            {
                MessageBox.Show("Không tìm thấy vi phạm trong hệ thống.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (originalViolation.PaidStatus == true)
            {
                MessageBox.Show("Vi phạm này đã được thanh toán.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Cập nhật trạng thái thanh toán
            originalViolation.PaidStatus = true;
            _violationService.UpdateViolation(originalViolation);

            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Cập nhật lại danh sách hiển thị
            AllViolationsDataGrid.ItemsSource = GetProcessedViolations(_violationService.GetAllViolations());
            YourViolationsDataGrid.ItemsSource = GetProcessedViolations(_violationService.GetViolationsByUserId(CurrentUser.UserId));

            YourViolationsDataGrid.Items.Refresh();

        }

        private void SearchViolationButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PlateNumberTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập biển số xe!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string plateNumber = PlateNumberTextBox.Text.Trim();
            var userViolations = _violationService.GetViolationsByUserId(CurrentUser.UserId);

            bool hasOwnPlateNumber = userViolations.Any(v => v.PlateNumber == plateNumber);
            if (!hasOwnPlateNumber)
            {
                MessageBox.Show("Bạn không có xe nào có biển số này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Kiểm tra logic ngày
            bool hasFromDate = FromDatePicker.SelectedDate != null;
            bool hasToDate = ToDatePicker.SelectedDate != null;

            if (hasFromDate && !hasToDate)
            {
                MessageBox.Show("Vui lòng chọn ngày kết thúc!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!hasFromDate && hasToDate)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var filteredViolations = userViolations
                .Where(v => v.PlateNumber == plateNumber)
                .ToList();

            if (hasFromDate && hasToDate)
            {
                DateTime fromDate = FromDatePicker.SelectedDate.Value;
                DateTime toDate = ToDatePicker.SelectedDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                filteredViolations = filteredViolations
                    .Where(v => v.FineDate >= fromDate && v.FineDate <= toDate)
                    .ToList();
            }

            YourViolationsDataGrid.ItemsSource = GetProcessedViolations(filteredViolations);
        }


        private void SearchAllViolationsButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AllPlateNumberTextBox.Text))
            {
                MessageBox.Show("Vui lòng nhập biển số xe!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string plateNumber = AllPlateNumberTextBox.Text.Trim();
            var allViolations = _violationService.GetAllViolations();

            // Kiểm tra logic ngày
            bool hasFromDate = AllFromDatePicker.SelectedDate != null;
            bool hasToDate = AllToDatePicker.SelectedDate != null;

            if (hasFromDate && !hasToDate)
            {
                MessageBox.Show("Vui lòng chọn ngày kết thúc!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!hasFromDate && hasToDate)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var filteredViolations = allViolations
                .Where(v => v.PlateNumber == plateNumber)
                .ToList();

            if (hasFromDate && hasToDate)
            {
                DateTime fromDate = AllFromDatePicker.SelectedDate.Value;
                DateTime toDate = AllToDatePicker.SelectedDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi nhập liệu", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                filteredViolations = filteredViolations
                    .Where(v => v.FineDate >= fromDate && v.FineDate <= toDate)
                    .ToList();
            }

            AllViolationsDataGrid.ItemsSource = GetProcessedViolations(filteredViolations);
        }



    }
}
