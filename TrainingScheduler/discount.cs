using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingScheduler
{
    public partial class discount : Form
    {
        public discount()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Globals.trainingDiscount = Convert.ToInt32(textBox1.Text);
            Globals.testingDiscount = Convert.ToInt32(testTextBox.Text);
            this.Close();
        }
    }
}
