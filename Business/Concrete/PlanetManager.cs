using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs.PlanetDtos;
using System.Numerics;

namespace Business.Concrete;

public class PlanetManager : IPlanetService
{
    IPlanetDal _planetDal;
    public PlanetManager(IPlanetDal planetDal)
    { 
        _planetDal = planetDal;
    }
    public IResult Add(PlanetAddDto planet)
    {
        var planetToAdd = new Planet
        {
            Id = 0, // Database iterate automatic so I pass default value
            Name = planet.Name,
            SatelliteId = planet.SatelliteId,
            Weather = planet.Weather,
            
        };
        _planetDal.Add(planetToAdd);
        return new SuccessResult();
    }

    public IResult Delete(PlanetDeleteDto planetDeleteDto)
    {
        var selectedPlanet = _planetDal.Get(p => p.Id == planetDeleteDto.Id);
        if (selectedPlanet != null)
        {
            _planetDal.Delete(selectedPlanet);
            return new SuccessResult();
        }
        else { return new ErrorResult(); }
       
    }

    public IResult Update(Planet planet)
    {
        _planetDal.Update(planet);
        return new SuccessResult();
    }

    public IResult EditPlanet(PlanetDetailDto planet)
    {
        var planetInfo = new Planet()
        {
            Id = planet.Id,
            Name = planet.Name,
            Weather = planet.Weather,
            SatelliteId = planet.SatelliteId,
        };

        _planetDal.Update(planetInfo);
        return new SuccessResult();
    }

    public IDataResult<List<Planet>> GetAll(string filterParam, string sortOrder)
    {
        var planets = _planetDal.GetAll();

        if (!string.IsNullOrEmpty(filterParam))
        {
            planets = planets.Where(item => item.Name.Equals(filterParam, StringComparison.OrdinalIgnoreCase)).ToList();
            if (planets.Count == 0)
            {
                return new ErrorDataResult<List<Planet>>(Messages.NoMatchingContent);
            }
            else
            {
                if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
                {
                    planets = planets.OrderBy(item => item.Name).ToList();
                }
                else if (sortOrder.ToLower() == "desc")
                {
                    planets = planets.OrderByDescending(item => item.Name).ToList();
                }
                else
                {
                    planets = planets.OrderBy(item => item.Name).ToList();
                }

                return new SuccessDataResult<List<Planet>>(planets);
            }
            
        }

        return new ErrorDataResult<List<Planet>>(Messages.NullValue);

    }

    //public IDataResult<List<Planet>> GetAll()
    //{
    //    return new SuccessDataResult<List<Planet>>(_planetDal.GetAll());
    //}

    public IDataResult<Planet> GetById(int id)
    {
        return new SuccessDataResult<Planet>(_planetDal.Get(p => p.Id == id));
    }

    public IDataResult<PlanetDetailDto> GetPlanetDetails(int id)
    {
        return new SuccessDataResult<PlanetDetailDto>(_planetDal.GetDetails(id));
    }

    public IDataResult<List<PlanetDetailDto>> GetPlanetsDetails()
    {
        return new SuccessDataResult<List<PlanetDetailDto>>(_planetDal.GetDetails());
    }
}
