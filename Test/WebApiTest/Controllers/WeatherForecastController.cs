using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly FuckWayneDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, FuckWayneDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public class Demo
        {
            public string para1 { get; set; }
        }

        [HttpPost]
        public string FuckWayne([FromBody]Demo d)
        {
            return d.para1;
        }

        [HttpPost]
        public string FuckWayne1([FromForm] string para1)
        {
            return para1;
        }

        [HttpPost]
        public async Task<string> TestSQliteCRUD()
        {
            var res = string.Empty;
            using (var db = _context)
            {
                //1.新增
                var userInfo = new UserInfo()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = "FuckWayne",
                    Sex = "男"
                };
                await db.Set<UserInfo>().AddAsync(userInfo);
                int count = await db.SaveChangesAsync();
                res += $"\r\n成功插入{count}条数据";

                //2.查询
                List<UserInfo> uList = db.Set<UserInfo>().ToList();
                foreach (var item in uList)
                {
                    res += $"\r\nid为：{item.Id},名字为：{item.Name},性别为：{item.Sex}";
                }
            }

            return res;
        }
    }
}
