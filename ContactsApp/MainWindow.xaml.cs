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
using ContactsApp.BehindCodeClasses;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<ContactsBinding> listContento = new List<ContactsBinding>();

            //listContento.Add(new ContactsBinding() { ContactInfo = "This is text" });

            //ContactsListItems.ItemsSource = listContento;

            for (int i = 0; i < 20; i++)
            {
                listContento.Add(new ContactsBinding() { ContactInfo = "This is a test" });
            }

            ContactsListItems.ItemsSource = listContento;
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("This is a test");
        }

        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
        }

        private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
        }
    }
}
