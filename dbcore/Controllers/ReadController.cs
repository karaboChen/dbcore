using dbcore.Models;
using dbcore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dbcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {

        private readonly testContext _testContext;
        private readonly RoadContext _RoadContext;
        private readonly ReadService _readService;

        public ReadController(testContext testContext, RoadContext roadContext, ReadService readService)
        {
            _testContext = testContext;
            _RoadContext = roadContext;
            _readService = readService;
        }


        // GET: api/<ReadController>
        [HttpGet]
        public IActionResult Get()
        {
            var ans = _readService.測試資料("跑泡看");
            return Ok(ans);
        }

        // GET api/<ReadController>/5
        [HttpGet("{id}/{aa}")]
        public string Get(string id, string aa)
        {
            return id + aa;
        }

        [HttpGet("ss")]
        public string Get1([FromQuery] string name, int num)
        {
            return name + num.ToString();
        }

        // POST api/<ReadController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] map value)
        {
            await _RoadContext.map.AddAsync(value);
            await _RoadContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { title = value.title }, value);


            //          return CreatedAtAction(
            //    nameof(GetUser), // Location Header 指向的 Action
            //    new { id = user.Id }, // Location Header 指向的 Action 的參數
            //    user // 回傳的內容，是建立成功的完整的資料
            //);

        }

        // PUT api/<ReadController>/5
        [HttpPut("update")]
        public void Put([FromBody] map value)
        {
            //_RoadContext.map.Entry(value).State = EntityState.Modified;
            //_RoadContext.SaveChanges();


            _RoadContext.map.Where(d => d.title == "www")
               .ExecuteUpdate(s => s
                                    .SetProperty(p => p.title, "ooo")
                                    .SetProperty(p => p.id, 878)
                                    );
        }

        // DELETE api/<ReadController>/5
        [HttpDelete("del")]
        public void Delete([FromBody] Id title)
        {
            var ans = _RoadContext.map.Find(title);

            if (ans != null)
            {
                _RoadContext.map.Remove(ans);
                _RoadContext.SaveChanges();
            }
            _RoadContext.Database.ExecuteSqlRaw("DELETE FROM map WHERE title = {0}", title);
            //_RoadContext.Database.ExecuteSqlRaw("insert into map(title,id)  values({0},{1})", title.title,title.id);
        }
    }
}
