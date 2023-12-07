using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IPlanetDal : IEntityRepository<Planet>
{
    List<PlanetDetailDto> GetPlanetsDetails(Expression<Func<PlanetDetailDto, bool>> filter = null);
    PlanetDetailDto GetPlanetDetails(int id);
}
