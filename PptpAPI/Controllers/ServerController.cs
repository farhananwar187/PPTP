using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
namespace PptpAPI.Controllers
{
    public class ServerController : ApiController
    {
        // GET: api/Pptp
        //public List<User> GetUsers()
        //{
        //    using (PPTPEntities db = new PPTPEntities())
        //    {
        //        var res = db.Users.ToList();
        //        return res;
        //    }
        //}

        //GET: api/Pptp/5
        public server GetServer([FromBody] server srv)
        {
            using (PPTPEntities db = new PPTPEntities())
            {
                var res = db.servers.ToList().Find(p => p.Server1 == srv.Server1);
                return res;
            }
        }

        // POST: api/Pptp
        public string PostServer([FromBody]server srv)
        {
            using (PPTPEntities db = new PPTPEntities())
            {
                db.servers.Add(srv);
                db.SaveChanges();
                return "Server Saved Successfully";
            }
        }

        // PUT: api/Pptp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pptp/5
        public void Delete(int id)
        {
        }
    }
}
