
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.enums;
using dotnet_rpg.models;
using dotnet_rpg.Services.CharacterService;
using dotnet_rpg.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
           _characterService = characterService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){

            return Ok( await _characterService.GetCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto character){
            return Ok(await _characterService.AddCharacter(character));
        }
    }
}