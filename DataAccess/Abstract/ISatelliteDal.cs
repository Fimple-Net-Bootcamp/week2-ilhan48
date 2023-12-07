using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface ISatelliteDal : IEntityRepository<Satellite>
{

}
