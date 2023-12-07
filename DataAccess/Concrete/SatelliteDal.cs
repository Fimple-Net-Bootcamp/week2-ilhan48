using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete;

public class SatelliteDal : EFEntityRepositoryBase<Satellite, WeatherDbContext>, ISatelliteDal
{

}

