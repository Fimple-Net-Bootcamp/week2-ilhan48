using Core.Entities.Abstract;

namespace Entities.DTOs;

public class SatelliteWeatherDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Weather { get; set; }
}
