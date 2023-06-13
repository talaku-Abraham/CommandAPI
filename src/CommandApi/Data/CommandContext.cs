using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandApi.Data
{
    public class CommandContext : DbContext
    {
         public CommandContext(DbContextOptions<CommandContext> options):base(options)
         {
            
         }
        //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        //   {
          
        //       var connectionString= _configuration.GetConnectionString("ConnectionString");
        //      Console.WriteLine(connectionString);
        //      optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //        base.OnConfiguring(optionsBuilder);
        // }
        public DbSet<Command> CommandItems{get;set;}
    }
}