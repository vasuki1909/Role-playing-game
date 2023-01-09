using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role_playing_game.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } ="Frodo";
        public int Hitpoints { get; set; }= 100;

        public int Defence { get; set; } =10;
        public int Strength { get; set; } =10;
        public int Intelligence { get; set; } =10;
        public RPGClass Aclass { get; set; } = RPGClass.Knight;
    }
}