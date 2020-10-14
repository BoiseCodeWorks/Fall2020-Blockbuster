namespace Blockbuster.Interfaces
{
  interface IRentable
  {
    bool IsAvailable { get; set; }
    double RentalCost { get; set; }
  }
}