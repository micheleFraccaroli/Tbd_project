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

            if(choice.Equals("1"))
            {
                Console.WriteLine("Id post: ");
                String id = Console.ReadLine();

                Console.WriteLine("New text: ");
                String text = Console.ReadLine();

                query = "USE DB_Test;UPDATE posts SET body = '" + text + "' WHERE id = " + Int32.Parse(id);
            }

            else if(choice.Equals("2"))
            {
                Console.WriteLine("Id comment: ");
                String id = Console.ReadLine();

                Console.WriteLine("New text: ");
                String text = Console.ReadLine();

                query = "USE DB_Test;UPDATE comments SET body = '" + text + "' WHERE id = " + Int32.Parse(id);
            }

            Conn newConn = new Conn();
            SqlConnection con = newConn.fun();
            con.Open();
            
            try
            {
                SqlCommand command = con.CreateCommand();
                command.CommandText = query;
                int rows = command.ExecuteNonQuery();

                con.Close();
                if (rows > 0)
                {
                    Console.WriteLine("Udated! " + rows.ToString() + " rows updated!");
                }
                else
                {
                    Console.WriteLine("Ops! " + rows.ToString() + " rows updated!");
                }
                Console.WriteLine("Press [Enter] to continue: ");
                String enter = Console.ReadLine();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Console.WriteLine(ex);
                }
                else {
                    Console.WriteLine("Errore!");
                }
            }
        }
    }
}
