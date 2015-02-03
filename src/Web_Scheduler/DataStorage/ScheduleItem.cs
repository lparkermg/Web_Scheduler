using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Scheduler.DataStorage
{
    public class ScheduleItem
    {
        public DateTime ScheduleDate { get; private set; }
        public string ScheduleTitle { get; private set; }
        public string ScheduleDescription { get; private set; }

        public ScheduleItem(DateTime scheduleDate, string scheduleTitle, string scheduleDescription)
        {
            ScheduleDate = scheduleDate;
            ScheduleTitle = scheduleTitle;
            ScheduleDescription = scheduleDescription;
        }
    }
}