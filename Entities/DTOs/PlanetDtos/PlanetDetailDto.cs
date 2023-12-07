using Core.Entities.Abstract;

namespace Entities.DTOs.PlanetDtos;

public class PlanetDetailDto : IDto
{
    public int Id { get; set; }
    public int SatelliteId { get; set; }
    public string Name { get; set; }
    public int Weather { get; set; }
    public string SatelliteName { get; set; }
    public int SatelliteWeather { get; set; }
}
