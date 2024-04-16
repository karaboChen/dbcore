using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace dbcore.Fliiter
{
    public class ActionFilter : IActionFilter
    {   
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ActionFilter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


            
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var 跟目錄 = _webHostEnvironment.ContentRootPath + @"\Log\";

            if (!Directory.Exists(跟目錄))
            {
                Directory.CreateDirectory(跟目錄);
            }

        
            var bb = context.HttpContext.Request.Path;

            var text = "結束" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " 路徑" + bb + "\r\n";
            File.AppendAllText(跟目錄 + DateTime.Now.ToString("yyyyMMdd") + ".txt", text);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var 跟目錄 = _webHostEnvironment.ContentRootPath + @"\Log\";

            if (!Directory.Exists(跟目錄))
            {
                Directory.CreateDirectory(跟目錄);
            }

            var 參數 = context.ActionArguments;
            var 結構化 = JsonConvert.SerializeObject(參數);


            var args = context.ActionArguments.Select(a => $"{JsonConvert.SerializeObject(a.Value)}");
            var arg = string.Join(",", args);


            var bb = context.HttpContext.Request.Path;

            var text = "開始"+DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")+" 參數內容"+ arg + " 路徑" + bb + "\r\n";


            File.AppendAllText(跟目錄 + DateTime.Now.ToString("yyyyMMdd") + ".txt", text);
        }
    }
}
