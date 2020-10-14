using Blockbuster.Interfaces;

namespace Blockbuster.Models
{
  class Snack : IPurchasable
  {
    public double Price { get; set; }
    public string Name { get; set; }
    public string SKU { get; set; }


    public double CalculateTax()
    {
      return Price + .02 + .05;
    }

    public Snack(double price, string name, string sKU)
    {
      Price = price;
      Name = name;
      SKU = sKU;
    }
  }
}