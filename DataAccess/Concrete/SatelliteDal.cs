using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete;

public class SatelliteDal : EFEntityRepositoryBase<Satellite, WeatherDbContext>, ISatelliteDal
{

    public List<SatelliteWeatherDto> GetDetails(Expression<Func<SatelliteWeatherDto, bool>> filter = null)
    {
        throw new NotImplementedException();
    }
}

