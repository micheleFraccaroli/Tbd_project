using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tbd_project;

namespace tbd_project
{
    class Users
    {
        public void getUsers()
        {
            String check = null;
            Console.WriteLine("--- View user into system ---\n");

            Console.WriteLine("Name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if(check.Equals("Yes") || check.Equals("yes"))
            {
                Commit(name);
            }
            Console.WriteLine("Surname: ");
            String surname = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Yes") || check.Equals("yes"))
            {
                Commit(name, surname);
            }
            Console.WriteLine("Email: ");
            String email = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Yes") || check.Equals("yes"))
            {
                Commit(name, surname, email);
            }
            Console.WriteLine("Date: ");
            String date = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Yes") || check.Equals("yes"))
            {
                Commit(name, surname, email, date);
            }
            else
            {
                Console.WriteLine("Devi inserire almeno un elemento.. riprova!");
                getUsers();
            }
        }

        public void Commit(String name = "", String surname = "", String email = "", String date = "")
        {
            String query = "SELECT * FROM dbo.users WHERE ";
            if(!name.Equals(""))
            {
                query = query + "name = '" + name + "' AND";
            }
            if (!surname.Equals(""))
            {
                query = query + "surname = '" + surname + "' AND";
            }
            if (!email.Equals(""))
            {
                query = query + "email = '" + email + "' AND";
            }
            if (!date.Equals(""))
            {
                query = query + "date = '" + date + "' AND";
            }

            query = query.Remove(query.Length - 4);

            Conn newConn = new Conn();
            SqlConnection con = newConn.fun();
            con.Open();

            Console.WriteLine(query);
            Console.WriteLine("OK?? ---> ");
            String confirm = Console.ReadLine();
            SqlCommand command = new SqlCommand(query, con);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["id"]));
                }
            }
        }
    }
}
