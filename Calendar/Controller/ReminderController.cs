using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Calendar.Model;

/// <summary>
/// https://habr.com/ru/post/324272/
/// </summary>

namespace Calendar.Controller
{
    public class ReminderController 
    {
        private readonly BaseContent _baseContent;

        public ReminderController(BaseContent baseContent)
        {
            _baseContent = baseContent;
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
            try
            {
                _baseContent.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

        }

        public List<Reminder> GetRemindersAtRange (DateTime start, DateTime end)
        {
            var remList =  _baseContent.Reminders.Where(st => st.DateTime >= start && st.DateTime <= end);
            return remList.ToList();

        }




    }
}
