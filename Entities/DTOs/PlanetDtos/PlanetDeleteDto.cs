using Core.Entities.Abstract;

namespace Entities.DTOs.PlanetDtos;

public class PlanetDeleteDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
