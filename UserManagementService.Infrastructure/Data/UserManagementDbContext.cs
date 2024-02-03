﻿
using Microsoft.EntityFrameworkCore;
using UserManagementService.Library.Models;

namespace UserManagementService.Infrastructure.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
