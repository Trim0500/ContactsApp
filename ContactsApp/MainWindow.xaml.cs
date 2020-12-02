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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBHelper DBH1 = DBHelper.instance;

            //List<ContactsBinding> listContento = new List<ContactsBinding>();

            //listContento.Add(new ContactsBinding() { ContactInfo = "This is text" });

            //ContactsListItems.ItemsSource = listContento;

            /*for (int i = 0; i < 20; i++)
            {
                listContento.Add(new ContactsBinding() { ContactInfo = DBH1.getContacts() });
            }*/

            ContactsListItems.ItemsSource = DBH1.getContacts();
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

        private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a test");
        }
    }

    public sealed class DBHelper
    {
        DBHelper() { }

        static readonly DBHelper DBH = new DBHelper();

        public static DBHelper instance
        {
            get { return DBH; }
        }

        public List<ContactsBinding> getContacts()
        {
            List<ContactsBinding> listContento = new List<ContactsBinding>();

            //Create a new instance of the SQLCOnnection class and pass the database path as the parameter, specificy the database to choose & the connection type
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDatabase;Trusted_Connection = True");

            //Create an instance of the SQLCommand class & pass the SQL query as a parameter using the Connection class instance
            SqlCommand cm = new SqlCommand("Select ID, First_Name, Last_Name, Address, Phone_Num, email from Contact", con);

            //Open the connection
            con.Open();

            //Create an instance of the SQLDataReader class and initalize it using the SQLCommand instance's ExecuteReader method
            SqlDataReader sdr = cm.ExecuteReader();

            //While the reader has more rows to find...
            while (sdr.Read())
            {
                // Display Record
                listContento.Add(new ContactsBinding() { ContactInfo = sdr["ID"] + " " + sdr["Last_Name"] + " " + sdr["email"] });
            }
            con.Close();

            return listContento;
        }
    }
}
