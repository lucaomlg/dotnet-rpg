using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController:ControllerBase
    {
        public static int id = 1;
        private static List<Character> Characters = new List<Character>
        {
            new Character(),
            new Character{Id = id++,Name = "Alison", Class = RpgClass.Cleric },
            new Character{Id = id++,Name = "Caikão", Class = RpgClass.Knigth },
            new Character{Id = id++, Name = "Dogão" , Class = RpgClass.Mage},
            new Character{Id = id++,Name = "Felipepi", Class = RpgClass.Assasin },
            new Character{Id = id++,Name = "Luketa", Class = RpgClass.Hunter}
        };
        
        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            return Ok(Characters);
        }

    }

}