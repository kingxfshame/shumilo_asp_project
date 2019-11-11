﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using shumilo_asp_project.Models;

namespace shumilo_asp_project.Controllers
{
    public class UserController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();
        
        public string Post(RegisterUser registerUser)
        {
            string result = "";
            if (registerUser.password != registerUser.password_second) result= "Passwords do not match";
            else if (db.Users.Where(x => x.login == registerUser.email).FirstOrDefault() != null) result = "This user already exists";
            else
            {
                HttpContext.Current.Session["email"] = registerUser.email;

                string password = registerUser.password;
                result = "Success";
                User user = new User();
                user.login = registerUser.email;
                user.password = Hash.ComputeSha256Hash(password);
                user.roleID = 1;
                db.Users.Add(user);
                db.SaveChanges();

            }
            return result;
        }
    }
}
