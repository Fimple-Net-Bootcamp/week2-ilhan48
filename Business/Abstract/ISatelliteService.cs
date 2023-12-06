using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ISatelliteService
{
    IDataResult<List<Satellite>> GetAll();
    IDataResult<Satellite> GetById(int id);
    IDataResult<List<SatelliteWeatherDto>> GetDetails();
    IResult Add(Satellite satellite);
    IResult Update(Satellite satellite);
    IResult Delete(Satellite satellite);
}
