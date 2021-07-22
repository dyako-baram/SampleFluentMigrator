using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SampleFluentMigrator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _config;

        public WeatherForecastController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var con=new SqliteConnection(_config.GetConnectionString("Default")))
            {
                var result =await con.QueryAsync("Select * from Book");
                return Ok(result);
            }
        }
    }
}
