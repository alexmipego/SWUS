using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace SWUS
{
	public class RemotingController
	{
		public static void Start()
		{
			TcpChannel channel = (TcpChannel)ChannelServices.GetChannel("tcp");
			if (channel == null)
			{
				channel = new TcpChannel(6669);
				ChannelServices.RegisterChannel(channel, false);
			}
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(SWUSController), "SWUSController", WellKnownObjectMode.Singleton);
		}

		public static void Stop()
		{
			
		}
	}
}
