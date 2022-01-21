using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Calendar.Model;

/// <summary>
/// https://habr.com/ru/post/324272/
/// https://docs.microsoft.com/ru-ru/ef/ef6/fundamentals/databinding/winforms
/// </summary>

namespace Calendar.Controller
{
    public class ReminderController 
    {
        private readonly BaseContent _baseContent;

        private static List<Reminder> remindOldList = new List<Reminder>();

        public ReminderController()
        {
            _baseContent = new BaseContent();
        }

        /// <summary>
        /// Create new reminder
        /// </summary>
        /// <param name="reminder"></param>
        public void Create (DateTime dateTime, string title, string detail)
        {
            var reminder =  new Reminder()
            {
                Id = Guid.NewGuid(),
                DateTime = dateTime,
                Title = title,
                Detail = detail
            };

            _baseContent.Add(reminder);
            _baseContent.SaveChanges();

        }

        public List<ReminderShort> GetReminderShortsAtRange (DateTime start, DateTime end)
        {

            var reminders = _baseContent.Reminders.Where(st => st.DateTime >= start && st.DateTime <= end)
                .Select(x => 
                new ReminderShort()
                {
                    DateTime = x.DateTime,
                    Title = x.Title
                })
                .ToList();
            return reminders;
        }


        /// <summary>
        /// receive a list of notifications until which there are minute left
        /// </summary>
        /// <param name="milisecon"></param>
        /// <returns></returns>
        public List<Reminder> GetNotificationList (int minute = 5)
        {
            var nowTime = DateTime.Now;
            // дата 
            var endTime = nowTime.AddMinutes(minute);

            var remindNewList = _baseContent.Reminders.Where(st => st.DateTime >= nowTime && st.DateTime <= endTime).ToList();

            //Определяем новые уведомления
            var diffList = remindNewList.Except(remindOldList).ToList();

            remindOldList = remindNewList;

            if (diffList.Count != 0)
                return diffList.ToList();
            else
                return null;
        }




    }
}
