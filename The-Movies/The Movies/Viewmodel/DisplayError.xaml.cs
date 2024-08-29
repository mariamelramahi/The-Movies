using System.Windows;

namespace The_Movies.View
{
    public partial class DisplayError : Window
    {
        public DisplayError(string errorMessage)
        {
            InitializeComponent(); // This initializes the components defined in XAML
            ErrorMessageTextBlock.Text = errorMessage; // This sets the error message
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Closes the error window
        }
    }
}
