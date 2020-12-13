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
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        DBHelper DBH = DBHelper.instance;
        int idForEdit;
        public AddContactWindow()
        {
            InitializeComponent();

            Button addBtn = new Button();

            addBtn.Name = "Add_Contact_btn";
            addBtn.Content = " Add Contact ";
            addBtn.Margin = new Thickness(50, 0, 0, 0);
            addBtn.Click += Add_Contact_btn_Click;

            Button_pnl.Children.Add(addBtn);
        }

        public AddContactWindow(int id, string fName, string lName, string add, string phoneNum, string email)
        {
            InitializeComponent();

            Add_Contact_Title.Content = "Edit a Contact by Changing the Textboxes:";

            First_Name_txt.Text = fName;
            Last_Name_txt.Text = lName;
            Address_txt.Text = add;
            Phone_Num_txt.Text = phoneNum;
            email_txt.Text = email;

            Button editBtn = new Button();

            editBtn.Name = "Edit_Contact_btn";
            editBtn.Content = " Edit Contact ";
            editBtn.Margin = new Thickness(50, 0, 0, 0);
            editBtn.Click += Edit_Contact_btn_Click;

            Button_pnl.Children.Add(editBtn);

            idForEdit = id;
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            First_Name_txt.Text = "Ex. Tristan";
            Last_Name_txt.Text = "Ex. Lafleur";
            Address_txt.Text = "Ex. 32 rue René";
            Phone_Num_txt.Text = "Ex. (438) 526-5985";
            email_txt.Text = "Ex. tristanblacklafleur@hotmail.ca";
        }

        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            string fN = First_Name_txt.Text;
            string lN = Last_Name_txt.Text;
            string ad = Address_txt.Text;
            string pN = Phone_Num_txt.Text;
            string em = email_txt.Text;

            DBH.addContacts(fN, lN, ad, pN, em);
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = idForEdit;
            string fN = First_Name_txt.Text;
            string lN = Last_Name_txt.Text;
            string ad = Address_txt.Text;
            string pN = Phone_Num_txt.Text;
            string em = email_txt.Text;

            DBH.editContacts(id, fN, lN, ad, pN, em);
        }
    }
}
