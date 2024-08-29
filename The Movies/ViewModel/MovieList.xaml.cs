using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using The_Movies.Model;
using The_Movies.View;

namespace The_Movies.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MovieList : Window
    {
        private MovieRepository _movieRepository;
        public MovieList()
        {
            _movieRepository = new MovieRepository();
            LoadMoviesIntoDataGrid();
        }

        private void LoadMoviesIntoDataGrid()
        {
            List<Movie> movies = _movieRepository.GetMovies();
            DataGrid MyDataGrid = new DataGrid(); // Create a new instance of DataGrid
            MyDataGrid.ItemsSource = movies;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
