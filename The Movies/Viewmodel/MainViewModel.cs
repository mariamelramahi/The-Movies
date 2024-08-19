using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
		private readonly MovieRepository _movieRepository = new MovieRepository();
		private string _title;
        private string _genre;
        private uint _duration;
		private string _theater;
		private string _director;

		public void AddMovie()
		{
			if (string.IsNullOrEmpty(_genre))
			{
				throw new Exception();
			} else if (string.IsNullOrEmpty(_genre))
			{
				throw new Exception();
			} else if (_duration == 0)
			{
				throw new Exception();
			}

            _movieRepository.CreateMovie(_title, _genre, (int)_duration, _theater, _director);
			MovieTitle = "";
			MovieGenre = "";
			MovieDuration = 0;
			MovieTheater = "";
			MovieDirector = "";
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
		}
    }

