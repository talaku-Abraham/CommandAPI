// using System;
using System.Collections.Generic;
using CommandApi.Data;
using CommandApi.Models;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CommandApi.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace CommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommandAPIRepo repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands(){
            var commandItems= _repository.GetAllCommands();
            return  Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        
            // new String[]{"this", "is","hard", "coded"};
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem ==null){
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
        //  [HttpGet("{id}", Name="Get")]
        // public ActionResult<String> Get(){
            // return Ok("Talex");
        // }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateNewCommand(CommandCreateDto commandCreateDto){
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new {id =commandReadDto.Id}, commandReadDto);

        }
        
        [HttpPut("{id}")]
        public ActionResult<CommandUpdateDto> UpdateCommand(int id ,CommandUpdateDto commandUpdateDto)
        {         
            var commandModelFromRepo = _repository.GetCommandById(id);  
            
            if(commandModelFromRepo==null){
                  return NotFound();  
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
            
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> PatchDoc){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo ==null){
                return NotFound();
            }
            var commnadToPatch=_mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            PatchDoc.ApplyTo(commnadToPatch,ModelState);
            if(!TryValidateModel(commnadToPatch)){
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commnadToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id){
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
       
    }
}