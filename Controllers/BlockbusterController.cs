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
      Console.WriteLine("Options: (R)ent, R(e)turn, (B)uy, (H)elp");
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
        case "buy":
        case "b":
          Buy();
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
      Console.WriteLine(_Service.GetRentables(true));
      Console.Write("Enter a number to rent: ");
      string inputStr = Console.ReadLine();
      if (int.TryParse(inputStr, out int index) && index > 0)
      {
        System.Console.WriteLine("Scanning.....");
        Thread.Sleep(500);
        Console.WriteLine(_Service.Rent(index - 1));
        Console.Beep();
        Thread.Sleep(2000);
        Console.Clear();
      }

    }
    private void ReturnMovie()
    {
      Utils.PrintLogo();
      Console.WriteLine(_Service.GetRentables(false));
      Console.Write("Enter a number to return: ");
      string inputStr = Console.ReadLine();
      if (int.TryParse(inputStr, out int index) && index > 0)
      {
        Console.WriteLine(_Service.Return(index - 1));
        Thread.Sleep(2000);
        Console.Clear();
      }
    }
    private void Buy()
    {
      Console.WriteLine(_Service.GetPurchasables());
      Console.ReadLine();
    }
    private void Help()
    {
      throw new NotImplementedException();
    }
  }
}