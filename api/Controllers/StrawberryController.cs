using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Homo.Api;
using Homo.Core.Constants;
using Homo.AuthApi;
using Swashbuckle.AspNetCore.Annotations;

namespace Homo.FarmApi
{
    [Route("v1/strawberries")]
    [Validate]
    public class StrawberryController : ControllerBase
    {
        private readonly FarmDbContext _dbContext;
        public StrawberryController(FarmDbContext dbContext, IOptions<AppSettings> appSettings, Homo.Api.CommonLocalizer commonLocalizer)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<dynamic> GetAll([FromQuery] DTOs.StrawberryQuery dto)
        {
            return StrawberryDataservice.GetAll(_dbContext, dto);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<dynamic> GetOne([FromRoute] long id)
        {
            return StrawberryDataservice.GetOne(_dbContext, id);
        }

        [HttpPost]
        public ActionResult<dynamic> Create([FromBody] DTOs.Strawberry dto)
        {
            StrawberryDataservice.Create(_dbContext, dto);
            return new { status = "OK" };
        }

        [HttpGet]
        [Route("{strawberryId}/logs")]
        public ActionResult<dynamic> GetLogs([FromRoute] long strawberryId, [FromQuery] System.DateTime? startAt, [FromQuery] System.DateTime? endAt, [FromQuery] int page, [FromQuery] int limit)
        {
            return StrawberryLogDataservice.GetList(_dbContext, strawberryId, startAt, endAt, page, limit);
        }

        [HttpPost]
        [Route("{strawberryId}/logs")]
        public ActionResult<dynamic> CreateLog([FromRoute] long strawberryId, [FromBody] DTOs.StrawberryLog dto)
        {
            return StrawberryLogDataservice.Create(_dbContext, strawberryId, dto);
        }

        [HttpGet]
        [Route("{strawberryId}/logs/{id}")]
        public ActionResult<dynamic> GetLog([FromRoute] long id)
        {
            return StrawberryLogDataservice.GetOne(_dbContext, id);
        }

        [HttpPatch]
        [Route("{strawberryId}/logs/{id}")]
        public ActionResult<dynamic> UpdateLog([FromRoute] long id, [FromBody] DTOs.StrawberryLog dto)
        {
            StrawberryLogDataservice.Update(_dbContext, id, dto);
            return new { status = "OK" };
        }

    }
}
