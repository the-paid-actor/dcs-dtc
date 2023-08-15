using DTC.Utilities;

namespace DTC.Models.DCS
{
	public class Theater
	{
		public readonly string Name;
		public readonly Airbase[] Airbases;

		public Theater(string name, Airbase[] airbases)
		{
			Name = name;
			Airbases = airbases;
		}

		private static Theater[] _theaters;


		public static Theater[] Theaters
		{
			get
			{
				if (_theaters == null)
				{
					_theaters = FileStorage.LoadAirbases();
				}
				if (_theaters == null)
				{
					_theaters = GetDefaultAirbases();
				}
				return _theaters;
			}
		}

		private static Theater[] GetDefaultAirbases()
		{
			return new Theater[]
			{
				new Theater("Caucasus", new Airbase[]
				{
					new Airbase("Anapa", "N 45.00.318", "E 037.20.901", 141),
					new Airbase("Batumi", "N 41.36.576", "E 041.36.011", 33),
					new Airbase("Beslan", "N 43.12.343", "E 044.36.352", 1722),
					new Airbase("Ghelendzik", "N 44.34.392", "E 038.00.723", 72),
					new Airbase("Gudauta", "N 43.06.862", "E 040.34.186", 69),
					new Airbase("Kobuleti", "N 41.55.800", "E 041.51.796", 59),
					new Airbase("Krasnodar-Center", "N 45.05.214", "E 038.56.467", 98),
					new Airbase("Krasnodar-Pashkovsky", "N 45.02.303", "E 039.11.324", 112),
					new Airbase("Krymsk", "N 44.58.100", "E 037.59.736", 66),
					new Airbase("Kutaisi", "N 42.10.657", "E 042.28.879", 148),
					new Airbase("Maykop", "N 44.40.869", "E 040.02.111", 591),
					new Airbase("Mineralnye Vody", "N 44.13.673", "E 043.04.870", 1050),
					new Airbase("Mozdok", "N 43.47.503", "E 044.36.350", 507),
					new Airbase("Nalchik", "N 43.30.840", "E 043.38.185", 1411),
					new Airbase("Novorossisk", "N 44.40.101", "E 037.46.720", 131),
					new Airbase("Senaki-Kolkhi", "N 42.14.444", "E 042.02.887", 43),
					new Airbase("Sochi", "N 43.26.666", "E 039.56.470", 98),
					new Airbase("Soganlug", "N 41.38.971", "E 044.56.298", 1483),
					new Airbase("Sukhumi", "N 42.51.675", "E 041.07.499", 43),
					new Airbase("Tbilisi-Lochini", "N 41.40.022", "E 044.57.374", 1574),
					new Airbase("Vaziani", "N 41.37.743", "E 045.01.630", 1524),
				}),
				new Theater("Persian Gulf", new Airbase[]
				{
					new Airbase("Abu Dhabi Intl", "N 24.27.218", "E 054.39.254", 92),
					new Airbase("Al Ain Intl", "N 24.15.703", "E 055.36.552", 814),
					new Airbase("Al-Bateen", "N 24.25.682", "E 054.27.511", 12),
					new Airbase("Al Dhafra AFB", "N 24.14.891", "E 054.32.863", 52),
					new Airbase("Al Maktoum Intl", "N 24.53.824", "E 055.09.625", 123),
					new Airbase("Liwa AFB", "N 23.39.046", "E 053.49.465", 400),
				})
			};
		}
	}
}
