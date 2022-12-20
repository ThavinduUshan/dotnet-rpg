using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.enums;
using dotnet_rpg.models;
using dotnet_rpg.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {

            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var newCharacter = _mapper.Map<Character>(character);
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                var UpdateCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == character.Id);

                if (UpdateCharacter is null)
                {
                    throw new Exception($"The character which has id of {character.Id} is not found");
                }

                UpdateCharacter.Name = character.Name;
                UpdateCharacter.Defense = character.Defense;
                UpdateCharacter.Strength = character.Strength;
                UpdateCharacter.Intelligence = character.Intelligence;
                UpdateCharacter.RpgClass = character.RpgClass;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(UpdateCharacter);

                return serviceResponse;
            }

            catch (Exception Ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = Ex.Message;

                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();


            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

                if (character is null)
                {
                    throw new Exception($"The character which has id of {id} is not found");
                }

                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();

                return serviceResponse;
            }

            catch (Exception Ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = Ex.Message;

                return serviceResponse;
            }
        }
    }
}