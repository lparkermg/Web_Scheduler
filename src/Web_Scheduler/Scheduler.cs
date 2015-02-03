using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Scheduler.DataStorage;

namespace Web_Scheduler
{
    public class Scheduler : ISchedule

    {
        private Dictionary<DateTime,ScheduleItem> _InMemorySchedule = new Dictionary<DateTime, ScheduleItem>(); 

        public bool AddItem(DateTime date, string title, string description)
        {
            _InMemorySchedule.Add(date,new ScheduleItem(date,title,description));
            return true;
        }

        public bool AddItem(DateTime dateStart, DateTime dateEnd, string title, string description)
        {
            foreach(DateTime day in EachDay(dateStart,dateEnd))
                _InMemorySchedule.Add(day,new ScheduleItem(day,title,description));
        }

        public void RemoveItem(DateTime date)
        {
            _InMemorySchedule.Remove(date);
        }

        public void RemoveItem(DateTime startDate, DateTime endDate)
        {
            foreach (DateTime day in EachDay(startDate, endDate))
                _InMemorySchedule.Remove(day);
        }

        public ScheduleItem GetItem(DateTime date)
        {
            return CheckForScheduleItem(date);
        }

        public List<ScheduleItem> GetItem(DateTime startDate, DateTime endDate)
        {
            List<ScheduleItem> scheduleList = new List<ScheduleItem>();
            foreach(DateTime day in EachDay(startDate,endDate))
                scheduleList.Add(_InMemorySchedule[day]);
            return scheduleList;
        }

        private IEnumerable<DateTime> EachDay(DateTime startDate, DateTime endDate)
        {
            for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
                yield return day;
        }

        private ScheduleItem CheckForScheduleItem(DateTime date)
        {
            if (_InMemorySchedule.ContainsKey(date))
            {
                var scheduleItem = _InMemorySchedule[date];
                return scheduleItem;
            }
            else
            {
                return null;
            }
        }
    }
}