using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;

namespace LC951verifier
{
	public class Program
	{
		[STAThread]
		public static void Main()
		{
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
