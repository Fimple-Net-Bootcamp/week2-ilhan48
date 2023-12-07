using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Planet : IEntity
{
    public int Id { get; set; }
    public int SatelliteId { get; set; }
    public string Name { get; set; }
    public int Weather { get; set; }
}
