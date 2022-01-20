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
        public CreateReminder()
        {
            InitializeComponent();
            var now = DateTime.UtcNow;
            dateTimePickerDate.Value = now;
            dateTimePickerTime.Value = now;
            buttonOk.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DateTime dateTime = Convert.ToDateTime(dateTimePickerDate.Value.ToString() + dateTimePickerTime.Value.ToString());

            var remContr = new ReminderController();
            remContr.Create(dateTime, textBoxTitle.Text, textBoxDetail.Text);
            
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
