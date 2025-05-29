using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restafarian.Core.ApiSpecs;
public record Resource
{
    public string Name { get; init; } = "";
    public string Model { get; init; } = "";
    public List<Operation> Operations { get; init; } = [];
}
