using System.Windows;
using TrafficViolation.BLL.Services;
using TrafficViolation.DAL.Entities;

namespace PROJECT_PRN
{
    public partial class UserVehicleWindow : Window
    {
        private readonly VehicleService _vehicleService = new();
        public User CurrentUser { get; set; } // Thông tin tài khoản hiện tại

        public UserVehicleWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Tải dữ liệu cho All Vehicles Tab (dành cho Admin và Police)
            if (CurrentUser.Role == "Admin" || CurrentUser.Role == "TrafficPolice")
            {
                AllVehiclesDataGrid.ItemsSource = _vehicleService.GetAllVehiclesWithOwnerDetails();
                AllVehiclesTab.Visibility = Visibility.Visible;
            }
            else
            {
                AllVehiclesTab.Visibility = Visibility.Collapsed;
            }

            // Tải dữ liệu cho My Vehicles Tab (dành cho Citizen, Police và Admin)
            if (CurrentUser.Role == "Citizen" || CurrentUser.Role == "TrafficPolice" || CurrentUser.Role == "Admin")
            {
                MyVehiclesDataGrid.ItemsSource = _vehicleService.GetVehiclesByOwner(CurrentUser.UserId);
                MyVehiclesTab.Visibility = Visibility.Visible;
            }
            else
            {
                MyVehiclesTab.Visibility = Visibility.Collapsed;
            }

            // Chọn tab mặc định
            if (CurrentUser.Role == "Citizen")
            {
                VehicleTabControl.SelectedIndex = 1; // Đặt tab "My Vehicles" được chọn (Index = 1)
            }
            else
            {
                VehicleTabControl.SelectedIndex = 0; // Đặt tab "All Vehicles" được chọn (Index = 0)
            }
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {  
            this.Close();
        }
    }
}
