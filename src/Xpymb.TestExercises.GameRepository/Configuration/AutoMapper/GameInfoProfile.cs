using AutoMapper;
using Xpymb.TestExercises.GameRepository.Data.Entities;
using Xpymb.TestExercises.GameRepository.Models;

namespace Xpymb.TestExercises.GameRepository.Configuration.AutoMapper
{
    public class GameInfoProfile : Profile
    {
        public GameInfoProfile()
        {
            CreateMap<GameInfoEntity, GameInfoModel>()
                .ForMember(
                    dest => dest.GameTags, 
                    opt => opt.MapFrom(src => src.GameTags.ToEnumCollection<GameTagType>()));
            CreateMap<GameInfoModel, GameInfoEntity>()
                .ForMember(
                    dest => dest.GameTags, 
                    opt => opt.MapFrom(src => src.GameTags.EnumCollectionToString()));
            
            CreateMap<CreateGameInfoModel, GameInfoModel>();
            CreateMap<CreateGameInfoModel, GameInfoEntity>()
                .ForMember(
                    dest => dest.GameTags, 
                    opt => opt.MapFrom(src => src.GameTags.EnumCollectionToString()));
            
            CreateMap<UpdateGameInfoModel, GameInfoModel>();
            CreateMap<UpdateGameInfoModel, GameInfoEntity>()
                .ForMember(
                    dest => dest.GameTags,
                    opt => opt.MapFrom(src => src.GameTags.EnumCollectionToString()));
        }
    }
}