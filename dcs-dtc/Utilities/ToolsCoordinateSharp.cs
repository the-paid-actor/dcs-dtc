namespace DTC.Utilities
{
	internal static class ToolsCoordinateSharp
	{
		public static readonly CoordinateSharp.CoordinateFormatOptions CfoDms = new CoordinateSharp.CoordinateFormatOptions()
		{
			Format = CoordinateSharp.CoordinateFormatType.Degree_Minutes_Seconds,
			Round = 2,
			Display_Leading_Zeros = true,
			Display_Trailing_Zeros = true
		};
		public static readonly CoordinateSharp.CoordinateFormatOptions CfoDdm = new CoordinateSharp.CoordinateFormatOptions()
		{
			Format = CoordinateSharp.CoordinateFormatType.Degree_Decimal_Minutes,
			Round = 4,
			Display_Leading_Zeros = true,
			Display_Trailing_Zeros = true
		};

		public static CoordinateSharp.Coordinate? FromString(string s)
		{
			if (CoordinateSharp.Coordinate.TryParse(s, out CoordinateSharp.Coordinate coordinate))
				return coordinate;
			else
				return null;
		}

		public static string ToStringDMS(CoordinateSharp.Coordinate? c)
		{
			if (c is not null)
				return c.ToString(CfoDms);
			else
				return string.Empty;
		}

		public static string ToStringDDM(CoordinateSharp.Coordinate? c)
		{
			if (c is not null)
				return c.ToString(CfoDdm);
			else
				return string.Empty;
		}

		public static string ToStringMGRS(CoordinateSharp.Coordinate? c)
		{
			if (c is not null)
				return c.MGRS.ToString();
			else
				return string.Empty;
		}
	}
}
