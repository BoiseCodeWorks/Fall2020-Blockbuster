using System;
using System.Collections.Generic;
using Blockbuster.Models;

namespace Blockbuster.Services
{
  class BlockbusterService
  {
    public List<Movie> Movies { get; set; }


    internal string GetMovies(bool available)
    {
      // get all the movies that requested
      var movies = Movies.FindAll(m => m.IsAvailable == available);
      if (movies.Count == 0)
      {
        return "NO MOVIES HERE";
      }
      string list = available ? "Movies to Rent\n" : "Movies to Return\n";
      for (int i = 0; i < movies.Count; i++)
      {
        Movie movie = movies[i];
        list += $"{i + 1}. {movie.Title} - {movie.Description}({movie.Year})";
        // NOTE depending on the original type when created it will run the virtual default or the class override of Play
        // movie.Play();

        // EXPLICIT CASTING
        // var bad = (VHS)movie;
        // OPTION 1
        if (movie is DVD)
        {
          var mov = (DVD)movie;
          list += $"[DVD Discs{mov.Discs}]\n";
        }

        // OPTION 2
        VHS vhs = movie as VHS;
        if (vhs != null)
        {
          string message = vhs.IsRewound ? "Ready" : "Needs Rewound";
          list += $"[VHS {message}]\n";
        }
      }
      return list;
    }



    internal string Rent(int index)
    {
      var movies = Movies.FindAll(m => m.IsAvailable);
      if (index < movies.Count)
      {
        movies[index].IsAvailable = false;
        return "Enjoy your film";
      }
      return "Invalid Selection, You Ignoramus";
    }

    internal string Return(int index)
    {
      var movies = Movies.FindAll(m => !m.IsAvailable);
      if (index < movies.Count)
      {
        movies[index].IsAvailable = false;
        return "Thanks!";
      }
      return "Invalid Selection, You Ignoramus";
    }

    public BlockbusterService()
    {
      Movies = new List<Movie>(){
        // IMPLICIT CASTING (can implicitly cast up)
          new VHS("Jurassic Park", 1993, "Dino's are Cool but maybe not so nice"),
          new DVD("Willy Wonka", 1971, "A Chocolate mogal murders some kids", 1, true),
          new DVD("LOTR", 2001, "A Small man returns a lost ring, on a really long walk", 3, true),
          new VHS("The Pagemaster", 1994, "Home Alone in a Library")
        };

      Movies[3].IsAvailable = false;
    }
  }
}