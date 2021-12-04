using System;
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

        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _gameInfoService.GetAsync(e => e.Id == id);

            if (result is null)
            {
                return NotFound($"Record with id = \"{ id }\" not found");
            }

            return Ok(result);
        }
        
        [HttpGet("get-by-game-tag")]
        public async Task<IActionResult> GetByGameTags(GameTagType gameTag)
        {
            var result = await _gameInfoService.GetManyAsync(e => e.GameTags.Contains(gameTag.ToString()));

            if (!result.Any())
            {
                return NotFound($"Records with GameTag = \"{ gameTag }\" not found");
            }

            return Ok(result);
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameInfoService.GetAllAsync();

            if (result is null)
            {
                return BadRequest($"Database is empty");
            }

            return Ok(result);
        }

        [HttpPut("create")]
        public async Task<IActionResult> Create([FromBody] CreateGameInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            
            var result = await _gameInfoService.CreateAsync(model);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGameInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            
            var result = await _gameInfoService.UpdateAsync(model);

            if (result is null)
            {
                return NotFound($"Record with id = \"{ model.Id }\" not found");
            }
            
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _gameInfoService.DeleteAsync(id);

            return Ok(result);
        }
    }
}