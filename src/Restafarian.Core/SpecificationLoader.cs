using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using Restafarian.Core.ApiSpecs;

namespace Restafarian.Core;
public class SpecificationLoader
{
    public static Specification LoadFromFile(string path)
    {
        var yaml = File.ReadAllText(path);

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        var spec = deserializer.Deserialize<Specification>(yaml);
        return spec;
    }
}
