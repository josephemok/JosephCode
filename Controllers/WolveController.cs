using JosephCode.Models;
using Microsoft.AspNetCore.Mvc;


namespace JosephCode.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WolveController :  ControllerBase
    {
       private  static Wolve wolve = new Wolve();

       public IActionResult Get()
       {
            return Ok(wolve);
       }
    }
}