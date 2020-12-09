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
using System.Windows.Shapes;
using ContactsApp.BehindCodeClasses;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        ContactsBinding CB;
        public DetailsWindow(int id)
        {
            InitializeComponent();

            DBHelper DBH = DBHelper.instance;

            CB = DBH.getDetails(id);

            nametxt.Text = "Name:\n" + CB.fullName.ToString();
            contactInfotxt.Text = "Points of Contact:\n" + CB.contactMeth.ToString();
        }
    }
}
