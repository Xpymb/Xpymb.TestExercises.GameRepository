using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Xpymb.TestExercises.GameRepository.Models
{
    public class UpdateGameInfoModel
    {
        [Required] public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string GameStudio { get; set; }
        
        public IEnumerable<GameTagType> GameTags { get; set; }
        
        public bool? IsActive { get; set; }
    }
}