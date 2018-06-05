using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tbd_project;

namespace tbd_project
{
    class Posts
    {
        public void getPosts()
        {
            Console.Clear();
            Console.WriteLine("--- Seleziona post tramite utente ---");
            UserPosts();
        }

        public void UserPosts()
        {
            String query = null;
            Console.WriteLine("Nome: ");
            String name = Console.ReadLine();

            Console.WriteLine("Procedo?[Yes/no]");
            String check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
            {
                query = "USE DB_Test;SELECT body FROM dbo.posts as p JOIN dbo.users as u ON p.id_user = u.id WHERE u.name LIKE '" + name + "'";
            }
            else if(check.Equals("N") || check.Equals("n"))
            {
                Console.WriteLine("Cognome: ");
                String surname = Console.ReadLine();
                query = "USE DB_Test;SELECT body FROM dbo.posts as p JOIN dbo.users as u ON p.id_user = u.id WHERE u.name LIKE '" + name + "' AND u.surname LIKE '" + surname + "'";
            }
            else
            {
                Console.WriteLine("Compila un campo!");
                Console.Clear();
                UserPosts();
            }

            Conn newConn = new Conn();
            SqlConnection con = newConn.fun();
            con.Open();

            SqlCommand command = new SqlCommand(query, con);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                int c = 0;
                if (reader.Read())
                {
                    do
                    {
                        Console.WriteLine(String.Format("{0}", reader["body"]));   //body post
                    } while (reader.NextResult());
                }
            }
        }
    }
}
