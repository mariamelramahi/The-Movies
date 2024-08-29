using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using The_Movies.Model;

namespace The_Movies.Viewmodel
{
    internal class MainViewModel : ViewModelBase
    {
		private readonly MovieRepository _movieRepository = new MovieRepository();
		private string _title;
        private string _genre;
        private uint _duration;
		private string _theater;
		private string _director;
		private uint _theaterhall;
		private DateTime? _showtime;
		private DateTime? _premeiredate;


		public void AddMovie()
		{
			if (string.IsNullOrEmpty(_title))
			{
				throw new Exception();
			} else if (string.IsNullOrEmpty(_genre))
			{
				throw new Exception();
			} else if (_duration == 0)
			{
				throw new Exception();
			}
			else if (string.IsNullOrEmpty(_theater))
			{
				throw new Exception();
			}
			else if (string.IsNullOrEmpty(_director))
			{
				throw new Exception();
			}
			else if (_theaterhall == 0)
			{
				throw new Exception();
			}
			else if (_showtime == null)
			{
				throw new Exception();
			}
			else if (_premeiredate == null)
			{
				throw new Exception();
			}

            _movieRepository.CreateMovie(_title, _genre, (uint)_duration, _theater, _director, (uint)_theaterhall, (DateTime)_showtime, (DateTime)_premeiredate);
			MovieTitle = "";
			MovieGenre = "";
			MovieDuration = 0;
			MovieTheater = "";
			MovieDirector = "";
			MovieTheatreHall = 0;
			MovieShowtime = DateTime.Now;
			MoviePremeireDate = DateTime.Now;

        }

        public RelayCommand AddMovieCommand => new RelayCommand(execute => AddMovie());


        public string MovieTitle
		{
			get { return _title; }
			set 
			{ 
				_title = value;
				OnPropertyChanged();
			}
		}

		public string MovieGenre
		{
			get { return _genre; }
			set 
			{ 
				_genre = value;
                OnPropertyChanged();
            }
		}

		public uint MovieDuration
		{
			get { return _duration; }
			set 
			{ 
				_duration = value;
				OnPropertyChanged();
			}
		}


		public string MovieTheater
			{
			get { return _theater; }
			set
				{
				_theater = value;
				OnPropertyChanged();
				}
			}

		public string MovieDirector
			{
			get { return _director; }
			set
				{
				_director = value;
				OnPropertyChanged();
				}
			}
		public uint MovieTheatreHall
            {
            get { return _theaterhall; }
            set
                {
                _theaterhall = value;
                OnPropertyChanged();
                }
            }
		public DateTime? MovieShowtime
            {
			get 
				{
				//if (_showtime == DateTime.MinValue)
				//	_showtime = DateTime.Now;
				return _showtime;
				}
			set
                {
                _showtime = value;
                OnPropertyChanged();
                }
            }
		public DateTime? MoviePremeireDate
            {
			get { return _premeiredate; }
			set
                {
                _premeiredate = value;
                OnPropertyChanged();
                }
            }
		}

    }

