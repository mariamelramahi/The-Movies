using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model;
using The_Movies.View;
using The_Movies.ViewModel;

namespace The_Movies.Viewmodel
{
    internal class MovieTheatreViewModel : ViewModelBase
    {
        private MovieTheatreRepository movieTheatreRepository = new MovieTheatreRepository();

        public ObservableCollection<MovieTheatre> theatres;
        private string _theatreName;
        private string _cityName;
        private int _seats;

        public MovieTheatreViewModel() 
        {
            theatres = new ObservableCollection<MovieTheatre>();
            _theatreName = "";
            _cityName = "";
            _seats = 0;

            foreach (var movieTheatre in movieTheatreRepository.MovieTheatres)
            {
                theatres.Add(movieTheatre);
            }
        }

        private void AddTheatre()
        {

            if (string.IsNullOrEmpty(_theatreName))
            {
                throw new Exception();
            }
            else if (string.IsNullOrEmpty(_cityName))
            {
                throw new Exception();
            }
            else if (_seats <= 0)
            {
                throw new Exception();
            }

            MovieTheatre theatre = new MovieTheatre(_theatreName, _cityName, _seats);

            movieTheatreRepository.AddTheatre(theatre);
            theatres.Add(theatre);

            TheatreName = "";
            CityName = "";
            Seats = 0;

        }

        private void SaveTheatres()
        {
            movieTheatreRepository.SaveTheatresToCSV();
        }


        public RelayCommand AddTheatreCommand => new RelayCommand(execute => AddTheatre());
        public RelayCommand SaveCommand => new RelayCommand(execute => SaveTheatres());

        public string TheatreName
        { 
            get { return _theatreName; }
            set 
            { 
                _theatreName = value; 
                OnPropertyChanged();
            }
        }

        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                OnPropertyChanged();
            }
        }

        public int Seats
        {
            get { return _seats; }
            set
            {
                _seats = value;
                OnPropertyChanged();
            }
        }

    }

    //public class MovieTheatreMainViewModel
    //{
    //    private MovieTheatreRepository theatreRepository = new MovieTheatreRepository();

    //    public ObservableCollection<MovieTheatreViewModel> TheatreVM { get; set; }

    //    public MovieTheatreMainViewModel()
    //    {
    //        TheatreVM = new ObservableCollection<MovieTheatreViewModel>();
    //        foreach (var movieTheatre in theatreRepository.MovieTheatres)
    //        {
    //            MovieTheatreViewModel movieTheatreViewModel = new MovieTheatreViewModel(movieTheatre);
    //            TheatreVM.Add(movieTheatreViewModel);
    //        }
    //    }
    //}
}
