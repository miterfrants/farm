using Microsoft.AspNetCore.Mvc;
using Homo.AuthApi;
using Swashbuckle.AspNetCore.Annotations;

namespace Homo.FarmApi
{
    [Route("v1/universal")]
    public class UniversalController : ControllerBase
    {

        public UniversalController()
        {
        }

        [SwaggerOperation(
            Tags = new[] { "常數" },
            Summary = "",
            Description = ""
        )]
        [HttpGet]
        [Route("diseases")]
        public ActionResult<dynamic> getDiseases()
        {
            return ConvertHelper.EnumToList(typeof(STRAWBERRY_DISEASE));
        }
    }
}
