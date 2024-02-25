using dbcore.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection.Metadata;

namespace dbcore.Fliiter
{
    //檔案過濾的 
    public class FileLiimtAttribute : Attribute, IResourceFilter
    {

        public long size ;

        //當我有屬性設定時，會優先使用外部傳入的。如果沒有才會預設值。



        public FileLiimtAttribute( long _size =100)
        {
            size = _size;
        }


        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // 回傳的時候  出去

            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {  
            // 正在執行  近來
            var files = context.HttpContext.Request.Form.Files;

            foreach (var file in files)
            {
                //file.length 注意這邊會取得檔案大小 就是byte

                //注意byte 1024 *1024 *1  就是 1MB

                  
                //取得副檔名
                var a = Path.GetExtension(file.FileName); 

                if( file.Length > 1024 * size)
                {
                    context.Result = new JsonResult(new ReturnJson()
                    {
                        Data = "測試1",
                        HttpCode = 401,
                        ErrorMessage = "檔案太大了"
                    });
                }

             
            }
        }
    }
}
