using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.SatelliteDtos;

namespace Business.Abstract;

public interface ISatelliteService
{
    IDataResult<List<Satellite>> GetAll(string filterParam, string sortOrder, int page, int size);
    IDataResult<Satellite> GetById(int id);
    IResult Add(SatelliteAddDto satelliteAddDto);
    IResult Update(Satellite satellite);
    IResult Delete(SatelliteDeleteDto satelliteDeleteDto);
    IResult EditSatellite(SatelliteDetailDto satellite);
}
