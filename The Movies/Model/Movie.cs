using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    class Movie
    {
        public string _title { get; set; }
        public string _genre { get; set; }
        public int _duration { get; set; }

        public Movie(string title, string genre, int duration)
        {
            _title = title;
            _genre = genre;
            _duration = duration;
        }


    }
}
