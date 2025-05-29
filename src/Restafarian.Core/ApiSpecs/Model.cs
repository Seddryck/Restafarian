using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restafarian.Core.ApiSpecs;
public record Model
{
    public required string Name { get; init; }
    public List<string> Key { get; init; } = [];
    public List<Field> Fields { get; init; } = [];
}
