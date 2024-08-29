using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace The_Movies.Model
{
    class MovieRepository
    {
        private string filePath = "movies.csv";
        public MovieRepository()
        {
            EnsureHeader();
        }
        private void EnsureHeader()
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Title, Genre, Duration, Theater, Director, Theaterhall, Showtime, Premeiredate");
                }
            }
            else if (new FileInfo(filePath).Length == 0)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Title, Genre, Duration, Theater, Director, Theaterhall, Showtime, Premeiredate");
                }
            }
        }
        public void CreateMovie(string title, string genre, uint duration, string theater, string director, uint theatrehall, DateTime showtime, DateTime premeiredate)
        {

            Movie newMovie = new Movie(title, genre, duration, theater, director, theatrehall, showtime, premeiredate);
            SaveMovieToCSV(newMovie);

        }

        private void SaveMovieToCSV(Movie movie)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{movie._title}, {movie._genre}, {movie._duration}, {movie._theater}, {movie._director}, {movie._theaterhall},{movie._showtime.ToString("f")}, {movie._premeiredate.ToString("f")}");
            }
        }

        public void ReadMovies()
        {
            if (!File.Exists(filePath))
            { return; }

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    string title = values[0];
                    string genre = values[1];
                    uint duration = uint.Parse(values[2]);
                    string theater = values[3];
                    string director = values[4];
                    uint theaterhall = uint.Parse(values[5]);
                    DateTime showtime = DateTime.Parse(values[6], null, DateTimeStyles.RoundtripKind);
                    DateTime premeiredate = DateTime.Parse(values[7], null, DateTimeStyles.RoundtripKind);

                    Movie newMovie = new Movie(title, genre, duration, theater, director, theaterhall, showtime, premeiredate);
                }
            }

        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            if (!File.Exists(filePath))
            {
                return movies;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    string title = values[0];
                    string genre = values[1];
                    uint duration = uint.Parse(values[2]);
                    string theater = values[3];
                    string director = values[4];
                    uint theaterhall = uint.Parse(values[5]);
                    DateTime showtime = DateTime.Parse(values[6], null, DateTimeStyles.RoundtripKind);
                    DateTime premeiredate = DateTime.Parse(values[7], null, DateTimeStyles.RoundtripKind);

                    Movie newMovie = new Movie(title, genre, duration, theater, director, theaterhall, showtime, premeiredate);
                    movies.Add(newMovie);
                }
            }
            return movies;
        }

   

    }
}
    

