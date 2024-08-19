using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    class MovieRepository
    {
        private string filePath = "movies.csv";

        public void CreateMovie(string title, string genre, int duration, string theater, string director)
        {
            Movie newMovie = new Movie(title, genre, duration, theater, director);
            SaveMovieToCSV(newMovie);

        }

        private void SaveMovieToCSV(Movie movie)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Movie Title: {movie._title},Movie Genre: {movie._genre},Movie Duration: {movie._duration}");
            }
        }

        public void ReadMovies()
        {
            if (!File.Exists(filePath))
            { return; }

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    string title = values[0];
                    string genre = values[1];
                    int duration = int.Parse(values[2]);
                    string theater = values[3];
                    string director = values[4];
                    Movie newMovie = new Movie(title, genre, duration, theater, director);
                }
            }

        }

    }
}
    

