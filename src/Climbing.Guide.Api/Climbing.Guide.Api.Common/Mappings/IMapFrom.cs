using AutoMapper;

namespace Climbing.Guide.Api.Common.Mappings {
   public interface IMapFrom<T> {
      void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
   }
}
