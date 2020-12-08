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
        public DetailsWindow(ContactsBinding CB)
        {
            InitializeComponent();

            this.CB = CB;

            fNametxt.Text = "First Name: " + CB.firstName.ToString();
            lNametxt.Text = "Last Name: " + CB.lastName.ToString();
            addresstxt.Text = "Address: " + CB.address.ToString();
            phonetxt.Text = "Phone Number: " + CB.phoneNumber.ToString();
            emailtxt.Text = "E-Mail: " + CB.email.ToString();
        }
    }
}
