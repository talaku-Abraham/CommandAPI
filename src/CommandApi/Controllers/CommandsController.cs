// using System;
using System.Collections.Generic;
using CommandApi.Data;
using CommandApi.Models;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        public CommandsController(ICommandAPIRepo repository){
            _repository = repository;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands(){
            var commandItems= _repository.GetAllCommands();
            return  Ok(commandItems);
        
            // new String[]{"this", "is","hard", "coded"};
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem ==null){
                return NotFound();
            }
            return Ok(commandItem);
        }
    }
}