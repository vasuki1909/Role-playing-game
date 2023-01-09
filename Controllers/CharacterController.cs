//global using Role_playing_game.Models; U can put the 'global using directives ' in program.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//note:---
//readonly - It indicates that the assignment to the fields is only the part of the declaration or in a constructor to the same class.

namespace Role_playing_game.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        
        private readonly ICharacterService characterService;

        public CharacterController(ICharacterService characterService)
        {
            this.characterService = characterService;
        }
        
        //using Get(Something actually works tho)
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters()
        {
            return Ok(await characterService.GetAllCharacters());
            //BadRequest
            //NotFound
            
        }

           [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> Get(int id)
        {

            //FirstOrDefault() =Returns the first element of a collection, or the first element that satisfies a condition. 
            //Returns a default value if index is out of range.
            return Ok(await characterService.GetCharacterByID(id));
            //BadRequest
            //NotFound
            
        }


        // Adding a new character
        //getting a json request body from the web 
       [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await characterService.UpdateCharacter(updatedCharacter);
            if(response.Data is null)
            return NotFound(response);
            else 
            return Ok(response);
        }

            [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {

            var response = await characterService.DeleteCharacter(id);
            if(response.Data is null)
            return NotFound(response);
            else 
            return Ok(response);

           
            
        }
    }
}