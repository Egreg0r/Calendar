using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void buttonFilter_Click(object sender, EventArgs e)
        {

        }

        // открываем окно для добавления задачи
        private void Create_Click(object sender, EventArgs e)
        {

            CreateReminder newReminder = new CreateReminder();
            newReminder.ShowDialog();

        }

    }
}
