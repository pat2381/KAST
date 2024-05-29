using KAST.Domain.Common.Entities;

namespace KAST.Domain.Entities;

public class Tenant : IEntity<string>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
}