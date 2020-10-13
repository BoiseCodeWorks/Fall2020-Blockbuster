using System;

namespace Blockbuster.Models
{
  // abstract prevents the movie from being instatiated
  abstract class Movie
  {
    public string Title { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }

    public virtual void Play()
    {
      Console.WriteLine(Description);
    }

    public Movie(string title, int year, string description)
    {
      Title = title;
      Year = year;
      Description = description;
      IsAvailable = true;
    }
  }
}