using Business.Abstract;
using Business.BusinessAspect;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class SatelliteManager : ISatelliteService
{
    readonly ISatelliteDal _stalliteDal;
    public SatelliteManager(ISatelliteDal satelliteDal)
    {
        _stalliteDal = satelliteDal;
    }
    [SecuredOperation("satellite.add, Admin")]
    public IResult Add(Satellite satellite)
    {
        _stalliteDal.Add(satellite);
        return new SuccessResult();
    }

    public IResult Delete(Satellite satellite)
    {
        _stalliteDal.Delete(satellite);
        return new SuccessResult();
    }

    public IDataResult<List<Satellite>> GetAll()
    {
        var getAll = _stalliteDal.GetAll();
        return new SuccessDataResult<List<Satellite>>(getAll);
    }

    public IDataResult<Satellite> GetById(int id)
    {
        var getById = _stalliteDal.Get(satellite => satellite.Id == id);
        return new SuccessDataResult<Satellite>(getById);
    }

    public IDataResult<List<SatelliteWeatherDto>> GetDetails()
    {
        var getDetails = _stalliteDal.GetDetails();
        return new SuccessDataResult<List<SatelliteWeatherDto>>(getDetails);
    }

    public IResult Update(Satellite satellite)
    {
        _stalliteDal.Update(satellite);
        return new SuccessResult();
    }
}
