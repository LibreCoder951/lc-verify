using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Drawing;

namespace LC951verifier
{
    public partial class ProgramForm : Form
	{
		private TextBox DirectoryInputBox;
		private Button CalcHashButton;

		public ProgramForm()
		{
			// Create elements
			this.DirectoryInputBox = new TextBox();
			this.CalcHashButton = new Button();

			this.Controls.Add(this.DirectoryInputBox);
			this.Controls.Add(this.CalcHashButton);

			// Configure elements
			this.ClientSize = new Size(260, 65);
			this.Text = "LC verify";

			this.DirectoryInputBox.Location = new Point(10, 10);
			this.DirectoryInputBox.Size = new Size(240, 15);

			this.CalcHashButton.Location = new Point(100, 35);
			this.CalcHashButton.Size = new Size(60, 20);
			this.CalcHashButton.Text = "Verify";
			this.CalcHashButton.Click += VerifyIsClicked;

			//InitializeComponent();
		}
		public void VerifyIsClicked(object ob, EventArgs e)
		{
			string SelectedDirectory = this.DirectoryInputBox.Text;
			if (Directory.Exists(SelectedDirectory) || File.Exists(SelectedDirectory))
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
								ShowSomethingBig BigForm = new ShowSomethingBig($"{FInfo.Name}: " + Program.PrintByteArray(HashValue));
								BigForm.ShowDialog();
								FStream.Close();
							}
							catch (IOException exc)
							{
								MessageBox.Show("[ERROR] IO exception");
							}
							catch (UnauthorizedAccessException exc)
							{
								MessageBox.Show("[ERROR] You are not allowed to access that file.");
							}
						}
					}
				}
				else if (File.Exists(SelectedDirectory))
				{
					try
					{
						using (SHA256 HashOfFile = SHA256.Create())
						{
							FileStream FStream = File.Open(SelectedDirectory, FileMode.Open);
							FStream.Position = 0;
							byte[] HashValue = HashOfFile.ComputeHash(FStream);
							ShowSomethingBig BigForm = new ShowSomethingBig(Program.PrintByteArray(HashValue));
							BigForm.ShowDialog();
							FStream.Close();
						}
					}
					catch (IOException exc)
					{
						MessageBox.Show("[ERROR] IO exception");
					}
					catch (UnauthorizedAccessException exc)
					{
						MessageBox.Show("[ERROR] You are not allowed to access that file.");
					}
				}
				else
				{
					ShowSomethingBig BigForm = new ShowSomethingBig("[ERROR] The directory or file you specified could not be found. Please check if you spelled its path correctly.");
					BigForm.ShowDialog();
				}
			}
		}
    }
}
