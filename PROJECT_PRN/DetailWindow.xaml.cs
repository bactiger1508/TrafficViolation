using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{

    public partial class DetailWindow : Window
    {
        public Report EditedReport { get; set; } = null;
        private ReportService _service = new();
        public DetailWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillElements(EditedReport);
            if(EditedReport == null)
            
                DetailWindowModeLabel.Content = "Your Create Report Form";
            else
                DetailWindowModeLabel.Content = "Your Update Report Form";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SaveButton_Click(sender, e); // Gọi phương thức lưu báo cáo khi nhấn Enter
            }
        }


        //Lấy dữ liệu từ Properties, cụ thể là UserId và điền ô
        private void FillElements(Report x)
        {
            if (x == null)
            {
                int userId = 0;
                if (Application.Current.Properties.Contains("UserId"))
                {
                    userId = (int)Application.Current.Properties["UserId"];
                }
                UserIDTextBox.Text = userId.ToString();
                UserIDTextBox.IsEnabled = false;
                return;
            }

            UserIDTextBox.Text = x.ReporterId.ToString();
            UserIDTextBox.IsEnabled = false;
            ViolationTypeTextBox.Text = x.ViolationType;
            PlateNumberTextBox.Text = x.PlateNumber;
            PlateNumberTextBox.IsEnabled = false;
            VideoUrlTextBox.Text = x.VideoUrl;
            LocationTextBox.Text = x.Location;
            DescriptionTextBox.Text = x.Description;

            if (!string.IsNullOrEmpty(x.ImageUrl))
            {
                string imagePath = System.IO.Path.Combine("C:\\C# Coder\\PRN_PROJECT\\PROJECT_PRN\\image\\violation", x.ImageUrl);//sửa theo đường dẫn máy
                if (System.IO.File.Exists(imagePath))
                {
                    ImageViolation.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                    ImageUrlTextBox.Text = x.ImageUrl;
                }
                else
                {
                    ImageUrlTextBox.Text = string.Empty;
                    MessageBox.Show("File ảnh không tồn tại. Vui lòng chọn ảnh khác.", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                ImageUrlTextBox.Text = string.Empty;
            }
        }



        private bool ValidateElements()
        {
            if (string.IsNullOrEmpty(UserIDTextBox.Text) || !int.TryParse(UserIDTextBox.Text, out _))
            {
                MessageBox.Show("ID người báo cáo không hợp lệ. Vui lòng nhập số hợp lệ.", "Lỗi xác thực", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(ViolationTypeTextBox.Text))
            {
                MessageBox.Show("Loại vi phạm là bắt buộc!", "Trường bắt buộc", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(PlateNumberTextBox.Text))
            {
                MessageBox.Show("Biển số xe là bắt buộc!", "Trường bắt buộc", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(PlateNumberTextBox.Text, @"^[A-Za-z0-9-]+$"))
            {
                MessageBox.Show("Biển số xe không hợp lệ. Vui lòng sử dụng đúng định dạng (ví dụ: ABC-1234).", "Lỗi xác thực", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Kiểm tra PlateNumber trong bảng Vehicles
            if (!_service.CheckPlateNumberExists(PlateNumberTextBox.Text))
            {
                MessageBox.Show("Biển số xe không tồn tại trong hệ thống. Vui lòng nhập lại!", "Lỗi xác thực", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(VideoUrlTextBox.Text) && !Uri.IsWellFormedUriString(VideoUrlTextBox.Text, UriKind.Absolute))
            {
                MessageBox.Show("Định dạng URL video không hợp lệ!", "Lỗi xác thực", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(DescriptionTextBox.Text) || DescriptionTextBox.Text.Length > 500)
            {
                MessageBox.Show("Mô tả là bắt buộc và không được vượt quá 500 ký tự!", "Lỗi xác thực", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateElements())
                return;

            Report report = EditedReport ?? new Report();
            report.ReporterId = int.Parse(UserIDTextBox.Text);
            report.ViolationType = ViolationTypeTextBox.Text.Trim();
            report.Description = DescriptionTextBox.Text.Trim();
            report.PlateNumber = PlateNumberTextBox.Text.Trim();
            report.VideoUrl = VideoUrlTextBox.Text.Trim();
            report.Location = LocationTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(ImageUrlTextBox.Text))
            {
                report.ImageUrl = ImageUrlTextBox.Text;
            }

            if (EditedReport == null)
            {
                _service.AddReport(report);
                MessageBox.Show("Báo cáo đã được tạo thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                switch (EditedReport.Status)
                {
                    case "Rejected":
                    case "Approved":
                        report.Status = "Pending";
                        _service.UpdateReport(report);
                        MessageBox.Show(
                            EditedReport.Status == "Rejected"
                            ? "Nộp lại báo cáo thành công!"
                            : "Chỉnh sửa báo cáo thành công!",
                            "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        _service.UpdateReport(report);
                        MessageBox.Show("Báo cáo đã được cập nhật thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                }
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImageViolation.Source = null;
            ImageUrlTextBox.Text = string.Empty;
        }

        private string GenerateUniqueImageName(string originalFileName)
        {
            string extension = System.IO.Path.GetExtension(originalFileName);
            return $"{Guid.NewGuid()}{extension}";
        }
        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    ImageViolation.Source = new BitmapImage(fileUri);

                    string uniqueImageName = GenerateUniqueImageName(openFileDialog.FileName);
                    string destinationDirectory = System.IO.Path.Combine("C:\\C# Coder\\PRN_PROJECT\\PROJECT_PRN\\image\\violation");//sửa theo đường dẫn máy
                    if (!System.IO.Directory.Exists(destinationDirectory))
                    {
                        System.IO.Directory.CreateDirectory(destinationDirectory);
                    }

                    string destinationFile = System.IO.Path.Combine(destinationDirectory, uniqueImageName);
                    System.IO.File.Copy(openFileDialog.FileName, destinationFile, true);

                    ImageUrlTextBox.Text = uniqueImageName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm ảnh: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
