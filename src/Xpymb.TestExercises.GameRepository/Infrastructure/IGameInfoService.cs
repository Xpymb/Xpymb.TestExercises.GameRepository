using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xpymb.TestExercises.GameRepository.Data.Entities;
using Xpymb.TestExercises.GameRepository.Models;

namespace Xpymb.TestExercises.GameRepository.Infrastuture
{
    public interface IGameInfoService
    {
        Task<GameInfoModel> GetAsync(Expression<Func<GameInfoEntity, bool>> selector);
        Task<IEnumerable<GameInfoModel>> GetManyAsync(Expression<Func<GameInfoEntity, bool>> selector);
        Task<IEnumerable<GameInfoModel>> GetAllAsync();
        Task<GameInfoModel> CreateAsync(CreateGameInfoModel model);
        Task<GameInfoModel> UpdateAsync(UpdateGameInfoModel model);
        Task<GameInfoModel> DeleteAsync(Guid id);
    }
}