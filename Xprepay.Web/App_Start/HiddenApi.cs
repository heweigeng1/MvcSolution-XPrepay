using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace Xprepay.Web.App_Start
{
    public partial class HiddenApi : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            //foreach (var item in apiExplorer.ApiDescriptions)
            //{
            //    if (item.RelativePath.Contains("management"))
            //    {
            //        swaggerDoc.paths.Remove("/" + item.RelativePath);
            //    }
            //}
        }
    }
}
