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
        
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            
            characters.Add(newCharacter);

            serviceResponse.Data = characters;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();

            serviceResponse.Data = characters;
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(x=> x.Id == id);

            if(character is not null)
            {
                serviceResponse.Data = character;
                return serviceResponse;
            }

            throw new Exception("Character not Found");
        }
    }
}