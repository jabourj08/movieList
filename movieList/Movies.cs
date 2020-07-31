using System;
using System.Collections.Generic;
using System.Text;

namespace movieList
{
    class Movies
    {
        #region Properties
        private string _name;
        private string _genre;
        private int _year;
        private bool _series;
        private double _rating;
        #endregion

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
            }
        }
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }
        public bool Series
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
            }
        }
        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
            }
        }

        #region Constructors
        public Movies()
        {

        }
        public Movies(string Name, string Genre, int Year, bool Series, double Rating)
        {
            _name = Name;
            _genre = Genre;
            _year = Year;
            _series = Series;
            _rating = Rating;
        }
        #endregion

        public void PrintMovies()
        {
            if (_series)
            {
                Console.WriteLine();
                Console.WriteLine($"\"{_name}\", was released in {_year}. It is a {_genre} movie.");
                Console.WriteLine($"It is part of a series, and its Rotten Tomatoes Rating is {_rating}%");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"\"{_name}\", released in {_year}. It is a {_genre} movie");
                Console.WriteLine($"Its Rotten Tomatoes Audience Rating is {_rating}%");
            }
            
        }

    }
}