using Blockbuster.Interfaces;

namespace Blockbuster.Models
{
  class GameConsole : IRentable
  {
    public bool IsAvailable { get; set; }
    public double RentalCost { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }

    public GameConsole(string make, string model, double rentalCost)
    {
      IsAvailable = true;
      RentalCost = rentalCost;
      Make = make;
      Model = model;
    }
  }
}