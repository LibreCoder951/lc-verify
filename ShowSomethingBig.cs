using System;
using System.Windows.Forms;
using System.Drawing;

namespace LC951verifier
{
    public partial class ShowSomethingBig : Form
	{
        string FromMainForm;
		private Label Label1;
		public ShowSomethingBig()
		{
            this.ClientSize = new Size(400, 65);
            this.Label1 = new Label();
            this.Label1.Size = new Size(400, 65);
			this.Controls.Add(this.Label1);
		}
        public ShowSomethingBig(string FromMainFormRecieved)
        {
            this.FromMainForm = FromMainFormRecieved;
            this.ClientSize = new Size(400, 65);
            this.Label1 = new Label();
            this.Label1.Size = new Size(400, 65);
			this.Controls.Add(this.Label1);
			this.Label1.Text = this.FromMainForm;
        }
	}
}
