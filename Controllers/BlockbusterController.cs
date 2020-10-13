using System;
using System.Threading;
using Blockbuster.Services;

namespace Blockbuster.Controllers
{
  class BlockbusterController
  {
    private BlockbusterService _Service { get; set; } = new BlockbusterService();
    public bool _Running { get; set; } = true;
    public void Run()
    {
      while (_Running)
      {
        GetUserInput();
      }
    }

    private void GetUserInput()
    {
      Utils.PrintLogo();
      Console.WriteLine("Options: (R)ent, R(e)turn, (S)earch, (H)elp");
      string input = Console.ReadLine().ToLower();
      Console.Clear();
      switch (input)
      {
        case "rent":
        case "r":
          Rent();
          break;
        case "return":
        case "e":
          ReturnMovie();
          break;
        case "search":
        case "s":
          Search();
          break;
        case "help":
        case "h":
          Help();
          break;
        default:
          Console.WriteLine("invalid command");
          break;
      }
    }



    private void Rent()
    {
      // Display available movies
      // FIXME WHAT HAPPENS IF THERE ARE NO MOVIES
      Utils.PrintLogo();
      Console.WriteLine(_Service.GetMovies(true));
      Console.Write("Enter a number to rent: ");
      string inputStr = Console.ReadLine();
      if (int.TryParse(inputStr, out int index) && index > 0)
      {
        Console.WriteLine(_Service.Rent(index - 1));
        Thread.Sleep(2000);
        Console.Clear();
      }

    }
    private void ReturnMovie()
    {
      Utils.PrintLogo();
      Console.WriteLine(_Service.GetMovies(false));
      Console.Write("Enter a number to return: ");
      string inputStr = Console.ReadLine();
      if (int.TryParse(inputStr, out int index) && index > 0)
      {
        Console.WriteLine(_Service.Return(index - 1));
        Thread.Sleep(2000);
        Console.Clear();
      }
    }
    private void Search()
    {
      throw new NotImplementedException();
    }
    private void Help()
    {
      throw new NotImplementedException();
    }
  }
}