using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.PlanetDtos;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IPlanetDal : IEntityRepository<Planet>
{
    List<PlanetDetailDto> GetDetails(Expression<Func<PlanetDetailDto, bool>> filter = null);
    PlanetDetailDto GetDetails(int id);
}
