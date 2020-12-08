using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using ContactsApp.BehindCodeClasses;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ContactsBinding> contacts = new List<ContactsBinding>();
        DBHelper DBH = DBHelper.instance;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contacts = DBH.getContacts();
            ContactsListItems.ItemsSource = contacts;
        }

        private void ContactsListItems_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ContactsBinding selectedContact = (ContactsBinding)ContactsListItems.SelectedItem;
            if(selectedContact != null)
            {
                DetailsWindow newWindow = new DetailsWindow(selectedContact);
                newWindow.ShowDialog();
            }
            contacts = DBH.getContacts();
            ContactsListItems.ItemsSource = contacts;
        }
        
        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
            contacts = DBH.getContacts();
            ContactsListItems.ItemsSource = contacts;
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
            contacts = DBH.getContacts();
            ContactsListItems.ItemsSource = contacts;
        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
            contacts = DBH.getContacts();
            ContactsListItems.ItemsSource = contacts;
        }

        private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
        }

        private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
        }

        
    }
}
