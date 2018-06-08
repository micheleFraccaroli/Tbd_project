using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tbd_project;

namespace tbd_project
{
    class Notify
    {
        public void getNotify()
        {
            String query = null;
            Console.Clear();
            Console.WriteLine("--- Get activity for user ---");

            Console.WriteLine("Select user: \nName: ");
            String name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            String surname = Console.ReadLine();

            query = "USE DB_Test;SELECT body, type FROM dbo.notification as n JOIN dbo.users as u ON n.id_utente = u.id WHERE u.name = '" + name + "' AND u.surname = '" + surname + "'";

            Conn newConn = new Conn();
            SqlConnection con = newConn.fun();
            con.Open();

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0} -> {1}", reader["type"],reader["body"]));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Console.WriteLine(ex);
                }
                else
                {
                    Console.WriteLine(ex);
                }
            }

            Console.WriteLine("Press [Enter] to continue: ");
            String enter = Console.ReadLine();
        }
    }
}
