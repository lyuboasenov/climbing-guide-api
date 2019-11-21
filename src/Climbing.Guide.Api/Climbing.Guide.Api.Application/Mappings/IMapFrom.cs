using AutoMapper;

namespace Climbing.Guide.Api.Application.Mappings {
   public interface IMapFrom<T> {
      void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
   }
}
