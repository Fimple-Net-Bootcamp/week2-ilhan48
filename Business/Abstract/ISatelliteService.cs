using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ISatelliteService
{
    IDataResult<List<Satellite>> GetAll(string filterParam, string sortOrder);
    IDataResult<Satellite> GetById(int id);
    IResult Add(Satellite satellite);
    IResult Update(Satellite satellite);
    IResult Delete(Satellite satellite);
    IResult EditSatellite(SatelliteDetailDto satellite);
}
