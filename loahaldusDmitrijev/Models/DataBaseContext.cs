using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shumilo_asp_project.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public DataBaseContext() : base("DbContext")
        {
            if (!Database.Exists())
                Database.Create();

            Users.Add(new User()
            {
                login = "artur.kexpa@gmail.com",
                password = Hash.ComputeSha256Hash("admin"),
                roleID = 2,
            });

            SaveChanges();
        }
    }
}