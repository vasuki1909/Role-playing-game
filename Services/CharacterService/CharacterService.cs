using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Role_playing_game.Services.CharacterService
{
    public class CharacterService : ICharacterService

    {
        //Examples
        // var students = new List<Student>() { 
        //         new Student(){ Id = 1, Name="Bill"},
        //         new Student(){ Id = 2, Name="Steve"},
        //         new Student(){ Id = 3, Name="Ram"},
        //         new Student(){ Id = 4, Name="Abdul"}
        //     };

        private readonly DataContext context;
        private readonly IMapper mapper;

        // we need to add a constructer here to use an object of auto mapper
        public CharacterService(IMapper mapper, DataContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }
         private static List<Character> characters = new List<Character> {
            new Character(),
            new Character() {Id = 1,Name = " Vasuki"} 
        };
        

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)

        {
            // we are creating a new service response object in every method and returning the list of character ie we can return any data type
           var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
           // here mapping is opposite mapping a addcaharacterdto to model Character

           var character = mapper.Map<Character> (newCharacter);
          // character.Id = characters.Max(c => c.Id)+1; no need to add sql server do it for us
            context.Characters.Add(character); // the newCharacter -== inserting it in edit state so it starts tracking the new character
           await context.SaveChangesAsync();
           serviceResponse.Data=  characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList ();
          
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            //get characters from database
            var dbCharacter = await context.Characters.ToListAsync();
           serviceResponse.Data= dbCharacter.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
          
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int id)

        {

            var serviceResponse = new ServiceResponse<GetCharacterDto>();
           // var character =characters.FirstOrDefault(c => c.Id == id);
           var dbcharacter =await context.Characters.FirstOrDefaultAsync(c => c.Id == id);
           serviceResponse.Data= mapper.Map<GetCharacterDto> (dbcharacter);// Mappings model with dto here
          
            return serviceResponse;
            
            // if(character is not null)
            //  return character;

            //  throw new Exception("Character not found");
            // now since we are using service response we dont need to 
            //take care of exception of being null of niot finding the id as service response can take care of the error messgaese
           
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {

            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try{
             var character =characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

             if(character is null)
             throw new Exception($"Charater with id '{updatedCharacter.Id}' not found");

             //mapper.Map<Character>(updatedCharacter);
            // mapper.Map(updatedCharacter,character)

             character.Hitpoints = updatedCharacter.Hitpoints;
             character.Name = updatedCharacter.Name;
             character.Defence = updatedCharacter.Defence;
             character.Strength = updatedCharacter.Strength;
             character.Intelligence = updatedCharacter.Intelligence;
             character.Aclass = updatedCharacter.Aclass;
             serviceResponse.Data= mapper.Map<GetCharacterDto> (character);

            }
            catch(Exception e)
            {
                serviceResponse.Success= false;
                serviceResponse.Message= e.Message;
            }
            
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
             var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{
             var character =characters.FirstOrDefault(c => c.Id == id);

             if(character is null)
             throw new Exception($"Charater with id '{id}' not found");

                characters.Remove(character);
                serviceResponse.Data= characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();



            }
            catch(Exception e)
            {
                serviceResponse.Success= false;
                serviceResponse.Message= e.Message;
            }
            
            return serviceResponse;
            
    }
}
}

