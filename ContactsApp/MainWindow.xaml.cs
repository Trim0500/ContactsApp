﻿using System;
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
using System.Windows.Controls.Primitives;
using Microsoft.Win32;
using System.IO;

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

        private void ContactsListItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ContactsBinding selectedContact = (ContactsBinding)ContactsListItems.SelectedItem;

            if (selectedContact != null)
            {
                DetailsWindow newWindow = new DetailsWindow(selectedContact.ID);
                newWindow.ShowDialog();
            }

            contacts = DBH.getContacts();

            ContactsListItems.ItemsSource = contacts;
        }        
        private void ContactsListItems_MouseEnter(object sender, MouseEventArgs e)
        {
            ContactPopUp.PlacementTarget = ContactsListItems;
            ContactPopUp.Placement = PlacementMode.Top;
            ContactPopUp.IsOpen = true;
        }

        private void ContactsListItems_MouseLeave(object sender, MouseEventArgs e)
        {
            ContactPopUp.IsOpen = false;
        }

        private void Add_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            AddContactWindow ACW1 = new AddContactWindow();

            ACW1.ShowDialog();

            contacts = DBH.getContacts();

            ContactsListItems.ItemsSource = contacts;

            MessageBox.Show("Contact successfully added.");
        }

        private void Edit_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            ContactsBinding selectedContact = (ContactsBinding)ContactsListItems.SelectedItem;

            if(selectedContact == null)
            {
                MessageBox.Show("You have to select a contact to edit.");
                return;
            }
            else
            {
                int idToPass = selectedContact.ID;
                string first = selectedContact.firstName;
                string last = selectedContact.lastName;
                string address = selectedContact.address;
                string phone = selectedContact.phoneNumber;
                string email = selectedContact.email;

                AddContactWindow ACW1 = new AddContactWindow(idToPass, first, last, address, phone, email);

                ACW1.ShowDialog();
            }

            contacts = DBH.getContacts();

            ContactsListItems.ItemsSource = contacts;

            MessageBox.Show("All changes have been saved to the database.");
        }

        private void Del_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deleting the selected contact...");

            ContactsBinding CB1 = (ContactsBinding)ContactsListItems.SelectedItem;

            DBH.deleteContacts(CB1.ID);

            contacts = DBH.getContacts();

            ContactsListItems.ItemsSource = contacts;
        }

        private void Imp_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "*.csv|*.csv|All files(*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                var myContacts = File.ReadLines(openFileDialog.FileName);
                foreach(String line in myContacts)
                {
                    String[] contactInfo = line.Split(',');
                    DBH.addContacts(contactInfo[0], contactInfo[1], contactInfo[2], contactInfo[3], contactInfo[4]);
                }
                MessageBox.Show("Your contacts have been added.");
            }
            else
            {
                MessageBox.Show("An error occured with the open dialogue box...");
            }
            
            contacts = DBH.getContacts();

            ContactsListItems.ItemsSource = contacts;
        }

        private void Ex_Contact_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.Filter = "*.csv|*.csv|All files(*.*)|*.*";
            
            if(saveFileDialog.ShowDialog() == true)
            {
                String myContacts= "";

                foreach(ContactsBinding contact in contacts)
                {
                    myContacts += contact.firstName + "," + contact.lastName + "," + contact.address + "," + contact.phoneNumber + "," + contact.email + "\r\n";
                }
                File.WriteAllText(saveFileDialog.FileName, myContacts);
            }
        }
    }
}
