using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoice
{
    public class User
    {
        public enum userType { Manager, Finance }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public userType Type { get; set; }
        public int EmpId { get; set; }

        public static void setSession(User userData)
        {
            HttpContext.Current.Session.Add("User", userData);
        }

        public static void removeSession()
        {
            HttpContext.Current.Session.Remove("User");
        }

        public static User getCurrentUser()
        {
            return HttpContext.Current.Session["User"] != null ? (User)HttpContext.Current.Session["User"] : null;
        }
    }
}