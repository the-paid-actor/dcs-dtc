using System.Windows.Forms;

namespace DTC.Utilities
{
	internal static class DTCMessageBox
	{
		public static void ShowError(string text)
		{
			MessageBox.Show(text, "DTC", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowInfo(string text)
		{
			MessageBox.Show(text, "DTC", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static bool ShowQuestion(string text)
		{
			return MessageBox.Show(text, "DTC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}
	}
}