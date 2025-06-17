using System.Windows;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    /// <summary>
    /// Interaction logic for ManageAccountWindow.xaml
    /// </summary>
    public partial class ManageAccountWindow : Window
    {
        private UserService _service = new();
        public User CurrentAccount { get; set; }
        public ManageAccountWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
            HelloMsgLabel.Content = $"Xin chào, {CurrentAccount.FullName}!";
            RoleMsgLabel.Content = $"Vai trò: {CurrentAccount.Role}";
        }
        //Hiển thị lên dtGrid
        private void FillDataGrid()
        {
            AccountDataGrid.ItemsSource = null;
            AccountDataGrid.ItemsSource = _service.GetAllUsers();
        }

        private void UpdateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            User? selectedUser = AccountDataGrid.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để chỉnh sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            // Mở cửa sổ chỉnh sửa tài khoản và chuyển tài khoản hiện tại sang cửa sổ chỉnh sửa
            UpdateAccountWindow editWindow = new UpdateAccountWindow
            {
                CurrentUser = selectedUser
            };
            editWindow.ShowDialog();
            FillDataGrid();
        }

        private void ManageReportButton_Click(object sender, RoutedEventArgs e)
        {
            // Mở lại MainWindow và truyền CurrentAccount trở lại
            MainWindow main = new MainWindow
            {
                CurrentAccount = CurrentAccount
            };
            main.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
