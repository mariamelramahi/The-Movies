using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using The_Movies.View;
using The_Movies.ViewModel;

namespace The_Movies.ViewModel.Program
{
    public partial class Program : Window;
    private MovieRepository movieRepository;

    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
        MovieList movieList = new MovieList();
        movieList.Show();
        this.Close();
    }
}
