using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWUS
{
	class WorkUnitOrder
	{
		public Guid ID { get; set; }
		public Type WorkUnit { get; set; }
		public WorkUnitPriority Priority { get; set; }
		public object[] Args { get; set; }
	}
}
