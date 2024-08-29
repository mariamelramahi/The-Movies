using System;
using System.Collections.ObjectModel;
using System.Windows;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly MovieRepository _movieRepository = new MovieRepository();

        private Movie _currentMovie = new Movie();
        public Movie CurrentMovie
        {
            get => _currentMovie;
            set
            {
                _currentMovie = value;
                OnPropertyChanged(nameof(CurrentMovie));
                AddMovieCommand.RaiseCanExecuteChanged(); // Opdater knappen, når CurrentMovie ændres
            }
        }

        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        public RelayCommand AddMovieCommand { get; }

        public MainViewModel()
        {
            // Initialiser kommandoen i konstruktøren
            AddMovieCommand = new RelayCommand(execute => AddMovie(), canExecute => CanAddMovie());
        }

        public void AddMovie()
        {
            ExecuteWithValidation(
                () =>
                {
                    // Validering af felt
                    if (string.IsNullOrEmpty(_currentMovie.Title)) throw new ArgumentException("Title cannot be empty.");
                    if (string.IsNullOrEmpty(_currentMovie.Genre)) throw new ArgumentException("Genre cannot be empty.");
                    if (_currentMovie.Duration == 0) throw new ArgumentException("Duration must be greater than 0.");
                    if (string.IsNullOrEmpty(_currentMovie.MovieTheater)) throw new ArgumentException("Theater name cannot be empty.");
                    if (string.IsNullOrEmpty(_currentMovie.Director)) throw new ArgumentException("Director name cannot be empty.");
                    if (_currentMovie.MovieTheaterHall == 0) throw new ArgumentException("Theater hall cannot be 0.");
                    if (_currentMovie.Showtime == DateTime.MinValue || _currentMovie.PremiereDate == DateTime.MinValue)
                        throw new ArgumentException("Showtime and premiere date must be valid.");
                },
                () =>
                {
                    // Tilføj filmen til repositoryet
                    _movieRepository.CreateMovie(
                        _currentMovie.Title,
                        _currentMovie.Genre,
                        _currentMovie.Duration,
                        _currentMovie.MovieTheater,
                        _currentMovie.Director,
                        _currentMovie.MovieTheaterHall,
                        _currentMovie.Showtime,
                        _currentMovie.PremiereDate);

                    // Opdater ObservableCollection med den nye film
                    Movies.Add(CurrentMovie);

                    // Nulstil CurrentMovie for ny indtastning
                    ResetCurrentMovie();
                }
            );
        }

        private bool CanAddMovie()
        {
            // Valider om kommandoen kan udføres
            return !string.IsNullOrEmpty(_currentMovie.Title) &&
                   !string.IsNullOrEmpty(_currentMovie.Genre) &&
                   _currentMovie.Duration > 0 &&
                   !string.IsNullOrEmpty(_currentMovie.MovieTheater) &&
                   !string.IsNullOrEmpty(_currentMovie.Director) &&
                   _currentMovie.MovieTheaterHall > 0 &&
                   _currentMovie.Showtime != DateTime.MinValue &&
                   _currentMovie.PremiereDate != DateTime.MinValue;
        }

        private void ResetCurrentMovie()
        {
            CurrentMovie = new Movie();
        }

        private void ExecuteWithValidation(Action validate, Action execute)
        {
            try
            {
                validate.Invoke();  // Udfør validering
                execute.Invoke();   // Udfør handling (tilføj film)
            }
            catch (Exception ex)
            {
                // Håndter undtagelser ved at vise en fejlmeddelelse
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoadMovies()
        {
            Movies.Clear();
            var movieList = _movieRepository.ReadMovies();
            foreach (var movie in movieList)
            {
                Movies.Add(movie);
            }
        }
    }
}
