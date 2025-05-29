using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restafarian.Core.ApiSpecs;

public record Specification
{
    public string Domain { get; init; } = "";
    public List<Model> Models { get; init; } = [];
    public List<Resource> Resources { get; init; } = [];
}
