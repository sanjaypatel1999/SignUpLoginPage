using Microsoft.EntityFrameworkCore;
using SignupLogin.Models.Account;
using System;

namespace SignupLogin.Data
{
    public class ApplicationdbContext:DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
