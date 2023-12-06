using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Satellite : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Weather { get; set; }
}
