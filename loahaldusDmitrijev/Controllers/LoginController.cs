using shumilo_asp_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace shumilo_asp_project.Controllers
{
    public class LoginController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();
        public string Post(LoginUser user)
        {
            string result = "";
            if (user.password == null) result = "Password field are null";
            else if (user.email == null) result = "Email field are null";
            else
            {
                if((db.Users.Where(x => x.login == user.email).FirstOrDefault() != null)){
                    string password = user.password;
                    password = Hash.ComputeSha256Hash(password);
                    if ((db.Users.Where(x => x.login == user.email).FirstOrDefault().password == password))
                    {
                        HttpContext.Current.Session["email"] = user.email;
                        
                        result = "Success";
                    }
                }
                else
                {
                    result = "Invalid Password or Email";
                }
            }
            return result;
        }
    }
}
