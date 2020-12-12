using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.BehindCodeClasses
{
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
                listContento.Add(new ContactsBinding() { ID = (int)sdr["ID"], firstName = checkForNull(sdr, "First_Name"), lastName = checkForNull(sdr, "Last_Name"), address = checkForNull(sdr, "Address"),
                                                         phoneNumber = checkForNull(sdr, "Phone_Num"), email = checkForNull(sdr, "email")});
            }
            con.Close();

            return listContento;
        }

        public ContactsBinding getDetails(int ID)
        {
            ContactsBinding CB = new ContactsBinding();

            //Create a new instance of the SQLCOnnection class and pass the database path as the parameter, specificy the database to choose & the connection type
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDatabase;Trusted_Connection = True");

            //Create an instance of the SQLCommand class & pass the SQL query as a parameter using the Connection class instance
            SqlCommand cm = new SqlCommand("Select First_Name + ' ' + Last_Name as Full_Name, Address + ' ' + Phone_Num + ' ' + email as Contact_Meth from Contact Where ID = @id", con);

            //Open the connection
            con.Open();

            cm.Parameters.AddWithValue("@id", ID);

            //Create an instance of the SQLDataReader class and initalize it using the SQLCommand instance's ExecuteReader method
            SqlDataReader sdr = cm.ExecuteReader();

            while (sdr.Read())
            {
                CB.fullName = checkForNull(sdr, "Full_Name");
                CB.contactMeth = checkForNull(sdr, "Contact_Meth");
            }

            con.Close();

            return CB;
        }

        public string checkForNull(SqlDataReader reader, string column)
        {
            if (reader[column].GetType() == typeof(DBNull))
                return String.Empty;
            else
                return (string)reader[column];
        }

        public void addContacts(String f, String l, String a, String p, String e)
        {
            //Create a new instance of the SQLCOnnection class and pass the database path as the parameter, specificy the database to choose & the connection type
            var con = new SqlConnection(@"data source=localhost\SQLEXPRESS;database = ContactDatabase;Trusted_Connection = True");

            //Create an instance of the SQLCommand class & pass the SQL query as a parameter using the Connection class instance
            SqlCommand cm = new SqlCommand("INSERT INTO contact (first_name, last_name, address, phone_num, email)" +
                                        "VALUES (@firstName, @lastName, @address, @phoneNumber, @email)", con);
            //Open the connection
            con.Open();
            cm.Parameters.AddWithValue("@firstName", f);
            cm.Parameters.AddWithValue("@lastName", l);
            cm.Parameters.AddWithValue("@address", a);
            cm.Parameters.AddWithValue("@phoneNumber", p);
            cm.Parameters.AddWithValue("@email", e);

            cm.ExecuteNonQuery();

            con.Close();
        }
    }
}
