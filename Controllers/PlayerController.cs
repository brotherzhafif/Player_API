using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Player_API.Models;

namespace Player_API.Controllers
{

    [ApiController]
    public class PlayerController : Controller
    {
        // Endpoint Start

        private static readonly List<Player> _players = new List<Player>
        {
            new Player { Id = 1, Name = "Cristiano Ronaldo", Age = 38, BirthPlace = "Europe" },
            new Player { Id = 2, Name = "Lionel Messi", Age = 36, BirthPlace = "South America" },
            new Player { Id = 3, Name = "Karim Benzema", Age = 35, BirthPlace = "Europe" },
            new Player { Id = 4, Name = "Erling Haaland", Age = 23, BirthPlace = "Europe" },
            new Player { Id = 5, Name = "Kylian Mbappe", Age = 24, BirthPlace = "Europe" }
        };

        [HttpGet]
        [Route("GetAllPlayers")]
        public IActionResult GetPlayers()
        {
            return Ok(_players);
        }

        [HttpGet]
        [Route("GetPlayerByBirthPlace")]
        public IActionResult GetPlayers(string birthPlace)
        {
            IEnumerable<Player> filteredPlayers = _players;

            if (!string.IsNullOrEmpty(birthPlace))
            {
                filteredPlayers = _players.Where(p => p.BirthPlace.Equals(birthPlace, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(filteredPlayers);
        }

        [HttpGet]
        [Route("GetPlayerById")]
        public IActionResult GetPlayerById(int id)
        {
            var player = _players.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        [Route("PostPlayer")]
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest("Player data is null");
            }

            // Assign new ID
            player.Id = _players.Count + 1;

            // Add player to the list
            _players.Add(player);

            return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
        }
    }
}
