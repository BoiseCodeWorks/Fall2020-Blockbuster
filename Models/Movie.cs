using System;
using Blockbuster.Interfaces;

namespace Blockbuster.Models
{
  // abstract prevents the movie from being instatiated
  abstract class Movie : IRentable
  {
    public string Title { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public double RentalCost { get; set; }

    public virtual void Play()
    {
      Console.WriteLine(Description);
    }

    public Movie(string title, int year, string description, double rentalCost)
    {
      Title = title;
      Year = year;
      Description = description;
      IsAvailable = true;
      RentalCost = rentalCost;
    }
  }
}