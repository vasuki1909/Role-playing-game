using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Role_playing_game.Dtos.Character;

namespace Role_playing_game.Services.CharacterService
{
    public interface ICharacterService
    {
       Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
       Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

        //we dont have to send a list right we can just send back the updated character
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);

         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}