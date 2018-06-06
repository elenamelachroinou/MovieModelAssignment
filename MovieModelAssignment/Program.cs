using System;
using System.Collections.Generic;

namespace MovieModelAssignment
{
    class Program
    {
  
        static void Main(string[] args)
        {
            Console.WriteLine("Do It Like IMDB");

            List<Movie> movies = new List<Movie>()
            {
              new Movie {Title="Taken", Sum = 18500},
              new Movie {Title="Fog", Sum = 10000},
              new Movie {Title="Do It Like A Pro", Sum = 12600},
              new Movie {Title="Venom", Sum = 17000},
              new Movie {Title="SuperFly", Sum = 16300},
              new Movie {Title="The Meg", Sum = 18000},
              new Movie {Title="Tully", Sum = 19000},
              new Movie {Title="White Boy Rick", Sum = 15500},
              new Movie {Title="Carol", Sum = 12500},
              new Movie {Title="Spy", Sum = 1200}
            };

            int reviews_counter = 15;

            foreach (var movie in movies)
            {               
                movie.ReviewsRating = new int[reviews_counter];
                movie.ReviewsDescription = new string[reviews_counter];
                movie.GenerateRating(reviews_counter);
                movie.AverageRating(reviews_counter);
             }

            movies.Sort((x, y) => y.MovieRating.CompareTo(x.MovieRating));

            Console.WriteLine("The Top 10 Movies are:");

            foreach (var movie in movies)
            {
                string s = String.Format("{0:F1}", movie.MovieRating);
                Console.WriteLine(movie.Title + " " + s);
                Console.WriteLine(-----END-----);
            }
        }

        public class Movie
        {
            public Movie() { }  

            public Movie(string title, int sum)
            {
                Title = title;
                Sum = sum;
            }

            private string _Title;
            public string Title
            {
                get
                {
                    return _Title;
                }

                set
                {
                    _Title = value;
                }
            }
            public string[] Actors { get; set; }

            private int[] _ReviewsRating;

            public int[] ReviewsRating
            {
                get
                {
                    return _ReviewsRating;
                }
                set
                {
                    _ReviewsRating = value;
                }
            }

            private string[] _ReviewsDescription; 
            public string[] ReviewsDescription
            {
                get
                {
                    return _ReviewsDescription;
                }
                set
                {
                    _ReviewsDescription = value;

                }
            }

            public decimal Sum { get; set; }

            private decimal _MovieRating;

            public decimal MovieRating
            {
                get
                {
                    return _MovieRating;
                }
                set
                {
                     _MovieRating = value;
                }
            }

            public void GenerateRating(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    Random _r = new Random();
                    ReviewsRating[i] = _r.Next(10);
                    ReviewsDescription[i] = $"Description of a review{i}";
                }
            }
            public void AverageRating(int count)
            {
                var sum = 0m;
                for (int i = 0; i < count; i++)
                    sum += ReviewsRating[i];

                MovieRating = sum / count;
            }
        }
    }
}
