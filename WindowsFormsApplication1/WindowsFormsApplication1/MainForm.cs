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
    public partial class MainForm : Form
    {
        TimeKeeper tk;

        public MainForm()
        {
            InitializeComponent();
            tk = new TimeKeeper();
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            string output = "";
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                ErrorForm f = new ErrorForm("Input a username");
                f.Show();
                return;
            }
            else
            {
                output += tk.createuser(userNameTextBox.Text);
            }
            done(output);
        }

        void done(string output)
        {
            OutputForm f = new OutputForm(output);
            f.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            string output = tk.cleanup();
            Console.WriteLine(output);
        }

        private void clockInButton_Click(object sender, EventArgs e)
        {
            string output = "";
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                ErrorForm f = new ErrorForm("Input a username");
                f.Show();
                return;
            }
            else
            {
                output += tk.clockin(userNameTextBox.Text);
            }
            done(output);
        }

        private void clockOutButton_Click(object sender, EventArgs e)
        {
            string output = "";
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                ErrorForm f = new ErrorForm("Input a username");
                f.Show();
                return;
            }
            else
            {
                output += tk.clockout(userNameTextBox.Text);
            }
            done(output);
        }

        private void calculateHoursButton_Click(object sender, EventArgs e)
        {
            string output = "";
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                ErrorForm f = new ErrorForm("Input a username");
                f.Show();
                return;
            }
            else
            {
                output += tk.calculatehours(userNameTextBox.Text);
            }
            done(output);
        }
    }
}
