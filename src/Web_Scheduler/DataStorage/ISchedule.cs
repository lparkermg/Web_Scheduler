using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Scheduler.DataStorage
{
    interface ISchedule
    {
        bool AddItem(DateTime date, string title, string description);
        bool AddItem(DateTime dateStart, DateTime dateEnd, string title, string description);
        void RemoveItem(DateTime date);
        void RemoveItem(DateTime startDate, DateTime endDate);

    }
}
