using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using Restafarian.Core.ApiSpecs;

namespace Restafarian.Core.Testing;
[TestFixture]
public class RecordRendererTests
{
    [Test]
    public void RenderRecord_GeneratesBasicRecordCorrectly()
    {
        var model = new Model
        {
            Name = "Customer",
            Fields =
            [
                new Field { Name = "id", Type = "int" },
                new Field { Name = "name", Type = "string" }
            ]
        };

        var result = RecordRenderer.RenderRecord(model, "MyNamespace");

        Assert.That(result, Does.Contain("public record Customer"));
        Assert.That(result, Does.Contain("public int Id { get; init; }"));
        Assert.That(result, Does.Contain("public string Name { get; init; }"));
        Assert.That(result, Does.Contain("namespace MyNamespace"));
    }

    [Test]
    public void RenderRecord_SupportsNullableField()
    {
        var model = new Model
        {
            Name = "User",
            Fields = [new Field { Name = "email", Type = "string", Nullable = true }]
        };

        var result = RecordRenderer.RenderRecord(model, "MyApp.Models");

        Assert.That(result, Does.Contain("public string? Email { get; init; }"));
    }

    [Test]
    public void RenderRecord_UsesCapitalizedPropertyNames()
    {
        var model = new Model
        {
            Name = "Thing",
            Fields = [new Field { Name = "some_value", Type = "bool" }]
        };

        var result = RecordRenderer.RenderRecord(model, "Stuff");

        Assert.That(result, Does.Contain("public bool Some_value { get; init; }"));
    }
}
