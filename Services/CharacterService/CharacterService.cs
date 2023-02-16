global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    { 
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

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

       
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(x => x.Id)+1;
            
            characters.Add(character);

            serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            var character = characters.FirstOrDefault(x => x.Id == Id);
            
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(x => x.Id == updatedCharacter.Id);
            
            character.Name = updatedCharacter.Name;
            character.HealthPoints = updatedCharacter.HealthPoints;
            character.Strength = updatedCharacter.Strength;
            character.Defence = updatedCharacter.Defence;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            return serviceResponse;
        }
    }
}

      
