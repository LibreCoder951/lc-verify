using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace LC951verifier
{
	public class Program
	{
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[STAThread]
		public static void Main()
		{
			IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
			ShowWindow(h, 0);

			Application.Run(new ProgramForm());
		}
		public static string PrintByteArray(byte[] ByteArray)
		{
			List<string> HashString = new List<string>();
			for (int i = 0; i < ByteArray.Length; i++)
			{
				HashString.Add($"{ByteArray[i]:X2}");
				if ((i % 4) == 3) HashString.Add(" ");
			}
			string FinishedString = string.Join("", HashString);
			return FinishedString;
		}
	}
}
