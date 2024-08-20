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
        public uint _duration { get; set; }
        public string _theater { get; set; }
        public string _director { get; set; }
        public uint _theaterhall { get; set; }
        public DateTime _showtime { get; set; }
        public DateTime _premeiredate { get; set; }

        public Movie(string title, string genre, uint duration, string theater, string director, uint theaterhall, DateTime showtime, DateTime premeiredate)
        {
            _title = title;
            _genre = genre;
            _duration = duration;
            _theater = theater;
            _director = director;
            _theaterhall = theaterhall;
            _showtime = showtime;
            _premeiredate = premeiredate;
        }


    }
}
