using Blockbuster.Interfaces;

namespace Blockbuster.Models
{
  class DVD : Movie
  {
    public int Discs { get; set; }
    public bool Extras { get; set; }

    public DVD(string title, int year, string description, int discs, bool extras, double rentalCost) : base(title, year, description, rentalCost)
    {
      Discs = discs;
      Extras = extras;
    }
  }
}