using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Data.SqlClient;

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

    public IDataResult<List<Satellite>> GetAll(string filterParam, string sortOrder)
    {
        var satellites = _stalliteDal.GetAll();

        if (!string.IsNullOrEmpty(filterParam))
        {
            satellites = satellites.Where(item => item.Name.Equals(filterParam, StringComparison.OrdinalIgnoreCase)).ToList();
            if (satellites.Count == 0)
            {
                return new ErrorDataResult<List<Satellite>>(Messages.NoMatchingContent);
            }
            else
            {
                if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
                {
                    satellites = satellites.OrderBy(item => item.Name).ToList();
                }
                else if (sortOrder.ToLower() == "desc")
                {
                    satellites = satellites.OrderByDescending(item => item.Name).ToList();
                }
                else
                {
                    satellites = satellites.OrderBy(item => item.Name).ToList();
                }

                return new SuccessDataResult<List<Satellite>>(satellites);
            }

        }

        return new ErrorDataResult<List<Satellite>>(Messages.NullValue);
    }

    public IDataResult<Satellite> GetById(int id)
    {
        var getById = _stalliteDal.Get(satellite => satellite.Id == id);
        return new SuccessDataResult<Satellite>(getById);
    }


    public IResult Update(Satellite satellite)
    {
        _stalliteDal.Update(satellite);
        return new SuccessResult();
    }

    public IResult EditSatellite(SatelliteDetailDto satellite)
    {
        var satelliteInfo = new Satellite()
        {
            Id = satellite.Id,
            Name = satellite.Name,
            Weather = satellite.Weather

            
        };

        _stalliteDal.Update(satelliteInfo);
        return new SuccessResult();
    }
}
