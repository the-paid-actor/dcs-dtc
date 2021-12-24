namespace DTC.Models.F16.CMS
{
	public class CMSystem
	{
		public Program[] Programs { get; set; }

		public CMSystem()
		{
			Programs = new Program[6];

			ResetToDefault();
		}

		public void ResetToDefault()
		{
			Programs[0] = new Program(1, 1, (decimal)0.02, 10, (decimal)1.0, 1, (decimal)0.02, 10, (decimal)1.0);
			Programs[1] = new Program(2, 1, (decimal)0.02, 10, (decimal)0.5, 1, (decimal)0.02, 10, (decimal)0.5);
			Programs[2] = new Program(3, 2, (decimal)0.1, 5, (decimal)1.0, 2, (decimal)0.1, 5, (decimal)1.0);
			Programs[3] = new Program(4, 2, (decimal)0.1, 5, (decimal)0.5, 2, (decimal)0.1, 5, (decimal)0.5);
			Programs[4] = new Program(5, 2, (decimal)0.05, 20, (decimal)0.75, 2, (decimal)0.05, 20, (decimal)0.75);
			Programs[5] = new Program(6, 1, (decimal)0.02, 1, (decimal)0.5, 1, (decimal)0.02, 1, (decimal)0.5);
		}
	}
}
