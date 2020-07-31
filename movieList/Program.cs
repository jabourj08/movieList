using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Linq;

namespace movieList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movies> movieList = new List<Movies>
            {
                new Movies("The Mask", "Comedy", 1994, true, 68),
                new Movies("Pulp Fiction", "Drama", 1994, false, 96),
                new Movies("Deadpool", "Action & Adventure", 2016, true, 90),
                new Movies("Deadpool 2", "Action & Adventure", 2018, true, 85),
                new Movies("Avatar", "Action & Adventure", 2009, false, 82),
                new Movies("Django Unchained", "Drama", 2012, false, 91),
                new Movies("Guardians of the Galaxy Vol. 1", "Action & Adventure", 2014, true, 92),
                new Movies("Guardians of the Galaxy Vol. 2", "Action & Adventure", 2017, true, 87),
                new Movies("Independence Day", "Action & Adventure", 1996, false, 75),
                new Movies("Zombieland", "Comedy", 2009, true, 86),
                new Movies("Zombieland: Double Tap", "Comedy", 2019, true, 88),
                new Movies("The Avengers", "Action & Adventure", 2012, true, 91),
                new Movies("Avengers: Age of Ultron", "Action & Adventure", 2015, true, 83),
                new Movies("Avengers: Infinity War", "Action & Adventure", 2019, true, 90),
                new Movies("Avengers: Endgame", "Action & Adventure", 1234, true, 5.5),
                new Movies("Mars Attacks!", "Action & Adventure", 1996, false, 53),
                new Movies("Grindhouse", "Action & Adventure", 2007, false, 87),
                new Movies("John Wick", "Action & Adventure", 2014, true, 81),
                new Movies("John Wick: Chapter 2", "Action & Adventure", 2017, true, 85),
                new Movies("John Wick Chapter 3", "Action & Adventure", 2019, true, 86),
            };

            Console.WriteLine("***** Hello and welcome to the Movie Database! *****");
            Console.WriteLine();
            bool cont = true;
            while (cont)
            {
                MainMenuOptions(movieList);

                cont = ExitProgram();
                Console.Clear();
            }

            Console.Beep(400, 350); Console.Beep(400, 150); Console.Beep(400, 150); Console.Beep(600, 1000);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("***** Thank you for using the Movie Database. Have a great day! *****");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        //Display Main Menu
        public static void MainMenuOptions(List<Movies> movieList)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Print all movies");
            Console.WriteLine("2) Look for Movies in the same Genre");
            Console.WriteLine("3) Look for Movies that are part of a series");
            Console.WriteLine();
            Console.Write("Enter 1-3: ");
            Console.ResetColor();

            bool invalid = true;
            while (invalid)
            {
                try
                {
                    int userSelection = int.Parse(Console.ReadLine());

                    if (userSelection == 1)
                    {
                        PrintAll(movieList);
                        invalid = false;
                    }
                    else if (userSelection == 2)
                    {
                        GenreSearch(movieList);
                        invalid = false;
                    }
                    else if (userSelection == 3)
                    {
                        SeriesSearch(movieList);
                        invalid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Why u no listen??? I said gimme a number 1-3");
                        Console.ResetColor();
                        BeepBoops();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Why u no listen??? I said gimme a number 1-3");
                    Console.ResetColor();
                    BeepBoops();
                }
            }
        }
        //Main Menu Option 1: Print all movies
        public static void PrintAll(List<Movies> movieList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < movieList.Count; i++)
            {
                movieList[i].PrintMovies();
            }
            Console.ResetColor();
        }
        //Main Menu Option 2: List Genres and print based on selection
        public static void GenreSearch(List<Movies> movieList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Which Genre would you like to see movies for?");
            Console.WriteLine("1) Action & Adventure");
            Console.WriteLine("2) Comedy");
            Console.WriteLine("3) Drama");
            Console.WriteLine();
            Console.Write("Enter 1-3: ");
            Console.ResetColor();

            bool invalid = true;
            while (invalid)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    List<Movies> sortedList = movieList.OrderBy(order => order.Name).ToList();
                    
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (input == 1)
                    {
                        foreach (Movies movie in sortedList)
                        {
                            if (movie.Genre == "Action & Adventure")
                            {
                                movie.PrintMovies();
                            }
                        }
                        invalid = false;
                    }
                    else if (input == 2)
                    {
                        foreach (Movies movie in sortedList)
                        {
                            if (movie.Genre == "Comedy")
                            {
                                movie.PrintMovies();
                            }
                        }
                        invalid = false;
                    }
                    else if (input == 3)
                    {
                        foreach (Movies movie in sortedList)
                        {
                            if (movie.Genre == "Drama")
                            {
                                movie.PrintMovies();
                            }
                        }
                        invalid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Why u no listen??? I said gimme a number 1-3");
                        Console.ResetColor();
                        BeepBoops();
                    }
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Why u no listen??? I said gimme a number 1-3");
                    Console.ResetColor();
                    BeepBoops();
                }
            }
        }
        //Main Menu Option 3: List Series/standAlone and print based on selection
        public static void SeriesSearch(List<Movies> movieList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Would you like to see movies that part of a series, or stand alone movies?");
            Console.WriteLine("1) Part of a Series");
            Console.WriteLine("2) Stand Alone");
            Console.WriteLine();
            Console.Write("Enter 1 or 2: ");
            Console.ResetColor();

            bool invalid = true;
            while (invalid)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    List<Movies> sortedList = movieList.OrderBy(order => order.Name).ToList();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (input == 1)
                    {
                        foreach (Movies movie in sortedList)
                        {
                            if (movie.Series == true)
                            {
                                movie.PrintMovies();
                            }
                        }
                        invalid = false;
                    }
                    else if (input == 2)
                    {
                        foreach (Movies movie in sortedList)
                        {
                            if (movie.Series == false)
                            {
                                movie.PrintMovies();
                            }
                        }
                        invalid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Why u no listen??? I said gimme a number 1-2");
                        Console.ResetColor();
                        BeepBoops();
                    }
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Why u no listen??? I said gimme a number 1-2");
                    Console.ResetColor();
                    BeepBoops();
                }
            }
        }
        //Determine if user wants to Exit Program
        public static bool ExitProgram()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Would you like to return to the Main Menu? y/n");
            Console.ResetColor();

            bool invalid = true;
            bool cont = true;
            while (invalid)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (input[0] == 'n')
                    {
                        cont = false;
                        invalid = false;
                    }
                    else if (input[0] == 'y')
                    {
                        cont = true;
                        invalid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Why u no listen??? I said gimme a \"y\" or \"n\"");
                        Console.ResetColor();
                        BeepBoops();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Why u no listen??? I said gimme a \"y\" or \"n\"");
                    Console.ResetColor();
                    BeepBoops();
                }
            }

            return cont;
        }
        //Addz Cool Zoundz!!!
        public static void BeepBoops()
        {
            Console.Beep(1000, 100); Console.Beep(1000, 100); Console.Beep(1000, 100);
            Console.Beep(2000, 100); Console.Beep(2000, 100); Console.Beep(2000, 100);
        }

    }
}
