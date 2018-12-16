using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data
    {
        public User GetUser(string userId,string password)
        {
            using (PPTPEntities db = new PPTPEntities())
            {
              var user= db.Users.ToList().Find(p => p.User_Id == userId && p.Password==password);
                return user;
            }
        }
        public server GetServer(string serverName)
        {
            using (PPTPEntities db = new PPTPEntities())
            {
               var server= db.servers.ToList().Find(p => p.Server1 == serverName);
                return server;
            }
        }
        public server AddServer(server serv)
        {
            using (PPTPEntities db = new PPTPEntities())
            {
                var server = db.servers.Add(serv);
                db.SaveChanges();
                return server;
            }
        }
    }
}
