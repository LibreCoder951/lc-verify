using System;
using System.IO;
using System.Security.Cryptography;

namespace LC951verifier
{
	public class Program
	{
		public static void Main(String[] args)
		{
			if (args.Length < 2)
			{
				Console.WriteLine("ERROR: Not all options specified. LC-verify needs all options to funtion.");
				return;
			}

			string Option = args[0];
			string SelectedDirectory = args[1];

			if (Option == "dir")
			{
				if (Directory.Exists(SelectedDirectory))
				{
					var Dir = new DirectoryInfo(SelectedDirectory);
					FileInfo[] Files = Dir.GetFiles();
					using (SHA256 HashOfFile = SHA256.Create())
					{
						foreach (FileInfo FInfo in Files)
						{
							try
							{
								FileStream FStream = FInfo.Open(FileMode.Open);
								FStream.Position = 0;
								byte[] HashValue = HashOfFile.ComputeHash(FStream);
								Console.Write($"{FInfo.Name}: ");
								PrintByteArray(HashValue);
								FStream.Close();
							}
							catch (IOException e)
							{
								Console.WriteLine($"ERROR: IO exception: {e.Message}");
							}
							catch (UnauthorizedAccessException e)
							{
								Console.WriteLine($"ERROR: You are not allowed to access that file: {e.Message}");
							}
						}
					}
				}
				else
				{
					Console.WriteLine("ERROR: The directory you specified could not be found. Please check if you spelled it correctly.");
				}
			}
			else if (Option == "file")
			{
				if (File.Exists(SelectedDirectory))
				{
					try
					{
						using (SHA256 HashOfFile = SHA256.Create())
						{
							FileStream FStream = File.Open(SelectedDirectory, FileMode.Open);
							FStream.Position = 0;
							byte[] HashValue = HashOfFile.ComputeHash(FStream);
							Console.Write($"{FStream.Name}: ");
							PrintByteArray(HashValue);
							FStream.Close();
						}
					}
					catch (IOException e)
					{
						Console.WriteLine($"ERROR: IO exception: {e.Message}");
					}
					catch (UnauthorizedAccessException e)
					{
						Console.WriteLine($"ERROR: You are not allowed to access that file: {e.Message}");
					}
				}
				else
				{
					Console.WriteLine("ERROR: The file you specified could not be found. Please check if you spelled it correctly.");
				}
			}
		}
		public static void PrintByteArray(byte[] ByteArray)
		{
			for (int i = 0; i < ByteArray.Length; i++)
			{
				Console.Write($"{ByteArray[i]:X2}");
				if ((i % 4) == 3) Console.Write(" ");
			}
			Console.WriteLine();
		}
	}
}
