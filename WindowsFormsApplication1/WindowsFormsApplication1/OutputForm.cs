using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class OutputForm : Form
    {
        public OutputForm(string output)
        {
            InitializeComponent();
            doneTextBox.Text = output+"\r\n done";
        }

        private void doneTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
