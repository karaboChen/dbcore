using dbcore.Dto;
using dbcore.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace dbcore.Controllers
{

    [ApiController]
    public class SeeController : ControllerBase
    {

        private readonly RoadContext _roadContext;

        public SeeController(RoadContext roadContext)
        {
            _roadContext = roadContext;
        }


        [HttpGet("see/get")]
        public async Task<IActionResult> Get()
        {
            // var ans = _roadContext.map.Select(a => TryParseAndAdd(a.title)).ToList();

            //var b=   ans.Where(a => a.HasValue).ToList();

            // return Ok(b);


            //var ans = await _roadContext.map.Where(a => a.id == 4).Select(a => new TA
            //{
            //    name = a.title,
            //    ssd = a.id.ToString()

            //}).ToListAsync();


            //var ans =  await _roadContext.map.Select(a=>測試(a)).ToListAsync();

            //var results = _roadContext.map.FromSqlRaw("SELECT * FROM MyTable WHERE Column = {0}", parameterValue).ToList();

            return Ok("2");
        }



        [HttpPost("see/post")]
        public void Post([FromBody] BcsDtocs e)
        {

            _roadContext.Add(e);
            _roadContext.SaveChanges();

        }

        [HttpGet("see/movie")]
        public IActionResult 測試()
        {
            var tmp = new List<string>() { "ji", "ji32ji3j3" };

            return Ok(new { aa = "999", bb = 123, cc = true, dd = tmp });
        }



        [HttpPut("see/put")]
        public void Put([FromBody] List<User> e)
        {
            //_roadContext.aaaa.Update(e);
            //_roadContext.SaveChanges();

            var data = (from a in _roadContext.aaaa
                        where a.aaa == 399
                        select a).SingleOrDefault();



            _roadContext.aaaa.Update(data).CurrentValues.SetValues(e);
            _roadContext.SaveChanges();


            //var source = _roadContext.aaaa.Where(e => e.aaa == 10).ToList();
            //foreach (var item in source)
            //{
            //    item.aaa = 11;
            //}
            //_roadContext.SaveChanges();

            //var num = 399;
            //_roadContext.aaaa.Where(d => d.aaa == 9)
            //.ExecuteUpdate(s => s
            //                      .SetProperty(p => p.aaa, num)
            //                      .SetProperty(p => p.sssa, "我不知道")
            //                      );
            //DimCustomer.Where(d => d.MiddleName == "C")
            //.ExecuteUpdate(s => s.SetProperty(p => p.MiddleName, p => p.FirstName + "CC" + p.LastName));

            //DimCustomer.Where(d => d.MiddleName == "CC").ExecuteDelete();




        }



        //private static int? TryParseAndAdd(string title)
        //{
        //    if (int.TryParse(title, out int number))
        //    {
        //        return number + 30;
        //    }
        //    return null;
        //}


        private static TA 測試(map item)
        {
            return new TA
            {
                name = item.title,
                ssd = item.id.ToString(),
            };
        }

    }
}
