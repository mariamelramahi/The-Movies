using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace The_Movies.Model
{
    /// <summary>
    /// Represents a movie with its details.
    /// </summary>
    public class Movie : INotifyPropertyChanged
    {
        // Backing fields with underscore prefix
        private string _title;
        private string _genre;
        private uint _duration = 0;
        private string _movieTheater;
        private string _director;
        private uint _movieTheaterHall = 0;
        private DateTime _showtime;
        private DateTime _premiereDate;

        // Public Properties
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                         { _title = value; OnPropertyChanged(nameof(Title)); }
            }
        }

        public string Genre
        {
            get => _genre;
            set
            {
                if (_genre != value)
                {
                    _genre = value;
                    OnPropertyChanged(nameof(Genre));
                }


            }
        }

        public uint Duration
        {
            get => _duration;
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged();
                }

            }
        }

        public string MovieTheater
        {
            get => _movieTheater;
            set
            {
                if (_movieTheater != value)

                {
                    _movieTheater = value;
                    OnPropertyChanged(nameof(MovieTheater));
                }


            }
        }

        public string Director
        {
            get => _director;
            set
            {
                if (_director != value)
                {
                    _director = value;
                    OnPropertyChanged(nameof(Director));

                }
            }
        }

        public uint MovieTheaterHall
        {
            get => _movieTheaterHall;
            set
            {
                if (_movieTheaterHall != value)
                {
                    _movieTheaterHall = value;
                    OnPropertyChanged(nameof(MovieTheaterHall));
                }
            }
        }

        public DateTime Showtime
        {
            get => _showtime;
            set
            {
                if (_showtime != value)
                {
                    _showtime = value;
                    OnPropertyChanged(nameof(Showtime));
                }
            }
        }

        public DateTime PremiereDate
        {
            get => _premiereDate;
            set
            {
                if (_premiereDate != value)
                {
                    _premiereDate = value;
                    OnPropertyChanged(nameof(PremiereDate));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Movie"/> class with specified details.
        /// </summary>
        public Movie(string title, string genre, uint duration, string movieTheater, string director, uint movieTheaterHall, DateTime showtime, DateTime premiereDate)
        {
            _title = title;
            _genre = genre;
            _duration = duration;
            _movieTheater = movieTheater;
            _director = director;
            _movieTheaterHall = movieTheaterHall;
            _showtime = showtime;
            _premiereDate = premiereDate;
        }

        /// <summary>
        /// Parameterless constructor to allow for instantiation without initial values.
        /// </summary>
        public Movie()
        {
            _title = string.Empty;
            _genre = string.Empty;
            _duration = 0;
            _movieTheater = string.Empty;
            _director = string.Empty;
            _movieTheaterHall = 0;
            _showtime = DateTime.Now;
            _premiereDate = DateTime.Now;
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}