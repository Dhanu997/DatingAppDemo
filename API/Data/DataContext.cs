using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// public class DataContext : DbContext
// {
//     public DataContext(DbContextOptions options) : base(options)
//     {
//     }

//     protected DataContext()
//     {
//     }
// }
public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}