﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TicketSeller.DAL.Data;

public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    private readonly IConfiguration _config;

    public UserDbContext(DbContextOptions<UserDbContext> opt, IConfiguration config) : base(opt)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        IdentityUser<int> admin = new IdentityUser<int>
        {
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            Id = 99999
        };

        PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

        admin.PasswordHash = hasher.HashPassword(admin, _config.GetValue<string>("admininfo:password"));

        builder.Entity<IdentityUser<int>>().HasData(admin);

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 99999,
                Name = "admin",
                NormalizedName = "ADMIN"
            }
        );

        builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>
            {
                Id = 99998,
                Name = "client",
                NormalizedName = "CLIENT"
            }
        );

        builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>
            {
                RoleId = 99999,
                UserId = 99999
            }
        );
    }
}
