using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using Microsoft.AspNetCore.Http;
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
        private readonly String _staticPath;
        public StrawberryController(FarmDbContext dbContext, IOptions<AppSettings> appSettings, Homo.Api.CommonLocalizer commonLocalizer)
        {
            _dbContext = dbContext;
            _staticPath = appSettings.Value.Common.StaticPath;
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

        [HttpPost]
        [Route("ml-raw")]
        public ActionResult<dynamic> CreateMlRawData([FromBody] DTOs.StrawberryMachineLearningRaw dto)
        {
            StrawberryMachineLearningRawDataservice.Create(_dbContext, dto);
            return new { status = "OK" };
        }

        [Route("files")]
        [HttpPost]
        public ActionResult<dynamic> Upload()
        {
            if (Request.ContentType.IndexOf("multipart/form-data") == -1)
            {
                throw new CustomException(ERROR_CODE.UNSUPPORT_MEDIA_TYPE, HttpStatusCode.UnsupportedMediaType);
            }

            if (!Directory.Exists(_staticPath))
            {
                Directory.CreateDirectory(_staticPath);
            }
            string destinationalFilename = "";
            DateTime now = DateTime.Now;
            string folder = now.ToString("yyyyMMdd");
            string filename = now.ToString("yyyyMMddHHmmssfff");
            string ext = "";
            if (Request.Form.Files.Count > 0)
            {
                foreach (IFormFile file in Request.Form.Files)
                {
                    ext = Path.GetExtension(file.FileName);
                    if (!new List<string> { "jpeg", "png", "jpg", "gif" }.Contains(ext))
                    {
                        throw new CustomException(ERROR_CODE.INVALID_FILE_EXT, HttpStatusCode.BadRequest);
                    }

                    if (!Directory.Exists($"{_staticPath}{folder}"))
                    {
                        Directory.CreateDirectory($"{_staticPath}{folder}");
                    }
                    destinationalFilename = $"{_staticPath}{folder}/{filename}{ext}";
                    FileStream filestream = new FileStream(destinationalFilename, FileMode.Create);
                    file.CopyTo(filestream);
                    filestream.Close();
                    filestream.Dispose();

                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                    {
                        Image image = Image.FromStream(file.OpenReadStream(), true, true);
                        int newWidth = (int)(image.Width * 0.3);
                        int newHeight = (int)(image.Height * 0.3);
                        var newImage = new Bitmap(newWidth, newHeight);
                        using (var g = Graphics.FromImage(newImage))
                        {
                            g.DrawImage(image, 0, 0, newWidth, newHeight);
                        }
                        newImage.Save($"{_staticPath}{folder}/{filename}-thumbnail{ext}");
                    }
                }
            }
            return new { uploaded = 1, url = $"/upload/{folder}/{filename}{ext}", fileName = $"{filename}{ext}" };
        }

    }
}
