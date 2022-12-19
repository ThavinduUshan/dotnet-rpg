
using dotnet_rpg.enums;
using dotnet_rpg.models;
using dotnet_rpg.Services.CharacterService;
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
        public ActionResult<List<Character>> Get(){
            return Ok(_characterService.GetCharacters());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character character){
            return Ok(_characterService.AddCharacter(character));
        }
    }
}