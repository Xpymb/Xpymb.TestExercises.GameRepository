using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xpymb.TestExercises.GameRepository.Infrastuture;
using Xpymb.TestExercises.GameRepository.Models;

namespace Xpymb.TestExercises.GameRepository.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameInfoController : ControllerBase
    {
        private readonly IGameInfoService _gameInfoService;

        public GameInfoController(
            IGameInfoService gameInfoService)
        {
            _gameInfoService = gameInfoService;
        }

        [HttpGet("gameinfo/{id:guid}")]
        public async Task<IActionResult> Get([Required][FromQuery] Guid id)
        {
            var result = await _gameInfoService.GetAsync(e => e.Id == id);

            if (result is null)
            {
                return NotFound($"Record with id = \"{ id }\" not found");
            }

            return Ok(result);
        }
        
        [HttpGet("gameinfo/gametag/{gameTag}")]
        public async Task<IActionResult> GetByGameTags([Required][FromQuery] GameTagType gameTag)
        {
            var result = await _gameInfoService.GetManyAsync(e => e.GameTags.Contains(gameTag.ToString()));

            if (!result.Any())
            {
                return NotFound($"Records with GameTag = \"{ gameTag }\" not found");
            }

            return Ok(result);
        }
        
        [HttpGet("gameinfo")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameInfoService.GetAllAsync();

            if (result is null)
            {
                return BadRequest($"Database is empty");
            }

            return Ok(result);
        }

        [HttpPost("gameinfo")]
        public async Task<IActionResult> Create([FromBody] CreateGameInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            
            var result = await _gameInfoService.CreateAsync(model);

            return CreatedAtRoute(new { id = result.Id }, result);
        }

        [HttpPut("gameinfo")]
        public async Task<IActionResult> Update([FromBody] UpdateGameInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            if (model.Id == Guid.Empty)
            {
                ModelState.AddModelError("Id", "Must not be null");
                return ValidationProblem();
            }
            
            var result = await _gameInfoService.UpdateAsync(model);

            if (result is null)
            {
                return NotFound($"Record with id = \"{ model.Id }\" not found");
            }
            
            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            var result = await _gameInfoService.DeleteAsync(id);

            if (result is null)
            {
                return NotFound($"Record with id = \"{ id }\" not found");
            }
            
            return NoContent();
        }
    }
}