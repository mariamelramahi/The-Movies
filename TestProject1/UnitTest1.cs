using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Movies.Model; // Sørg for, at dette matcher navneområdet i dit WPF-projekt

namespace TestProject1


{
        [TestClass]
        public class MovieRepositoryTests
        {
            private string tempFilePath;

            [TestInitialize]
            public void Setup()
            {
                // Set up a temporary file path for testing
                tempFilePath = Path.Combine(Path.GetTempPath(), "test_movies.csv");
            }

            [TestMethod]
      
        public void ReadMovies_ShouldReturnSavedMovies()
        {
            // Arrange
            var repository = new MovieRepository(Path.Combine(Path.GetTempPath(), "test_movies.csv"));

            // Sæt en fremtidig dato og tid op til minutter
            var futureDate = new DateTime(2024, 9, 5, 11, 34, 0); // Sæt et specifikt tidspunkt uden sekunder

            var movie = new Movie("Test Title", "Test Genre", 120, "Test Theater", "Test Director", 1, futureDate, futureDate);

            // Act
            repository.CreateMovie(movie.Title, movie.Genre, movie.Duration, movie.MovieTheater, movie.Director, movie.MovieTheaterHall, movie.Showtime, movie.PremiereDate);
            var movies = repository.ReadMovies();

            // Assert
            Assert.AreEqual(1, movies.Count);
            var savedMovie = movies[0];
            Assert.AreEqual(movie.Title, savedMovie.Title);
            Assert.AreEqual(movie.Genre, savedMovie.Genre);
            Assert.AreEqual(movie.Duration, savedMovie.Duration);
            Assert.AreEqual(movie.MovieTheater, savedMovie.MovieTheater);
            Assert.AreEqual(movie.Director, savedMovie.Director);
            Assert.AreEqual(movie.MovieTheaterHall, savedMovie.MovieTheaterHall);

            // Sammenlign datoer og tidspunkter op til minutter
            Assert.AreEqual(movie.Showtime, savedMovie.Showtime);
            Assert.AreEqual(movie.PremiereDate, savedMovie.PremiereDate);
        }

        [TestCleanup]
            public void Cleanup()
            {
                // Clean up the temporary file after each test
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }
}


