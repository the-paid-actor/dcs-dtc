using System;

namespace DTC.Models.FA18.CMS
{
	public class CMSystem
	{
		private Program[] programs;

		public Program[] Programs { get => programs; set => programs = value; }
		public bool EWHUDToBeUpdated { get; set; }
		public bool EnableUpload { get; set; }

		public CMSystem()
		{
			Programs = new Program[5];
			Programs[0] = new Program(1, 1, 1, (decimal)1.0, 10, false) ;
			Programs[1] = new Program(2, 1, 1, (decimal)0.5, 10, false) ;
			Programs[2] = new Program(3, 2, 2, (decimal)1.0, 5, false) ;
			Programs[3] = new Program(4, 2, 2, (decimal)0.5, 10, false) ;
			Programs[4] = new Program(5, 1, 1, (decimal)1.0, 2, false) ;

			EWHUDToBeUpdated = true;

			EnableUpload = true;
		}

		public Program[] getDefaults()
        {
            var programs = new Program[5];
			programs[0] = new Program(1, 1, 1, (decimal)1.0, 10, false) ;
			programs[1] = new Program(2, 1, 1, (decimal)0.5, 10, false) ;
			programs[2] = new Program(3, 2, 2, (decimal)1.0, 5, false) ;
			programs[3] = new Program(4, 2, 2, (decimal)0.5, 10, false) ;
			programs[4] = new Program(5, 1, 1, (decimal)1.0, 2, false) ;

			return programs;
        }

		public void AfterLoadFromJson()
		{
		}
	}
}
