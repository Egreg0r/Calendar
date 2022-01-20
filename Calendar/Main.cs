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

        // открываем окно для добавления задачи
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form CreateNewTask = new Form();
        }
    }
}
