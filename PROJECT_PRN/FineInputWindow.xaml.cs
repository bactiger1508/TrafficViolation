using System.Windows;
using System.Windows.Input;

namespace PROJECT_PRN
{
    public partial class FineInputWindow : Window
    {
        public decimal FineAmount { get; private set; }

        public FineInputWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(FineAmountTextBox.Text, out decimal fineAmount) && fineAmount > 0)
            {
                FineAmount = fineAmount;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid fine amount.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void FineAmountTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numbers and decimal point
            e.Handled = !decimal.TryParse(e.Text, out _) && e.Text != ".";
        }
    }
}