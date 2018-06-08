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
            tbd_project.DeleteUser delete = new DeleteUser();
            tbd_project.Moderate moderate = new Moderate();
            tbd_project.Messages msg = new Messages();

            //usr.getUsers();
            //seed.Seeding();
            //pst.getPosts();
            //delete.Delete();
            //moderate.updatePC();
            msg.getMessage();
        }

        public void Menu()
        {
            //menu
        }
    }
}
