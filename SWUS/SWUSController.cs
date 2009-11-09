using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace SWUS
{
	public class SWUSController : MarshalByRefObject
	{
		QueueManager queueManager = new QueueManager();

		public SWUSController()
		{
		}

		public static SWUSController GetRemoteInstance(string address)
		{
			TcpChannel chan;
			if ((chan = (TcpChannel)ChannelServices.GetChannel("tcp")) == null)
			{
				chan = new TcpChannel();
				ChannelServices.RegisterChannel(chan, false);
			}

			SWUSController obj = (SWUSController)Activator.GetObject(typeof(SWUSController), address);

			return obj;
		}

		public void QueueWorkUnit(Type workUnit)
		{
			QueueWorkUnit(workUnit, WorkUnitPriority.Normal);
		}

		public void QueueWorkUnit(Type workUnit, WorkUnitPriority priority)
		{
			QueueWorkUnit(workUnit, priority, new object[] {});
		}

		public void QueueWorkUnit(Type workUnit, params object[] args)
		{
			QueueWorkUnit(workUnit, WorkUnitPriority.Normal, args);
		}

		public void QueueWorkUnit(Type workUnit, WorkUnitPriority priority, params object[] args)
		{
			WorkUnitOrder wuo = new WorkUnitOrder() { ID = Guid.NewGuid(), WorkUnit = workUnit, Priority = priority, Args = args };
			queueManager.QueueOrder(wuo);
		}


	}
}
