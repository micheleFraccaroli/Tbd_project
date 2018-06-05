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
        static void Main(string[] args)
        {
            tbd_project.Users usr = new Users();
            tbd_project.Seed seed = new Seed();
            tbd_project.Posts pst = new Posts();

            //usr.getUsers();
            //seed.Seeding();
            pst.getPosts();            
        }

        public void Menu()
        {
            //menu
        }
    }
}
