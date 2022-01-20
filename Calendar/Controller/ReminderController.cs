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
        public void Create (Reminder reminder)
        {
            var title = reminder.Title;
            var date = reminder.DateTime;
            if (title == "") return;
            
            var guid = Guid.NewGuid();
            reminder.Id = guid;
            _baseContent.Add(reminder);
            try
            {
                _baseContent.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }


        }




    }
}
