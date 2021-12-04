using System;
using System.Collections.Generic;

namespace Xpymb.TestExercises.GameRepository.Models
{
    public class GameInfoModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string GameStudio { get; set; }
        
        public IEnumerable<GameTagType> GameTags { get; set; }
    }
}