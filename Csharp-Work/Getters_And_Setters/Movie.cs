using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getters_And_Setters
{
    class Movie
    {

        public string tittle;
        public string director;
        private string rating;


        public Movie(string aTitle, string aDirector, string aRating)
        {
            tittle = aTitle;
            director = aDirector;
            Rating = aRating;
        }


        public string Rating
        {
            get { return rating; }
            set {
                if (value == "G" || value == "PG-13" || value == "PG" || value == "R" || value == "NR")
                {
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }
        }
    }
}
