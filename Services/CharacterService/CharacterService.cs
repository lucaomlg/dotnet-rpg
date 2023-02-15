using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

                public static int id = 1;

        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Id = id++,Name = "Alison", Class = RpgClass.Cleric },
            new Character{Id = id++,Name = "Caikão", Class = RpgClass.Knigth },
            new Character{Id = id++, Name = "Dogão" , Class = RpgClass.Mage},
            new Character{Id = id++,Name = "Felipepi", Class = RpgClass.Assasin },
            new Character{Id = id++,Name = "Luketa", Class = RpgClass.Hunter}
        };
        
        public List<Character> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public Character GetCharacterById(int Id)
        {
           return characters.FirstOrDefault(x=> x.Id == id);
        }
    }
}