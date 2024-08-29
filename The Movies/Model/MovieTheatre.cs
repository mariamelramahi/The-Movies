using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    public class MovieTheatre
    {
        public string _theatreName { get; set; }
        public string _cityName { get; set; }
        public int _seats { get; set; }

        public MovieTheatre(string theatreName, string cityName, int seats) 
        { 
            _theatreName = theatreName;
            _cityName = cityName;
            _seats = seats;
        }
    }
}
