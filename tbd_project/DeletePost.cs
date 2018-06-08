using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tbd_project;

namespace tbd_project
{
    class DeletePost
    {
        public void dPost(String postId)
        {
            String query = null;
            //Console.Clear();
            Console.WriteLine("--- Deleting post ---");

            query = "USE DB_Test;DELETE FROM dbo.posts WHERE id = " + Int32.Parse(postId);

            Conn newConn = new Conn();
            SqlConnection con = newConn.fun();
            con.Open();

            try
            {
                SqlDataAdapter adapter = newConn.funA();
                adapter.InsertCommand = new SqlCommand(query, con);
                adapter.InsertCommand.ExecuteNonQuery();

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
                    Console.WriteLine("Errore!");
                }
            }
            Console.WriteLine("Post deleted!");
            Console.WriteLine("Press [Enter] to continue: ");
            String enter = Console.ReadLine();
        }
    }
}
