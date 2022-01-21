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
            _reminderController = new ReminderController();

            var now = DateTime.Now;
            InitializeComponent();
            dateTimePickerStart.MinDate = now;
            dateTimePickerEnd.MinDate = now.AddDays(1).Date;

            start = dateTimePickerStart.Value;
            end = dateTimePickerEnd.Value;
            setDataSourse(start, end);
        }

        // получение списка между датами
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            start = dateTimePickerStart.Value;
            end = dateTimePickerEnd.Value;

            setDataSourse(start, end);
        }

        // получение списка на сегодня
        private void buttonFilterToday_Click(object sender, EventArgs e)
        {
            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerEnd.Value = DateTime.Now.AddDays(1);
            start = dateTimePickerStart.Value;
            end = dateTimePickerEnd.Value;

            setDataSourse(start, end);
        }


        // открываем окно для добавления задачи
        private void Create_Click(object sender, EventArgs e)
        {

            CreateReminder newReminder = new CreateReminder();
            newReminder.ShowDialog();

        }


        //убирать в трей при сворачивании
        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();

        }


        // Восстановление при двойном клике в трей
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;

        }

        //Всплывающие напоминания
        private void timer1_Tick(object sender, EventArgs e)
        {
            int minute = dateTimePickerTimer.Value.Minute;
            var reminderList = _reminderController.GetNotificationList(minute);
            if (reminderList != null)
            {
                foreach (var x in reminderList)
                {
                    // время до события
                    var timeLeft = x.DateTime.AddMinutes(1) - DateTime.Now;
                    notifyIcon1.BalloonTipTitle = string.Format("Через {0} минут событие:", timeLeft.Minutes);
                    notifyIcon1.BalloonTipText = string.Format("{0}\n{1}\n{2} ", x.DateTime, x.Title, x.Detail);
                    notifyIcon1.ShowBalloonTip(15000);
                }
            }
        }


        //Обновление данных при появлении.
        private void Main_Shown(object sender, EventArgs e)
        {
            setDataSourse(start, end);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();

        }

        private void Main_Activated(object sender, EventArgs e)
        {
            setDataSourse(start, end);
        }


        /// <summary>
        /// Обновление данных в Data Set
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void setDataSourse (DateTime start, DateTime end)
        {
            dataGridViewReminders.DataSource = _reminderController.GetReminderShortsAtRange(start, end);
        }


    }
}
