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
                listContento.Add(new ContactsBinding() { ID = (int)sdr["ID"], firstName = (string)sdr["First_Name"], lastName = (string)sdr["Last_Name"], address = (string)sdr["Address"],
                                                         phoneNumber = (string)sdr["Phone_Num"], email = (string)sdr["email"]});
            }
            con.Close();

            return listContento;
        }

        public string getDetails(int ID)
        {
            string rowContent = null;

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
                ContactsBinding CB1 = new ContactsBinding(){ fullName = (string)sdr["Full_Name"], contactMeth = (string)sdr["Contact_Meth"]};
                StringBuilder SB = new StringBuilder();
                SB.Append("Full Name: ");
                SB.Append(CB1.fullName);
                SB.Append("\n\n");
                SB.Append(CB1.contactMeth);
                rowContent = SB.ToString();
            }

            con.Close();

            return rowContent;
        }
    }
}
