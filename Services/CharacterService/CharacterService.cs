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
        private readonly DataContext _context;

        public CharacterService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            _context.Characters.Add(_mapper.Map<Character>(newCharacter));
            await _context.SaveChangesAsync();
            

            serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(await _context.Characters.ToListAsync());

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();

            serviceResponse.Data = dbCharacters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(x => x.Id == Id);
            
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
            var character = await _context.Characters.FindAsync(updatedCharacter.Id);

            if(character is null)
                throw new Exception($"Character with ID:'{updatedCharacter.Id}' not found.");

            character.Name = updatedCharacter.Name;
            character.HealthPoints = updatedCharacter.HealthPoints;
            character.Strength = updatedCharacter.Strength;
            character.Defence = updatedCharacter.Defence;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;

            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
            var character = await _context.Characters.FindAsync(Id);

            if(character is null)
                throw new Exception($"Character with ID:'{Id}' not found.");

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(await _context.Characters.ToListAsync());
            }
            catch(Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Sucess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}

      
