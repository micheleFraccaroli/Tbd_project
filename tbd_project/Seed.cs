using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tbd_project;

namespace tbd_project
{
    class Seed
    {
        public void Seeding()
        {
            int num, i;
            String res = null;
            Conn newConn = new Conn();
            Console.WriteLine("Inserition:\n");

            Console.WriteLine("Quanti ne vuoi inserire? ");
            String n = Console.ReadLine();
            Int32.TryParse(n, out num);

            String q = "USE DB_Test;SELECT COUNT(*) as count FROM dbo.users";
            SqlConnection con = newConn.fun();
            con.Open();
            SqlCommand command = new SqlCommand(q, con);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    res = String.Format("{0}", reader["count"]);
                }
            }

            for (i = Int32.Parse(res) ; i < num + Int32.Parse(res); i++)
            {
                Console.WriteLine("Name: ");
                String name = Console.ReadLine();
                Console.WriteLine("Surame: ");
                String surname = Console.ReadLine();
                Console.WriteLine("Email: ");
                String email = Console.ReadLine();
                Console.WriteLine("Password: ");
                String pwd = Console.ReadLine();
                Console.WriteLine("Sesso: ");
                String sex = Console.ReadLine();
                Console.WriteLine("Data di nascita: ");
                String born = Console.ReadLine();

                String query = "USE DB_Test;INSERT INTO dbo.users (id,name,surname,email,pwd,sex,born) VALUES ("
                    + i + ",'"
                    + name + "','"
                    + surname + "','"
                    + email + "','"
                    + pwd + "','"
                    + sex + "','"
                    + born + "')";
                
                try
                {
                    SqlDataAdapter adapter = newConn.funA();
                    adapter.InsertCommand = new SqlCommand(query, con);
                    adapter.InsertCommand.ExecuteNonQuery();
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

                con.Close();
            }
        }
    }
}