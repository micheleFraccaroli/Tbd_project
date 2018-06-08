using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using tbd_project;

namespace tbd_project
{
    class Posts
    {
        public void getPosts()
        {
            Console.Clear();
            tbd_project.main m = new main();
            m.logo();
            Console.WriteLine("--- Seleziona post tramite utente ---");
            UserPosts();
            return;
        }

        public void UserPosts()
        {
            String query = null;
            String[] idPost = new String[50];
            Console.WriteLine("Nome: ");
            String name = Console.ReadLine();

            Console.WriteLine("Procedo?[Yes/no]");
            String check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
            {
                query = "USE DB_Test;SELECT p.id as id, p.body as bp FROM dbo.posts as p JOIN dbo.users as u ON p.id_user = u.id WHERE u.name LIKE '" + name + "'";
            }
            else if(check.Equals("N") || check.Equals("n"))
            {
                Console.WriteLine("Cognome: ");
                String surname = Console.ReadLine();
                query = "USE DB_Test;SELECT p.id as id, p.body as bp FROM dbo.posts as p JOIN dbo.users as u ON p.id_user = u.id JOIN WHERE u.name LIKE '" + name + "' AND u.surname LIKE '" + surname + "'";
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
            try
            {
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("[posts]");

                int i = 0;
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{1}: {0}", reader["bp"], reader["id"]));   //body post
                    idPost[i] = String.Format("{0}", reader["id"]);
                    i++;
                }

                reader.Close();
                Console.WriteLine("\n[comments]");
                foreach (String j in idPost)
                {
                    if (j == null)
                    {
                        break;
                    }
                    String com_quer = "USE DB_Test;SELECT body, ip_post FROM dbo.comments WHERE ip_post = " + Int32.Parse(j);
                    SqlCommand command2 = new SqlCommand(com_quer, con);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    
                    while (reader2.Read())
                    {
                        Console.WriteLine(String.Format("{1}: {0}", reader2["body"], reader2["ip_post"]));   //body comment
                    }

                    reader2.Close();
                }

                Console.WriteLine("[D] for delete: ");
                String d = Console.ReadLine();
                if(d.Equals("d") || d.Equals("D"))
                {
                    Console.WriteLine("Select post to delete white id: ");
                    String p = Console.ReadLine();
                    tbd_project.DeletePost dp = new DeletePost();
                    dp.dPost(p);
                }
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

            con.Close();
            Console.WriteLine("Press [Enter] to continue: ");
            String enter = Console.ReadLine();
        }
    }
}
