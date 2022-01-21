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
    public partial class CreateReminder : Form
    {
        ReminderController _reminderController; 
        public CreateReminder()
        {
            InitializeComponent();
            var now = DateTime.Now;
            dateTimePickerDate.Value = now;
            dateTimePickerDate.MinDate = now;
            dateTimePickerTime.Value = now;
            
            buttonOk.Enabled = false;
            _reminderController = new ReminderController();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(dateTimePickerDate.Value.ToShortDateString() +" "+ dateTimePickerTime.Value.ToShortTimeString());
            _reminderController.Create(dateTime, textBoxTitle.Text, textBoxDetail.Text);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            //Проверка на пустую строку либо строку состоящую из пробелов. 
            if (textBoxTitle.Text.Trim() != "")
                buttonOk.Enabled = true;
            else buttonOk.Enabled = false;
        }
    }
}
