using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role_playing_game
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //source , destination
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
           // CreateMap<UpdateCharacterDto,Character>();
        }
    }
}