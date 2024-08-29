using System.Globalization;
using System.IO;
using System.Windows;

namespace The_Movies.Model
{
    /// <summary>
    /// Handles operations related to storing and retrieving movies from a CSV file.
    /// </summary>
    public class MovieRepository
    {
        private string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "movies.csv");


        /// <summary>
        /// Initializes a new instance of the <see cref="MovieRepository"/> class.
        /// Ensures the CSV file has the appropriate header.
        /// </summary>
        /// 
        // Standardkonstruktør (uden parameter)
        public MovieRepository()
        {
            _filePath = "movies.csv"; // Standardfilsti
            EnsureHeader();
        }

        // Ny konstruktør, der tager en filsti som parameter
        public MovieRepository(string filePath)
        {
            _filePath = filePath;
            EnsureHeader();
        }


        /// <summary>
        /// Ensures the CSV file has a header. Creates the file if it doesn't exist.
        /// </summary>
        private void EnsureHeader()
        {
            if (!File.Exists(_filePath))
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    writer.WriteLine("Title, Genre, Duration, Theater, Director, TheaterHall, Showtime, PremiereDate");
                }
            }
            else if (new FileInfo(_filePath).Length == 0)
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    writer.WriteLine("Title, Genre, Duration, Theater, Director, TheaterHall, Showtime, PremiereDate");
                }
            }
        }




        /// <summary>
        /// Creates a new movie and saves it to the CSV file.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="genre">The genre of the movie.</param>
        /// <param name="duration">The duration of the movie in minutes.</param>
        /// <param name="theater">The name of the theater.</param>
        /// <param name="director">The director of the movie.</param>
        /// <param name="theaterHall">The hall number of the theater.</param>
        /// <param name="showtime">The showtime of the movie.</param>
        /// <param name="premiereDate">The premiere date of the movie.</param>
        public void CreateMovie(string title, string genre, uint duration, string theater, string director, uint theaterHall, DateTime showtime, DateTime premiereDate)
        {
            Movie newMovie = new Movie(title, genre, duration, theater, director, theaterHall, showtime, premiereDate);
            SaveMovieToCSV(newMovie);
        }

        /// <summary>
        /// Saves a movie to the CSV file.
        /// </summary>
        /// <param name="movie">The movie to save.</param>
     

        private void SaveMovieToCSV(Movie movie)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine($"{movie.Title};{movie.Genre};{movie.Duration};{movie.MovieTheater};{movie.Director};{movie.MovieTheaterHall};{movie.Showtime:yyyy-MM-dd HH:mm};{movie.PremiereDate:yyyy-MM-dd HH:mm}");
                }
                Console.WriteLine("Movie saved to you file 'movies.CSV': " + movie.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hello! There's an error. We could not save your movie to your file 'movies.CSV': " + ex.Message);
                MessageBox.Show("Hello! There's an error. We could not save your movie to your file 'movies.CSV': " + ex.Message);
            }
        }


        /// <summary>
        /// Reads all movies from the CSV file.
        /// </summary>
        /// <returns>A list of <see cref="Movie"/> objects.</returns>
        public List<Movie> ReadMovies()
        {
            var movies = new List<Movie>();

            if (!File.Exists(_filePath))
            {
                return movies;
            }

            using (StreamReader reader = new StreamReader(_filePath))
            {
                reader.ReadLine(); // Skip the header line
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    string title = values[0];
                    string genre = values[1];
                    uint duration = uint.Parse(values[2]);
                    string theater = values[3];
                    string director = values[4];
                    uint theaterHall = uint.Parse(values[5]);
                    DateTime showtime = DateTime.ParseExact(values[6], "yyyy-MM-dd HH:mm", null);
                    DateTime premiereDate = DateTime.ParseExact(values[7], "yyyy-MM-dd HH:mm", null);

                    Movie newMovie = new Movie(title, genre, duration, theater, director, theaterHall, showtime, premiereDate);
                    movies.Add(newMovie);
                }
            }

            return movies;
        }

        /// <summary>
        /// Generates a monthly program with all movies and their details.
        /// </summary>
        /// <returns>A list of strings representing the monthly program.</returns>
        public List<string> GenerateMonthlyProgram()
        {
            var movies = ReadMovies(); // Retrieve the list of movies from the CSV file
            var program = new List<string>();

            foreach (var movie in movies)
            {
                // Calculate the total duration including ads and cleaning time
                var totalDuration = movie.Duration + 30;

                // Format the information for each movie into a readable string
                var movieInfo = $"{movie.Title} spiller i {movie.MovieTheater} på {movie.Showtime:dd-MM-yyyy HH:mm} med en varighed på {totalDuration} minutter.";

                // Add the movie information to the program
                program.Add(movieInfo);
            }

            return program; // Return the complete list with the program
        }
    }
}
