using DTC.Utilities;

namespace DTC.Models.AH64.Waypoints
{
    public class PointType
    {
        public readonly string Type;
        public readonly Ident[] Idents;
        public PointType(string type, Ident[] idents)
        {
            Type = type;
            Idents = idents;
        }

        private static PointType[] _pointtypes;

        public static PointType[] PointTypes
        {
            get 
            { 
                if (_pointtypes == null)
                {
                    _pointtypes = FileStorage.LoadIdents();
                }
                if (_pointtypes == null)
                {
                    _pointtypes = GetDefaultIdents();
                }
                return _pointtypes; 
            }
        }

        private static PointType[] GetDefaultIdents()
        {
            return new PointType[]
            {
                new PointType("WP", new Ident[]
                {
                    new Ident("CC","Communications Check Point"),
                    new Ident("LZ","Landing Zone")
                }),
                new PointType("CM", new Ident[]
                {
                    new Ident("FA","Forward Assembly Area"),
                    new Ident("BP","Battle Position")
                }),
                new PointType("TG", new Ident[]
                {
                    new Ident("TG","Target Point"),
                    new Ident("AX","AMX-13 Air Defense Gun")
                })
            };
        }
    }
}
