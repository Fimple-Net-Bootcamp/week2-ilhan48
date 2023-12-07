using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs.SatelliteDtos;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Numerics;

namespace Business.Concrete;

public class SatelliteManager : ISatelliteService
{
    readonly ISatelliteDal _satelliteDal;
    public SatelliteManager(ISatelliteDal satelliteDal)
    {
        _satelliteDal = satelliteDal;
    }
    [SecuredOperation("Admin")]
    public IResult Add(SatelliteAddDto satelliteAddDto)
    {
        var satelliteToAdd = new Satellite
        {
            Id = 0, // Database iterate automatic so I pass default value
            Name = satelliteAddDto.Name

        };
        _satelliteDal.Add(satelliteToAdd);
        return new SuccessResult();
    }
    [SecuredOperation("Admin")]
    public IResult Delete(SatelliteDeleteDto satelliteDeleteDto)
    {
        var selectedSatellite = _satelliteDal.Get(p => p.Id == satelliteDeleteDto.Id);
        if (selectedSatellite != null)
        {
            _satelliteDal.Delete(selectedSatellite);
            return new SuccessResult();
        }
        else { return new ErrorResult(); }

    }

    public IDataResult<List<Satellite>> GetAll(string sortBy, string sortOrder, int page, int size)
    {
        var satellites = _satelliteDal.GetAll();

        if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(sortOrder))
        {
            satellites = SortAndPageSatellites(satellites, sortBy, sortOrder, page, size);
        }

        return new SuccessDataResult<List<Satellite>>(satellites);
    }

    //public IDataResult<List<Satellite>> GetAll(string filterParam, string sortOrder)
    //{
    //    var satellites = _satelliteDal.GetAll();

    //    if (!string.IsNullOrEmpty(filterParam))
    //    {
    //        satellites = satellites.Where(item => item.Name.Equals(filterParam, StringComparison.OrdinalIgnoreCase)).ToList();
    //        if (satellites.Count == 0)
    //        {
    //            return new ErrorDataResult<List<Satellite>>(Messages.NoMatchingContent);
    //        }
    //        else
    //        {
    //            if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
    //            {
    //                satellites = satellites.OrderBy(item => item.Name).ToList();
    //            }
    //            else if (sortOrder.ToLower() == "desc")
    //            {
    //                satellites = satellites.OrderByDescending(item => item.Name).ToList();
    //            }
    //            else
    //            {
    //                satellites = satellites.OrderBy(item => item.Name).ToList();
    //            }

    //            return new SuccessDataResult<List<Satellite>>(satellites);
    //        }

    //    }

    //    return new ErrorDataResult<List<Satellite>>(Messages.NullValue);
    //}

    public IDataResult<Satellite> GetById(int id)
    {
        var getById = _satelliteDal.Get(satellite => satellite.Id == id);
        return new SuccessDataResult<Satellite>(getById);
    }


    public IResult Update(Satellite satellite)
    {
        _satelliteDal.Update(satellite);
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

        _satelliteDal.Update(satelliteInfo);
        return new SuccessResult();
    }

    private List<Satellite> SortAndPageSatellites(List<Satellite> satellites, string sortBy, string sortOrder, int page, int size)
    {
        var property = typeof(Satellite).GetProperty(sortBy);

        if (property == null)
        {
            throw new ArgumentException($"Invalid property name: {sortBy}");
        }

        if (sortOrder.ToLower() == "asc")
        {
            satellites = satellites.OrderBy(item => property.GetValue(item, null)).ToList();
        }
        else if (sortOrder.ToLower() == "desc")
        {
            satellites = satellites.OrderByDescending(item => property.GetValue(item, null)).ToList();
        }
        else
        {
            throw new ArgumentException($"Invalid sort order: {sortOrder}");
        }

        var totalCount = satellites.Count;
        satellites = satellites.Skip((page - 1) * size).Take(size).ToList();

        return satellites;
    }
}
