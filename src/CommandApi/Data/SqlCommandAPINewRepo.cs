using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandApi.Models;

namespace CommandApi.Data
{
    public class SqlCommandNewRepo : ICommandAPIRepo
    {
        private readonly CommandContext _Context;
        public SqlCommandNewRepo(CommandContext Context){
            _Context = Context;
        }
        void ICommandAPIRepo.CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        void ICommandAPIRepo.DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Command> ICommandAPIRepo.GetAllCommands()
        {
            return _Context.CommandItems.ToList();
        }

        Command ICommandAPIRepo.GetCommandById(int id)
        {
            return _Context.CommandItems.FirstOrDefault(P=>P.Id == id);
        }

        bool ICommandAPIRepo.SaveChanges()
        {
            throw new NotImplementedException();
        }

        void ICommandAPIRepo.UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}