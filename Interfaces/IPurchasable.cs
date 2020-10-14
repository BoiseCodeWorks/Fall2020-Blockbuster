namespace Blockbuster.Interfaces
{
  interface IPurchasable
  {
    // every property of an interface is public
    double Price { get; }
    string Name { get; set; }
    string SKU { get; set; }

    // interfaces do not contain method definitions
    double CalculateTax();
  }
}