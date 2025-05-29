using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restafarian.Core.ApiSpecs;
using Scriban;

namespace Restafarian.Core;
public static class RecordRenderer
{
    public static string RenderRecord(Model model, string ns)
    {
        var templateText = EmbeddedResourceLoader.Load("Templates/Record.sbncs");

        var template = Template.Parse(templateText);
        if (template.HasErrors)
            throw new InvalidOperationException("Scriban template error: " + string.Join(", ", template.Messages));

        var rendered = template.Render(new { @namespace = ns, model });
        return rendered;
    }
}
