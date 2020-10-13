namespace Blockbuster.Models
{
  class VHS : Movie
  {
    public bool IsRewound { get; set; }
    // I am going to do things differently
    public override void Play()
    {
      // base.Play();
      System.Console.WriteLine("WRRRRRRR..." + Description);
      IsRewound = false;
    }


    public VHS(string title, int year, string description) : base(title, year, description)
    {
      IsRewound = true;
    }
  }
}