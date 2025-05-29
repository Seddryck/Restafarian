using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restafarian.Core.ApiSpecs;
public record Route
{
    public required string Path { get; init; }
    public List<PathParameter> PathParameters { get; init; } = [];
}
