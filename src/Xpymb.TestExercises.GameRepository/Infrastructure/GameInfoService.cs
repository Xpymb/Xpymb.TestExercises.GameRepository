using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xpymb.TestExercises.GameRepository.Configuration.AutoMapper;
using Xpymb.TestExercises.GameRepository.Data;
using Xpymb.TestExercises.GameRepository.Data.Entities;
using Xpymb.TestExercises.GameRepository.Infrastuture;
using Xpymb.TestExercises.GameRepository.Models;

namespace Xpymb.TestExercises.GameRepository.Infrastructure
{
    public class GameInfoService : IGameInfoService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public GameInfoService(
            IDbRepository dbRepository,
            IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }
        
        public async Task<GameInfoModel> GetAsync(Expression<Func<GameInfoEntity, bool>> selector)
        {
            var entity = await Task.Run(() => 
                _dbRepository.Get(selector).AsNoTracking().FirstOrDefaultAsync());

            var model = _mapper.Map<GameInfoModel>(entity);
            
            return model;
        }
        
        public async Task<IEnumerable<GameInfoModel>> GetManyAsync(Expression<Func<GameInfoEntity, bool>> selector)
        {
            var entities = await Task.Run(() => 
                _dbRepository.Get(selector).AsNoTracking());

            var models = entities.Select(e => _mapper.Map<GameInfoModel>(e));
            
            return models;
        }

        public async Task<IEnumerable<GameInfoModel>> GetAllAsync()
        {
            var entities = await Task.Run(() => _dbRepository.GetAll<GameInfoEntity>());

            var models = _mapper.Map<IEnumerable<GameInfoModel>>(entities);
            
            return models;
        }

        public async Task<GameInfoModel> CreateAsync(CreateGameInfoModel model)
        {
            var entity = _mapper.Map<GameInfoEntity>(model);
            
            entity.DateCreated = DateTime.Now;

            var result = await _dbRepository.AddAsync(entity);

            await _dbRepository.SaveChangesAsync();
            
            var resultModel = _mapper.Map<GameInfoModel>(result);
            return resultModel;
        }

        public async Task<GameInfoModel> UpdateAsync(UpdateGameInfoModel model)
        {
            var baseModel = _mapper.Map<GameInfoModel>(model);
            
            var entity = await Task.Run(() =>
                    _dbRepository.Get<GameInfoEntity>(entity => entity.Id == model.Id).AsNoTracking().FirstOrDefaultAsync());

            if (entity is null)
            {
                return null;
            }
            
            entity.Name = baseModel.Name ?? entity.Name;
            entity.GameStudio = baseModel.GameStudio ?? entity.GameStudio;
            entity.GameTags = baseModel.GameTags.Any() ? baseModel.GameTags.EnumCollectionToString() : entity.GameTags;
            entity.IsActive = model.IsActive ?? entity.IsActive;
            entity.DateUpdated = DateTime.Now;
           
            var result = await _dbRepository.UpdateAsync(entity);
            
            await _dbRepository.SaveChangesAsync();

            var resultModel = _mapper.Map<GameInfoModel>(result);
            return resultModel;
        }

        public async Task<GameInfoModel> DeleteAsync(Guid id)
        {
            var entity = await _dbRepository.DeleteAsync<GameInfoEntity>(id);

            if (entity is null)
            {
                return null;
            }

            await _dbRepository.SaveChangesAsync();
            
            var model = _mapper.Map<GameInfoModel>(entity);
            return model;
        }
    }
}