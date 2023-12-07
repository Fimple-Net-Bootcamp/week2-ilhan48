using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IPlanetService 
{
    IResult Add(Planet planet);
    IResult Delete(Planet planet);
    IResult Update(Planet planet);
    IDataResult<List<Planet>> GetAll();
    IDataResult<Planet> GetById(int id);
    IDataResult<PlanetDetailDto> GetPlanetDetails(int id);
    IDataResult<List<PlanetDetailDto>> GetPlanetsDetails();
}
