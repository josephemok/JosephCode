using JosephCode.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using JosephCode.Services.WolveService;
using System.Threading.Tasks;
using JosephCode.Dtos.WolvesDtos;

namespace JosephCode.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WolveController :  ControllerBase
    {
      

       private readonly IWolveService _wolveService;

       public WolveController(IWolveService wolveService)
       {

           _wolveService = wolveService;


       }

       
      [HttpGet("GetAll")]
       public async Task<IActionResult> Get()
       {
            return Ok(await _wolveService.GetAllWolves());
       }
       
       [HttpGet("WolvesInPack")]
       public async Task<IActionResult> WolvesInPack()
       {
            return Ok(await _wolveService.GetAllWolves());
       }
       
        [HttpGet("SingleOne/{id}")]
       public async Task<IActionResult> GetSingle(int id)
       {

            return Ok(await _wolveService.GetWolveById(id));
       }

       [HttpPost]

       public async Task<IActionResult> AddWolve(AddWolveDto newWolve)
       {

           
            return Ok(await _wolveService.AddWolve(newWolve));
       }

        [HttpPut]

       public async Task<IActionResult> UpdateWolve(UpDateWolveDto upDateWolve)
       {

           ServiceResponds<GetWolveDto> response = await _wolveService.UpdateWolve(upDateWolve);
           if (response.Data == null){
                return NotFound(response);
           }
            return Ok(response);
       }

       public async Task<IActionResult> DeleteWolve(int id)
       {

           ServiceResponds<List<GetWolveDto>> response = await _wolveService.DeleteWolve(id);
           if (response.Data == null){
                return NotFound(response);
           }
            return Ok(response);
       }
       
    }
}