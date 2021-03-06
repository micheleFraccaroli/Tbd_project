﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using tbd_project;

namespace tbd_project
{
    class DeleteUser
    {
        public void Delete()
        {
            String query = null;
            //Console.Clear();
            Console.WriteLine("--- Deleting user ---");

            Console.WriteLine("delete from:\n1)ID\n2)Name");
            String choice = Console.ReadLine();

            if (choice.Equals('1'))
            {
                query = "USE DB_Test;DELETE FROM dbo.users WHERE id = " + Int32.Parse(choice);
            }
            else
            {
                Console.WriteLine("Name: ");
                String name = Console.ReadLine();
                Console.WriteLine("Surname: ");
                String surname = Console.ReadLine();

                query = "USE DB_Test;DELETE FROM dbo.users WHERE name = '" + name + "' AND surname = '" + surname + "'";
            }

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
            Console.WriteLine("User and his posts deleted!");
            Console.WriteLine("Press [Enter] to continue: ");
            String enter = Console.ReadLine();
        }
    }
}
