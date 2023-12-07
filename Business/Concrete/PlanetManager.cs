using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class PlanetManager : IPlanetService
{
    IPlanetDal _planetDal;
    public PlanetManager(IPlanetDal planetDal)
    {
        _planetDal = planetDal;
    }
    public IResult Add(Planet planet)
    {
        _planetDal.Add(planet);
        return new SuccessResult();
    }

    public IResult Delete(Planet planet)
    {
        _planetDal.Delete(planet);
        return new SuccessResult();
    }

    public IResult Update(Planet planet)
    {
        _planetDal.Update(planet);
        return new SuccessResult();
    }

    public IDataResult<List<Planet>> GetAll()
    {
        return new SuccessDataResult<List<Planet>>(_planetDal.GetAll());
    }

    public IDataResult<Planet> GetById(int id)
    {
        return new SuccessDataResult<Planet>(_planetDal.Get(p => p.Id == id));
    }

    public IDataResult<PlanetDetailDto> GetPlanetDetails(int id)
    {
        return new SuccessDataResult<PlanetDetailDto>(_planetDal.GetPlanetDetails(id));
    }

    public IDataResult<List<PlanetDetailDto>> GetPlanetsDetails()
    {
        return new SuccessDataResult<List<PlanetDetailDto>>(_planetDal.GetPlanetsDetails());
    }
}
