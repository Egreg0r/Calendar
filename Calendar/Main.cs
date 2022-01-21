using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar.Controller;

namespace Calendar
{
    public partial class Main : Form
    {
        ReminderController _reminderController;

        //переменные для хранения ограничения филтра
        DateTime start, end;
        public Main()
        {
            var now = DateTime.Now;
            InitializeComponent();
            dateTimePickerStart.MinDate = now;
            dateTimePickerEnd.MinDate = now.AddDays(1);

            _reminderController = new ReminderController();
            start = dateTimePickerStart.Value;
            end = dateTimePickerEnd.Value;
            dataGridViewReminders.DataSource = _reminderController.GetRemindersAtRange(start, end);
            dataGridViewReminders.Columns["ID"].Visible = false;
        }


        private void buttonFilter_Click(object sender, EventArgs e)
        {
            dataGridViewReminders.DataSource = _reminderController.GetRemindersAtRange(start, end);
        }

        // открываем окно для добавления задачи
        private void Create_Click(object sender, EventArgs e)
        {

            CreateReminder newReminder = new CreateReminder();
            newReminder.ShowDialog();

        }

        private void buttonFilterToday_Click(object sender, EventArgs e)
        {

        }


    }
}
