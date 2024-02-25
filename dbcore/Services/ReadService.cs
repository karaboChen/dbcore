using dbcore.Models;

namespace dbcore.Services
{
    public class ReadService
    {
        private readonly testContext _testContext;

        public ReadService(testContext testContext)
        {
            _testContext= testContext;
        }

        public List<TA> 測試資料(string name)     // List<TA>
        {
            var aa =  _testContext._3_line.Select(a => new TA
            {
                //左邊定義的容器   =  右邊塞值
                name = name,
                ssd = "靠杯"
            }).ToList();

            return aa;
        }


    }
}
