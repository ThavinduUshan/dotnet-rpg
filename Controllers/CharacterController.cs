
using dotnet_rpg.enums;
using dotnet_rpg.models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>{
            new Character{
            Id = 1,
            Name="Frodo",
            Strength=10,
            Defense=10,
            Intelligence=10,
            RpgClass = RpgClass.knight
        },
        new Character{
            Id = 2,
            Name="Sam",
            Strength=5,
            Defense=6,
            Intelligence=8,
            RpgClass = RpgClass.Cleric
        }
        };

        
        [HttpGet]
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id){
            return Ok(characters.FirstOrDefault<Character>(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character character){
            characters.Add(character);
            return Ok(characters);
        }
    }
}