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
            Conn newConn = new Conn();
            Console.WriteLine("Inserition:\n");

            Console.WriteLine("Chi vuoi inserire? ");
            String tab = Console.ReadLine();

            Console.WriteLine("Quanti ne vuoi inserire? ");
            String n = Console.ReadLine();
            Int32.TryParse(n, out num);

            for (i = 0; i < num; i++)
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

                String query = "USE DB_Test;INSERT INTO dbo." + tab + " (id,name,surname,email,pwd,sex,born) VALUES ("
                    + i + ",'"
                    + name + "','"
                    + surname + "','"
                    + email + "','"
                    + pwd + "','"
                    + sex + "','"
                    + born + "')";

                SqlConnection con = newConn.fun();
                con.Open();

                SqlDataAdapter adapter = newConn.funA();
                Console.WriteLine(query);
                Console.WriteLine("OK?? ---> ");
                String confirm = Console.ReadLine();
                adapter.InsertCommand = new SqlCommand(query, con);
                adapter.InsertCommand.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}