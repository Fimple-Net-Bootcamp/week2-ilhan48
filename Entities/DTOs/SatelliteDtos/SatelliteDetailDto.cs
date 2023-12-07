using Core.Entities.Abstract;

namespace Entities.DTOs.SatelliteDtos;

public class SatelliteDetailDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Weather { get; set; }
}
