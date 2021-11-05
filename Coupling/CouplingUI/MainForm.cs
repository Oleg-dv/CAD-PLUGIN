using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CouplingUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Построить
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введённое значение = 30 мм. Область допустимых значений от 6 мм до 24 мм!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
