using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Homo.Api;

namespace Homo.FarmApi
{
    [Route("v1/ml")]
    [Validate]
    public class MachineLearningController : ControllerBase
    {
        private readonly FarmDbContext _dbContext;
        private readonly String _staticPath;
        public MachineLearningController(FarmDbContext dbContext, IOptions<AppSettings> appSettings, Homo.Api.CommonLocalizer commonLocalizer)
        {
            _dbContext = dbContext;
            _staticPath = appSettings.Value.Common.StaticPath;
        }

        [HttpPost]
        public ActionResult<dynamic> CreateMlRawData([FromBody] DTOs.StrawberryMachineLearningRaw dto)
        {
            StrawberryMachineLearningRawDataservice.Create(_dbContext, dto);
            return new { status = "OK" };
        }

    }
}
