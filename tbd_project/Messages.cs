using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tbd_project;
using System.Data.SqlClient;
using System.Data;

namespace tbd_project
{
    class Messages
    {
        public void getMessage()
        {
            String query1 = null;
            String query2 = null;
            String query_final = null;
            String id1 = null;
            String id2 = null;

            Console.Clear();
            Console.WriteLine("--- Messages between users ---");

            Console.WriteLine("Name user 1: ");
            String n_usr1 = Console.ReadLine();
            Console.WriteLine("Surname user 1: ");
            String s_usr1 = Console.ReadLine();
            query1 = "USE DB_Test;SELECT id FROM dbo.users WHERE name = '" + n_usr1 + "' AND surname = '" + s_usr1 + "'";

            Console.WriteLine("Name user 2: ");
            String n_usr2 = Console.ReadLine();
            Console.WriteLine("Surname user 2: ");
            String s_usr2 = Console.ReadLine();
            query2 = "USE DB_Test;SELECT id FROM dbo.users WHERE name = '" + n_usr2 + "' AND surname = '" + s_usr2 + "'";

            try
            {
                Conn newConn = new Conn();
                SqlConnection con = newConn.fun();
                con.Open();

                SqlCommand command1 = new SqlCommand(query1, con);
                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.Read())
                {
                    id1 = (String.Format("{0}", reader1["id"]));
                }
                reader1.Close();
                SqlCommand command2 = new SqlCommand(query2, con);
                SqlDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    id2 = (String.Format("{0}", reader2["id"]));
                }
                reader2.Close();

                query_final = "USE DB_Test;SELECT body FROM dbo.messages WHERE id_u1 = " + Int32.Parse(id1) + " AND id_u2 = " + Int32.Parse(id2)
                    + "OR id_u1 = " + Int32.Parse(id2) + " AND id_u2 = " + Int32.Parse(id1);

                SqlCommand command = new SqlCommand(query_final, con);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Messages ----- ");
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("-> {0}", reader["body"]));   //body message
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
