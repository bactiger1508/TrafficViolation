
using System.Windows;
using System.Windows.Media.Imaging;
using TrafficViolation.DAL;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    public partial class ViewDetailWindow : Window
    {
        public Report ViewedReport { get; set; } = null;

        public ViewDetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillElements(ViewedReport); // Điền dữ liệu vào các trường từ báo cáo

            DisableAllInputs(); // Vô hiệu hóa tất cả các trường nhập liệu
        }

        private void DisableAllInputs()
        {
            // Vô hiệu hóa tất cả các TextBox, nút, và các trường nhập liệu khác
            UserNameTextBox.IsEnabled = false;
            ViolationTypeTextBox.IsEnabled = false;
            PlateNumberTextBox.IsEnabled = false;
            VideoUrlTextBox.IsEnabled = false;
            LocationTextBox.IsEnabled = false;
            DescriptionTextBox.IsEnabled = false;
            ImageUrlTextBox.IsEnabled = false;
        }
        private string GetReporterFullName(int reporterId)
        {
            using (var context = new PrnProjectContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == reporterId);
                return user != null ? user.FullName : "Unknown User"; // Trả về "Unknown User" nếu không tìm thấy
            }
        }

        private void FillElements(Report report)
        {
            if (report == null)
            {
                MessageBox.Show("No report to display details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }

            // Lấy thông tin FullName từ ReporterId
            string reporterFullName = GetReporterFullName(report.ReporterId);

            // Điền dữ liệu vào các trường
            UserNameTextBox.Text = reporterFullName; // Hiển thị FullName thay vì ReporterId
            ViolationTypeTextBox.Text = report.ViolationType;
            PlateNumberTextBox.Text = report.PlateNumber;
            VideoUrlTextBox.Text = report.VideoUrl;
            LocationTextBox.Text = report.Location;
            DescriptionTextBox.Text = report.Description;

            // Kiểm tra và hiển thị hình ảnh
            if (!string.IsNullOrEmpty(report.ImageUrl))
            {
                string imagePath = System.IO.Path.Combine("C:\\C# Coder\\PRN_PROJECT\\PROJECT_PRN\\image\\violation", report.ImageUrl);//sửa theo đường dẫn máy
                if (System.IO.File.Exists(imagePath))
                {
                    ImageViolation.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                    ImageUrlTextBox.Text = report.ImageUrl;
                }
                else
                {
                    ImageUrlTextBox.Text = string.Empty;
                    MessageBox.Show("The specified image file does not exist.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                ImageUrlTextBox.Text = string.Empty;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Đóng cửa sổ
            this.Close();
        }
    }
}
