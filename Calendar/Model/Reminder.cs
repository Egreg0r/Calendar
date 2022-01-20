using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Model
{
    public class Reminder : BaseEntity
    {
        [Required (ErrorMessage = "Укажите дату и время")]
        [Display(Name ="Дата и время")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Укажите задачу")]
        [Display(Name = "Задача")]
        public string Title { get; set; }

        [Display(Name = "Подробнее")]
        public string Detail { get; set; }
    }
}
