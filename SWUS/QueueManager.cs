using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWUS
{
	class QueueManager
	{
		const int MAX_THREADS = 20;

		List<WorkUnitOrder> allWorkUnits = new List<WorkUnitOrder>();
		List<WorkUnitOrder> runningWorkUnits = new List<WorkUnitOrder>();
		List<WorkUnitOrder> queueLowPriority = new List<WorkUnitOrder>();
		List<WorkUnitOrder> queueNormalPriority = new List<WorkUnitOrder>();
		List<WorkUnitOrder> queueHighPriority = new List<WorkUnitOrder>();

		public bool QueueOrder(WorkUnitOrder wuo)
		{
			if (GetWorkUnitOrder(wuo.ID) != null)
				return false;

			allWorkUnits.Add(wuo);

			GetPriorityListForWorkUnit(wuo).Add(wuo);

			return true;
		}

		List<WorkUnitOrder> GetPriorityListForWorkUnit(WorkUnitOrder wuo) {
			if (wuo.Priority == WorkUnitPriority.Low)
				return queueLowPriority;
			else if (wuo.Priority == WorkUnitPriority.Normal)
				return queueNormalPriority;
			else
				return queueHighPriority;
		}

		public WorkUnitOrder GetWorkUnitOrder(Guid guid)
		{
			return allWorkUnits.Find(ewuo => ewuo.ID == guid);
		}

		public bool WorkUnitComplete(WorkUnitOrder wuo)
		{
			return WorkUnitComplete(wuo.ID);
		}

		public WorkUnitOrder GetNextWorkUnitJob()
		{
			// for now ignoring priorities, later we can add a weight based system to pick the best one based on # of max threads
			WorkUnitOrder wuo = allWorkUnits.Except(runningWorkUnits).FirstOrDefault();
			runningWorkUnits.Add(wuo);
			return wuo;
		}

		public bool WorkUnitComplete(Guid guid)
		{
			WorkUnitOrder wuo = GetWorkUnitOrder(guid);
			if (wuo == null)
				return false;

			allWorkUnits.Remove(wuo);
			runningWorkUnits.Remove(wuo);
			GetPriorityListForWorkUnit(wuo).Remove(wuo);

			return true;
		}
	}
}
