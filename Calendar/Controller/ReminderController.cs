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

        public List<ReminderShort> GetRemindersAtRange (DateTime start, DateTime end)
        {

            var remList = _baseContent.Reminders.Where(st => st.DateTime >= start && st.DateTime <= end);
            return remList.ToList();
        }



    }
}
