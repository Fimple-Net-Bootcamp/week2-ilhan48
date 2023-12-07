using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete;

public class PlanetDal : EFEntityRepositoryBase<Planet, WeatherDbContext>, IPlanetDal
{
    public PlanetDetailDto GetDetails(int id)
    {
        using (WeatherDbContext context = new())
        {
            var result = from planet in context.Planets.Where(p => p.Id == id)
                         join satellite in context.Satellites
                         on planet.SatelliteId equals satellite.Id

                         select new PlanetDetailDto()
                         {
                             Id = planet.Id,
                             Name = planet.Name,
                             Weather = planet.Weather,
                             SatelliteId = satellite.Id,
                             SatelliteName = satellite.Name,
                             SatelliteWeather = satellite.Weather
                         };
            return result.SingleOrDefault();
        }
    }

    public List<PlanetDetailDto> GetDetails(Expression<Func<PlanetDetailDto, bool>> filter = null)
    {
        using(WeatherDbContext context = new())
        {
            var result = from planet in context.Planets
                         join satellite in context.Satellites
                         on planet.SatelliteId equals satellite.Id

                         select new PlanetDetailDto()
                         {
                             Id = planet.Id,
                             Name = planet.Name,
                             Weather = planet.Weather,
                             SatelliteId = satellite.Id,
                             SatelliteName = satellite.Name,
                             SatelliteWeather = satellite.Weather
                         };
            
            return filter == null ? result.ToList() : result.Where(filter).ToList();                         
        }
    }
}
