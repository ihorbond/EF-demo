using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetNewUser()
        {
            User newUser;
            using(var ctx = new ConnectContext())
            {
                var address = ctx.Set<Address>().Find(1);

                var id = new Random().Next(10, 4000);

                newUser = new User()
                {
                    Id = id,
                    Name = $"user{id}",
                    AddressId = address.Id
                };

                ctx.Set<User>().Add(newUser);
                ctx.SaveChanges();

                Console.WriteLine(newUser.Address == null);
            }

            //this will be false as newUser's Address property got automatically populated 
            return Ok(newUser.Address == null);
        }
    }
}
