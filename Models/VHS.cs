using System;
using Blockbuster.Interfaces;

namespace Blockbuster.Models
{
  class VHS : Movie, IPurchasable
  {
    public bool IsRewound { get; set; }

    public double Price { get; private set; }
    public string Name { get; set; }
    public string SKU { get; set; }

    // I am going to do things differently
    public override void Play()
    {
      // base.Play();
      System.Console.WriteLine("WRRRRRRR..." + Description);
      IsRewound = false;
    }

    public double CalculateTax()
    {
      return Price * 1.06 + 1;
    }

    public VHS(string title, int year, string description, double rentalCost) : base(title, year, description, rentalCost)
    {
      Name = title;
      Random rnd = new Random();
      SKU = title.Substring(0, 3) + rnd.Next(100, 1000);
      Price = 2;
      IsRewound = true;
    }
  }
}