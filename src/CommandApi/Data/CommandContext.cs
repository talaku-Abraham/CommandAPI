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
        public CommandContext(DbContextOptions<CommandContext > options):base(options)
        {

        }
        public DbSet<Command> CommandItems{get;set;}
    }
}