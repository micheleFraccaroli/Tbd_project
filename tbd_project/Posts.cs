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
                query = "USE DB_Test;SELECT p.id as id, p.body as bp, c.body as cp FROM dbo.posts as p JOIN dbo.users as u ON p.id_user = u.id JOIN dbo.comments as c ON p.id = c.ip_post WHERE u.name LIKE '" + name + "'";
            }
            else if(check.Equals("N") || check.Equals("n"))
            {
                Console.WriteLine("Cognome: ");
                String surname = Console.ReadLine();
                query = "USE DB_Test;SELECT p.id as id, p.body as bp, c.body as cp FROM dbo.posts as p JOIN dbo.users as u ON p.id_user = u.id JOIN dbo.comments as c ON p.id = c.ip_post WHERE u.name LIKE '" + name + "' AND u.surname LIKE '" + surname + "'";
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

                Console.WriteLine("[post -> comment]");
                
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{2}: {0} -> {1}", reader["bp"], reader["cp"], reader["id"]));   //body post

                }
                con.Close();

                Console.WriteLine("[D] for delete: ");
                String d = Console.ReadLine();
                Console.WriteLine("Select post to delete white id: ");
                String p = Console.ReadLine();

                tbd_project.DeletePost dp = new DeletePost();
                dp.dPost(p);

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
