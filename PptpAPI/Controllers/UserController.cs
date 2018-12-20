using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
namespace PptpAPI.Controllers
{
    public class UserController : ApiController
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
        public User GetUser()
        {
            using (PPTPEntities db = new PPTPEntities())
            {
                var res = db.Users.ToList().FirstOrDefault();
                return res;
            }
        }
        //public User GetUser([FromBody] User user)
        //{
        //    using (PPTPEntities db = new PPTPEntities())
        //    {
        //        var res = db.Users.ToList().Find(p => p.User_Id == user.User_Id && p.Password == user.Password);
        //        return res;
        //    }
        //}

        // POST: api/Pptp
        public void Post([FromBody]string value)
        {
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
