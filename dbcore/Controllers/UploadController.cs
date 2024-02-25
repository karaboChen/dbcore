using dbcore.Fliiter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbcore.Controllers
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("upload")]
        [FileLiimt]
        public void 上傳檔案(List<IFormFile> files)
        {

            var 跟目錄 = _webHostEnvironment.ContentRootPath + @"\wwwroot\";

            foreach (var file in files)
            {
                var fileName = file.FileName;

                using (var stream = System.IO.File.Create(跟目錄 + fileName))   //在哪個地方 創立檔案
                {
                    //把檔案複製下來
                    file.CopyTo(stream);
                    var aa = "9996";
                }
            }

        }
    }
}
