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
            if(command == null){

            throw new ArgumentNullException(nameof(command));
            }
            _Context.CommandItems.Add(command);
        }

        void ICommandAPIRepo.DeleteCommand(Command command)
        {
            if(command==null)
            {
                throw new  ArgumentNullException(nameof(command));
            }
            // throw new NotImplementedException();
            _Context.CommandItems.Remove(command);
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
            return (_Context.SaveChanges()>=0);
        }

        void ICommandAPIRepo.UpdateCommand(Command command)
        {
            // throw new NotImplementedException();
            // _Context.CommandItems.Update(command);
        }
    }
}