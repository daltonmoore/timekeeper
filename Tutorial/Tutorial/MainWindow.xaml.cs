using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeKeeper tk;

        public MainWindow()
        {
            InitializeComponent();
            tk = new TimeKeeper();
        }

        private void createUserButton_Click(object sender, RoutedEventArgs e)
        {
            string output = "";
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                output += "Input a username";
                return;
            }
            else
            {
                output += tk.createuser(userNameTextBox.Text);
            }
        }

    }
}
