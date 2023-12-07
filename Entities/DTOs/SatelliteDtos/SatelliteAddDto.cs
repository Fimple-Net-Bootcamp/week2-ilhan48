using Core.Entities.Abstract;

namespace Entities.DTOs.SatelliteDtos;

public class SatelliteAddDto : IDto
{
    public string Name { get; set; }
    public int Weather { get; set; }
}
