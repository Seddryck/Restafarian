using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restafarian.Core.ApiSpecs;
public record Field
{
    public required string Name { get; init; }
    public required string Type { get; init; }
    public bool Nullable { get; init; } = false;
    public string? Description { get; init; }
}
