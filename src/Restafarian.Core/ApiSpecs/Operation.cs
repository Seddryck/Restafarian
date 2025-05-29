using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restafarian.Core.ApiSpecs;
public record Operation
{
    public required OperationKind Kind { get; init; }
    public required OperationView View { get; init; }
    public List<Route> Routes { get; init; } = new();
}
