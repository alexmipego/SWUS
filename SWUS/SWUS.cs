using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace SWUS
{
	public partial class SWUS : ServiceBase
	{
		public SWUS()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			RemotingController.Start();
		}

		protected override void OnStop()
		{
			RemotingController.Stop();
		}
	}
}
