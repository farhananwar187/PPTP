
namespace PPTPService
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string User_Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public bool Is_Active { get; set; }
    }
}
