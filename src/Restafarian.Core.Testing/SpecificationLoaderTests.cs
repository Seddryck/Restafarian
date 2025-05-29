using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Restafarian.Core.Testing;

[TestFixture]
internal class SpecificationLoaderTests
{
    [Test]
    public void LoadFromFile_ShouldParseDomainAndModel()
    {
        var yaml = """
        domain: MyGeneratedApi

        models:
          - name: Customer
            key: [id]
            fields:
              - name: id
                type: int
              - name: name
                type: string
        """;

        var path = WriteTempFile(yaml);

        var spec = SpecificationLoader.LoadFromFile(path);

        Assert.That(spec.Domain, Is.EqualTo("MyGeneratedApi"));
        Assert.That(spec.Models.Count, Is.EqualTo(1));

        var model = spec.Models.First();
        Assert.That(model.Name, Is.EqualTo("Customer"));
        Assert.That(model.Key, Is.EquivalentTo(new[] { "id" }));
        Assert.That(model.Fields, Has.Count.EqualTo(2));
    }

    [Test]
    public void LoadFromFile_ShouldSupportQueryAndPathParameters()
    {
        // Arrange
        var yaml = """
        domain: TestApi

        models:
          - name: Customer
            key: [id]
            fields:
              - name: id
                type: int

        resources:
          - name: Customer
            model: Customer
            operations:
              - kind: list
                view: key
                routes:
                  - path: /customers
                  - path: /country/{country}/customers
                    pathParameters:
                      - name: country
                        type: string
        """;

        var path = WriteTempFile(yaml);
        var spec = SpecificationLoader.LoadFromFile(path);

        var operation = spec.Resources.First().Operations.First();
        var routes = operation.Routes;

        Assert.That(routes.Any(r => r.Path == "/customers"), Is.True);

        var pathRoute = routes.First(r => r.Path.Contains("{country}"));
        Assert.That(pathRoute.PathParameters, Is.Not.Null);
        Assert.That(pathRoute.PathParameters.First().Name, Is.EqualTo("country"));
    }

    private static string WriteTempFile(string yamlContent)
    {
        var file = Path.GetTempFileName();
        File.WriteAllText(file, yamlContent);
        return file;
    }
}
