using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tbd_project
{
    class Conn
    {
        public SqlConnection fun()
        {
            String sql = null;
            SqlConnection con = new SqlConnection(); 
            con.ConnectionString = "Data Source=DESKTOP-EE096SE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return con;
        }

        public SqlDataAdapter funA()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            return adapter;
        }
    }
}


/*
Console.WriteLine("\nQuery data example:");
Console.WriteLine("=========================================\n");

sql = "USE DB_Test;INSERT INTO dbo.TestTable (id, Name, Surname) VALUES (1, 'Michele', 'Fraccaroli')";
            
con.Open();
adapter.InsertCommand = new SqlCommand(sql, con);
adapter.InsertCommand.ExecuteNonQuery();
Console.WriteLine("\nQuery eseguita:");
*/
