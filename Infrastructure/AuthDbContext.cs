using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure
{
    public class AuthDbContext : IdentityDbContext
    {

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
    }
}
