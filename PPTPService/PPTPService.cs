using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace PPTPService
{
    class PPTPService
    {
        Data db;
        public PPTPService()
        {
            db = new Data();
        }

        public User GetUser(string userId,string userName)
        {
            var user= db.GetUser(userId, userName);

            return user;
        }
        public server GetServer(string serverName)
        {
            var server = db.GetServer(serverName);

            return server;
        }
        public server AddServer(server serv)
        {
            var server = db.AddServer(serv);

            return server;
        }
    }
}
