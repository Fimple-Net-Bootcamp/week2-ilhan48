using Core.Entities.Abstract;

namespace Entities.DTOs.SatelliteDtos;

public class SatelliteDeleteDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
