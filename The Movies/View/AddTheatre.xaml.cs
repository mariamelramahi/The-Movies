using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;
using The_Movies.Viewmodel;

namespace The_Movies.View
{
    /// <summary>
    /// Interaction logic for AddTheatre.xaml
    /// </summary>
    public partial class AddTheatre : Window
    {
        private MovieTheatreViewModel vm = new MovieTheatreViewModel();

        public AddTheatre()
        {
            InitializeComponent();
            this.DataContext = vm;
            lstTheatresList.ItemsSource = vm.theatres;
        }

        //public AddTheatre()
        //{
        //    InitializeComponent();

        //    TheatreMainViewModel mvm = new TheatreMainViewModel();
        //    this.DataContext = mvm;
        //}

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    the
        //}
    }
}
