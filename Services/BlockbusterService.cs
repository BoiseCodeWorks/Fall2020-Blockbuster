using System;
using System.Collections.Generic;
using System.Linq;
using Blockbuster.Interfaces;
using Blockbuster.Models;

namespace Blockbuster.Services
{
  class BlockbusterService
  {
    public List<IRentable> Rentables { get; set; }

    public List<Snack> Snacks { get; set; }

    internal string GetRentables(bool available)
    {
      // get all the movies that were requested
      var rentables = Rentables.FindAll(r => r.IsAvailable == available);
      // if there are not short out and send back nothing
      if (rentables.Count == 0)
      {
        return "NOTHING HERE";
      }


      // create 2 lists one for movies, and one for "other"
      string movieList = "";
      movieList += available ? "Movies to Rent\n" : "Movies to Return\n";
      string others = "Other: \n";

      // itterate over the list of IRentables and check their types to add to the right list
      for (int i = 0; i < rentables.Count; i++)
      {
        var rentable = rentables[i];
        if (rentable is Movie)
        {
          var movie = (Movie)rentable;
          movieList += $"{i + 1}. {movie.Title} - {movie.Description}({movie.Year})\n";
        }
        else if (rentable is GameConsole)
        {
          var con = (GameConsole)rentable;
          others += $"{i + 1}. {con.Make} {con.Model} ({con.RentalCost}/week)\n";
        }
      }
      return movieList + "\n\n" + others;
    }
    internal string GetPurchasables()
    {
      var list = "ORDER FROM THE FOLLOWING: \n";
      List<IPurchasable> items = new List<IPurchasable>();
      items.AddRange(Snacks);
      // NOTE filter all rentables to only inclue things that can be purchased
      var purchasableRents = Rentables.FindAll(r => r is IPurchasable && r.IsAvailable);
      // NOTE Select functions like .map
      var rentItems = purchasableRents.Select(elem => (IPurchasable)elem);
      items.AddRange(rentItems);

      for (int i = 0; i < items.Count; i++)
      {
        IPurchasable item = items[i];
        list += $"{i + 1}. {item.Name} - ${item.Price}\n";
      }
      return list;
    }
    internal string Rent(int index)
    {
      var movies = Rentables.FindAll(m => m.IsAvailable);
      if (index < movies.Count)
      {
        movies[index].IsAvailable = false;
        return "Enjoy your film";
      }
      return "Invalid Selection, You Ignoramus";
    }
    internal string Return(int index)
    {
      var movies = Rentables.FindAll(m => !m.IsAvailable);
      if (index < movies.Count)
      {
        movies[index].IsAvailable = false;
        return "Thanks!";
      }
      return "Invalid Selection, You Ignoramus";
    }
    public BlockbusterService()
    {
      Rentables = new List<IRentable>(){
        // IMPLICIT CASTING (can implicitly cast up)
          new VHS("Jurassic Park", 1993, "Dino's are Cool but maybe not so nice", 1),
          new DVD("Willy Wonka", 1971, "A Chocolate mogal murders some kids", 1, true, 1),
          new DVD("LOTR", 2001, "A Small man returns a lost ring, on a really long walk", 3, true, 3),
          new VHS("The Pagemaster", 1994, "Home Alone in a Library", 5),
          new GameConsole("Sony", "Playstation", 15)
        };
      Snacks = new List<Snack>(){
        new Snack(5, "microwave popcorn 1.0oz", "PPC101"),
        new Snack(7, "microwave popcorn 1.3oz", "PPC102"),
        new Snack(4, "Pickle in Bag (DILL)", "PIB101"),
        new Snack(4, "Pickle in Bag (SPICY)", "PIB102")
      };

      Rentables[3].IsAvailable = false;
    }
  }
}