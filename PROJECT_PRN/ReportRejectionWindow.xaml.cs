using System.Windows;

namespace PROJECT_PRN
{
    /// <summary>
    /// Interaction logic for ReportRejectionWindow.xaml
    /// </summary>
    public partial class ReportRejectionWindow : Window
    {
        public string RejectionReason { get; private set; }

        public ReportRejectionWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            RejectionReason = RejectionReasonTextBox.Text.Trim();
            if (string.IsNullOrEmpty(RejectionReason))
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối.", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
