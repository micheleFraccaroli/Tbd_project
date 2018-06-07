using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tbd_project;

namespace tbd_project
{
    class Moderate
    {
        public void updatePC()
        {
            String query = null;
            Console.Clear();
            Console.WriteLine("--- Moderate posts or comments ---");

            Console.WriteLine("Select what you want to moderate: \n1)Post\n2)Comment");
            String choice = Console.ReadLine();

            if(choice.Equals('1'))
            {
                Console.WriteLine("Id post: ");
                String id = Console.ReadLine();

                Console.WriteLine("New text: ");
                String text = Console.ReadLine();

                query = "USE DB_Test;UPDATE posts SET body = " + text + "WHERE id = " + Int32.Parse(id);
            }

            else if(choice.Equals('2'))
            {
                Console.WriteLine("Id comment: ");
                String id = Console.ReadLine();

                Console.WriteLine("New text: ");
                String text = Console.ReadLine();

                query = "USE DB_Test;UPDATE comments SET body = " + text + "WHERE id = " + Int32.Parse(id);
            }

            Conn newConn = new Conn();
            SqlConnection con = newConn.fun();
            con.Open();

            SqlCommand command = con.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            /*SqlDataAdapter adapter = newConn.funA();
            adapter.InsertCommand = new SqlCommand(query, con);
            adapter.InsertCommand.ExecuteNonQuery();*/

            con.Close();
            Console.WriteLine("User and his posts deleted!");
            Console.WriteLine("Press [Enter] to continue: ");
            String enter = Console.ReadLine();
        }
    }
}
