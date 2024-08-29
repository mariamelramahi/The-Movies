using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.View;

namespace The_Movies.Model
{
    class MovieTheatreRepository
    {
        public List<MovieTheatre> MovieTheatres { get; }

        private string filePath = "movieTheatres.csv";

        public void AddTheatre(MovieTheatre movieTheatre)
        {
            MovieTheatres.Add(movieTheatre);
        }

        public void AddTheatre(string name, string city, int seats)
        {
            MovieTheatre newTheatre = new MovieTheatre(name, city, seats);
            MovieTheatres.Add(newTheatre);
        }

        public MovieTheatreRepository()
        {
            MovieTheatres = new List<MovieTheatre>();

            ReadMovieTheatres();
        }
                
        public void SaveTheatresToCSV()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (MovieTheatre mt in MovieTheatres)
                {
                    writer.WriteLine($"{mt._theatreName}, {mt._cityName}, {mt._seats}");
                }
            }
        }

        private void ReadMovieTheatres()
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

                    string theatreName = values[0];
                    string cityName = values[1];
                    int seats = int.Parse(values[2]);
                    
                    MovieTheatres.Add(new MovieTheatre(theatreName, cityName, seats));
                }
            }
        }
    }
}
