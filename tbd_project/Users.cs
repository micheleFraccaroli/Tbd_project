﻿using System;
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
            tbd_project.main m = new main();
            m.logo();
            Console.WriteLine("--- View user into system ---");

            Console.WriteLine("Name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if(check.Equals("Y") || check.Equals("y"))
            {
                Commit(name);
                return;
            }
            Console.WriteLine("Surname: ");
            String surname = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
            {
                Commit(name, surname);
                return;
            }
            Console.WriteLine("Email: ");
            String email = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
            {
                Commit(name, surname, email);
                return;
            }
            Console.WriteLine("Date: ");
            String date = Console.ReadLine();
            Console.WriteLine("Procedo?[Yes/no]");
            check = Console.ReadLine();
            if (check.Equals("Y") || check.Equals("y"))
            {
                Commit(name, surname, email, date);
                return;
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