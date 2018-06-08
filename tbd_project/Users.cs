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
            Console.Clear();
            Console.WriteLine("--- View user into system ---");
            Console.WriteLine("[b for return to main menù]");

            String back = Console.ReadLine();
            if (back.Equals("b"))
            {
                tbd_project.main main = new main();
                //main.Menu();
                System.Environment.Exit(1); // momentaneamente chiudo l'app
            }

            Console.WriteLine("Name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if(check.Equals("Y") || check.Equals("y"))
            {
                Commit(name);
            }
            Console.WriteLine("Surname: ");
            String surname = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
            {
                Commit(name, surname);
            }
            Console.WriteLine("Email: ");
            String email = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
            {
                Commit(name, surname, email);
            }
            Console.WriteLine("Date: ");
            String date = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
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
            String query = "USE DB_Test;SELECT * FROM dbo.users WHERE ";
            if(!name.Equals(""))
            {
                query = query + "name = '" + name + "' AND ";
            }
            if (!surname.Equals(""))
            {
                query = query + "surname = '" + surname + "' AND ";
            }
            if (!email.Equals(""))
            {
                query = query + "email = '" + email + "' AND ";
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

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader["name"]));   //name
                        Console.WriteLine(String.Format("{0}", reader["surname"]));   //surname
                        Console.WriteLine(String.Format("{0}", reader["email"]));   //email
                        Console.WriteLine(String.Format("{0}", reader["pwd"]));   //pwd
                        Console.WriteLine(String.Format("{0}", reader["sex"]));   //sex
                        Console.WriteLine(String.Format("{0}", reader["born"]));   //date
                    }
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
                    Console.WriteLine("Errore!");
                }
            }

            con.Close();
            Console.WriteLine("Press [Enter] to continue: ");
            String enter = Console.ReadLine();
        }
    }
}