namespace DTC.Models.AH64.Waypoints
{
    public class Ident
    {
        public readonly string Name;
        public readonly string Description;

        public Ident(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
