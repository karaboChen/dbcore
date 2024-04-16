using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dbcore.Fliiter
{
    public class ResultFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {

            if (context.ModelState.IsValid)
            {
                //如果都沒問題 會是TRUE  近來 這邊
            }
            else
            {
                 //就會跑這邊了
            } 


            var  ans  = context.Result as ObjectResult;

            throw new NotImplementedException();
        }
    }
}
