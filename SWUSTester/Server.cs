using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SWUS;

namespace SWUSTester
{
	public partial class Server : Form
	{
		public Server()
		{
			InitializeComponent();
		}

		private void Server_Load(object sender, EventArgs e)
		{
			RemotingController.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SWUSController controller = SWUSController.GetRemoteInstance("tcp://localhost:6669/SWUSController");
			controller.QueueWorkUnit(typeof(Server));
		}
	}
}
