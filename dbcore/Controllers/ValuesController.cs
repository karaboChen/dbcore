using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dbcore.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("www/ss")]
        public async Task  Get()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiUrl = "https://api.example.com/data";
                for(int i=0; i<100; i++)
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        // 處理回應內容

              


                    }
                }
            }
        }

    }
}
