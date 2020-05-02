using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ZNOSchool.Models
{
    public class AppDbInitializer: DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region Manager
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            #endregion
            #region Roles Creation
            var roleAdmin = new IdentityRole { Name = "admin" };
            var roleTeacher = new IdentityRole { Name = "teacher" };
            var roleStudent = new IdentityRole { Name = "student" };
            var roleParent = new IdentityRole { Name = "parent" };
            roleManager.Create(roleAdmin);
            roleManager.Create(roleTeacher);
            roleManager.Create(roleStudent);
            roleManager.Create(roleParent);
            #endregion
            #region User Creator
            //var admin = new ApplicationUser { Email = "nastyona@gmail.com", UserName = "Anastasia" };
            //string passwordAdmin = "ZNO_School0123456";
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            string password = "ad46D_ewr3";
            var resultAdmin = userManager.Create(admin, password);
            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
      //          userManager.AddToRole(admin.Id, roleTeacher.Name);
            }
            
            #endregion

            base.Seed(context);
        }
    }
}