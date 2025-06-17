using System.Transactions;
using System.Windows;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    public partial class TrafficPolice : Window
    {
        private readonly ReportService _reportService = new();
        public User CurrentAccount { get; set; }

        public TrafficPolice(User currentUser)
        {
            InitializeComponent();
            CurrentAccount = currentUser;
            UserNameTextBlock.Text = CurrentAccount.FullName;
            UserRoleTextBlock.Text = CurrentAccount.Role;
            LoadReports();
        }

        private void LoadReports()
        {
            ReportsDataGrid.ItemsSource = _reportService.GetPendingReports();
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReportsDataGrid.SelectedItem is not Report selectedReport)
            {
                MessageBox.Show("Please select a report to view details.", "No Report Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                ReportsDataGrid.UnselectAll();
                return;
            }

            ViewDetailWindow detailWindow = new()
            {
                ViewedReport = selectedReport
            };

            detailWindow.ShowDialog();
            ReportsDataGrid.UnselectAll();
        }

        private void ApproveReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReportsDataGrid.SelectedItem is not Report selectedReport)
            {
                MessageBox.Show("Chọn một báo cáo để duyệt", "No Report Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selectedReport.ReporterId == CurrentAccount.UserId)
            {
                MessageBox.Show("Không thể duyệt báo cáo bạn tạo ra", "Action Forbidden", MessageBoxButton.OK, MessageBoxImage.Warning);
                ReportsDataGrid.UnselectAll();
                return;
            }

            int? violatorId = _reportService.GetVehicleOwnerIdByPlateNumber(selectedReport.PlateNumber);

            if (violatorId == CurrentAccount.UserId)
            {
                MessageBox.Show("Bạn không thể duyệt báo cáo mà người vi phạm là mình", "Action Forbidden", MessageBoxButton.OK, MessageBoxImage.Warning);
                ReportsDataGrid.UnselectAll();
                return;
            }

            if (selectedReport.Status != "Pending")
            {
                MessageBox.Show("Chỉ được duyệt những báo cáo còn hàng chờ", "Invalid Status", MessageBoxButton.OK, MessageBoxImage.Warning);
                ReportsDataGrid.UnselectAll();
                return;
            }

            FineInputWindow fineInputWindow = new();
            ReportsDataGrid.UnselectAll();

            if (fineInputWindow.ShowDialog() == true)
            {
                decimal fineAmount = fineInputWindow.FineAmount;

                try
                {
                    Violation newViolation = new()
                    {
                        ReportId = selectedReport.ReportId,
                        PlateNumber = selectedReport.PlateNumber,
                        ViolatorId = violatorId.Value,
                        FineAmount = fineAmount,
                        PaidStatus = false,
                        FineDate = DateTime.Now
                    };

                    using (var transaction = new TransactionScope())
                    {
                        _reportService.CreateViolation(newViolation);
                        selectedReport.Status = "Approved";
                        selectedReport.ProcessedBy = CurrentAccount.UserId;
                        _reportService.UpdateReportStatus(selectedReport);
                        transaction.Complete();
                    }

                    LoadReports();
                    CreateApprovalNotification(selectedReport);
                    MessageBox.Show($"Report approved. Fine amount: {fineAmount:C}", "Approval Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing report: {ex.Message}", "Approval Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RejectReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReportsDataGrid.SelectedItem is not Report selectedReport)
            {
                MessageBox.Show("Chọn một báo cáo để từ chối", "No Report Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selectedReport.ReporterId == CurrentAccount.UserId)
            {
                MessageBox.Show("Không thể từ chối báo cáo bạn tạo ra", "Action Forbidden", MessageBoxButton.OK, MessageBoxImage.Warning);
                ReportsDataGrid.UnselectAll();
                return;
            }

            int? violatorId = _reportService.GetVehicleOwnerIdByPlateNumber(selectedReport.PlateNumber);

            if (violatorId == CurrentAccount.UserId)
            {
                MessageBox.Show("Bạn không thể từ chối báo cáo mà người vi phạm là mình", "Action Forbidden", MessageBoxButton.OK, MessageBoxImage.Warning);
                ReportsDataGrid.UnselectAll();
                return;
            }

            ReportRejectionWindow rejectionWindow = new();
            ReportsDataGrid.UnselectAll();

            if (rejectionWindow.ShowDialog() == true)
            {
                try
                {
                    selectedReport.Status = "Rejected";
                    selectedReport.ProcessedBy = CurrentAccount.UserId;
                    _reportService.UpdateReportStatus(selectedReport);
                    LoadReports();
                    CreateRejectionNotification(selectedReport, rejectionWindow.RejectionReason);
                    MessageBox.Show("Báo cáo được từ chối thành công", "Rejection Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error rejecting report: {ex.Message}", "Rejection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateApprovalNotification(Report report)
        {
            Notification notification = new()
            {
                UserId = report.ReporterId,
                Message = $"Your traffic violation report (ID: {report.ReportId}) has been approved by Traffic Police.",
                PlateNumber = report.PlateNumber,
                SentDate = DateTime.Now,
                IsRead = false
            };
            _reportService.CreateNotification(notification);
        }

        private void CreateRejectionNotification(Report report, string reason)
        {
            Notification notification = new()
            {
                UserId = report.ReporterId,
                Message = $"Your traffic violation report (ID: {report.ReportId}) has been rejected. Reason: {reason}",
                PlateNumber = report.PlateNumber,
                SentDate = DateTime.Now,
                IsRead = false
            };
            _reportService.CreateNotification(notification);
        }

        private void ViolationButton_Click(object sender, RoutedEventArgs e)
        {
            ViolationListWindow violationWindow = new()
            {
                CurrentUser = this.CurrentAccount
            };
            violationWindow.ShowDialog();
        }

        private void Notification_Click(object sender, RoutedEventArgs e)
        {
            NotificationWindow notificationWindow = new(CurrentAccount);
            notificationWindow.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            this.Close();
        }

        private void ManageVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            UserVehicleWindow userVehicleWindow = new()
            {
                CurrentUser = CurrentAccount
            };
            userVehicleWindow.Show();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileDetailWindow profileDetailWindow = new()
            {
                CurrentUser = CurrentAccount
            };
            profileDetailWindow.ShowDialog();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string plateNumber = PlateNumberTextBox.Text.Trim();
            DateTime? fromDate = FromDatePicker.SelectedDate;
            DateTime? toDate = ToDatePicker.SelectedDate;

            try
            {
                List<Report> results;

                // Validate: phải nhập biển số mới được tìm
                if (string.IsNullOrEmpty(plateNumber))
                {
                    MessageBox.Show("Vui lòng nhập biển số xe để tìm kiếm.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Tìm theo biển số và lọc trạng thái Pending
                if (fromDate == null && toDate == null)
                {
                    // Không chọn ngày → tìm tất cả báo cáo pending của biển số
                    results = _reportService
                        .SearchReports(plateNumber, null, null)
                        .Where(r => r.Status == "Pending")
                        .ToList();
                }
                else
                {
                    // Có chọn khoảng ngày → lọc theo ngày và trạng thái pending
                    results = _reportService
                        .SearchReports(plateNumber, fromDate, toDate)
                        .Where(r => r.Status == "Pending")
                        .ToList();
                }

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy báo cáo phù hợp.", "Kết quả", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                ReportsDataGrid.ItemsSource = results;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi hợp lệ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            PlateNumberTextBox.Clear();
            FromDatePicker.SelectedDate = null;
            ToDatePicker.SelectedDate = null;
            LoadReports();
        }
    }
}
