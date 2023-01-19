using Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;


namespace Portal.Models
{

    public class IdentitySeedData
    {
        private const string adminUser = "Admin@gmail.com";
        private const string adminPassword = "Secret123$";

        private const string StudentUser = "Student1@gmail.com";
        private const string StudentPassword = "Secret123$";

        private const string StudentUser2 = "Thomas@gmail.com";




        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByEmailAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminUser,
                    Email = adminUser,
                };
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddClaimAsync(user, new Claim("Employee", "true"));
            }

            IdentityUser student = await userManager.FindByIdAsync(StudentUser);
            if (student == null)
            {
                student = new IdentityUser
                {
                    UserName = StudentUser,
                    Email = StudentUser,
                };
                await userManager.CreateAsync(student, StudentPassword);
                await userManager.AddClaimAsync(student, new Claim("Student", "true"));
            }

            IdentityUser student2 = await userManager.FindByEmailAsync(StudentUser2);
            if (student2 == null)
            {
                student2 = new IdentityUser
                {
                    UserName = StudentUser2,
                    Email = StudentUser2,
                };
                await userManager.CreateAsync(student2, StudentPassword);
                await userManager.AddClaimAsync(student2, new Claim("Student", "true"));
            }




        }
    }
}
