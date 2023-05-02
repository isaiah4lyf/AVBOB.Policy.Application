using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVBOB.Application.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IWebHostEnvironment _Environment;

        public DocumentController(IWebHostEnvironment _Environment)
        {
            this._Environment = _Environment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile file)
        {
            string name = file.FileName;
            string guid = Guid.NewGuid().ToString();
            string extension = name.Split('.')[name.Split('.').Length - 1];

            MemoryStream ms = new MemoryStream(new byte[file.Length]);

            await file.CopyToAsync(ms);

            string path = _Environment.ContentRootPath + "Documents\\";

            using (FileStream _file = new FileStream(path + guid + "." + extension, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(_file);
            }

            return Ok(new DocumentDTO()
            {
                Description = string.Empty,
                Title = string.Empty,
                Size = string.Empty,
                Extension = extension,
                Name = guid + "." + extension,
                Guid = Guid.Parse(guid),
                OriginalTitle = name,
                Url = guid + "." + extension,
                IsActive = true,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IOrder = 0,
            });
        }
    }
}
