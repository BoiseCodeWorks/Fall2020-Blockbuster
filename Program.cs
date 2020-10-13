using System;
using Blockbuster.Controllers;

namespace Blockbuster
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Clear();

      new BlockbusterController().Run();
    }
  }
}
