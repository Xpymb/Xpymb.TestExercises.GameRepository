using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xpymb.TestExercises.GameRepository.Models
{
    public class CreateGameInfoModel
    {
        [Required] public string Name { get; set; }
        [Required] public string GameStudio { get; set; }
       
        [Required] public IEnumerable<GameTagType> GameTags { get; set; }
    }
}