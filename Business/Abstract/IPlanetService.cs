using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.PlanetDtos;

namespace Business.Abstract;

public interface IPlanetService 
{
    IResult Add(PlanetAddDto planet);
    IResult Delete(PlanetDeleteDto planet);
    IResult Update(Planet planet);
    IDataResult<List<Planet>> GetAll(string filterParam, string sortOrder);
    IDataResult<Planet> GetById(int id);
    IDataResult<PlanetDetailDto> GetPlanetDetails(int id);
    IDataResult<List<PlanetDetailDto>> GetPlanetsDetails();
    IResult EditPlanet(PlanetDetailDto planet);
}
