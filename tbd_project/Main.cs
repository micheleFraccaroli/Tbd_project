using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tbd_project;

namespace tbd_project
{
    class main
    {
        public void logo()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("████████╗██████╗ ██████╗ ");
            Console.WriteLine("╚══██╔══╝██╔══██╗██╔══██╗");
            Console.WriteLine("   ██║   ██████╔╝██║  ██║");
            Console.WriteLine("   ██║   ██╔══██╗██║  ██║");
            Console.WriteLine("   ██║   ██████╔╝██████╔╝");
            Console.WriteLine("   ╚═╝   ╚═════╝ ╚═════╝ ");
            Console.WriteLine("\n");
        }

        public static void Main(string[] args)
        {
            tbd_project.Users usr = new Users();
            tbd_project.Seed seed = new Seed();
            tbd_project.Posts pst = new Posts();
            tbd_project.DeleteUser delete = new DeleteUser();
            tbd_project.Moderate moderate = new Moderate();
            tbd_project.Notify ntf = new Notify();
            tbd_project.Messages msg = new Messages();
            tbd_project.main m = new main();

            while (true)
            {
                m.logo();

                Console.WriteLine("--- Menù ---\n");
                Console.WriteLine("1) Retrieve user\n" +
                                  "2) Retrieve posts and comments\n" +
                                  "3) Retrieve messages between users\n" +
                                  "4) Retrieve activity register\n" +
                                  "5) Moderate posts or comments\n" +
                                  "6) Delete user\n" +
                                  "7) Insert users\n");

                String choice = Console.ReadLine();
                if (choice.Equals("1"))
                {
                    usr.getUsers();
                }
                else if (choice.Equals("2"))
                {
                    pst.getPosts();
                }
                else if (choice.Equals("3"))
                {
                    msg.getMessage();
                }
                else if (choice.Equals("4"))
                {
                    ntf.getNotify();
                }
                else if (choice.Equals("5"))
                {
                    moderate.updatePC();
                }
                else if (choice.Equals("6"))
                {
                    delete.Delete();
                }
                else if (choice.Equals("7"))
                {
                    seed.Seeding();
                }
            }
        }
    }
}
