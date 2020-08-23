using System.Threading.Tasks;
using JosephCode.Data;
using Microsoft.AspNetCore.Mvc;
using JosephCode.Dtos.PackDto;
using JosephCode.Models;
using Microsoft.EntityFrameworkCore;

namespace JosephCode.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class PackController : ControllerBase
    {
        

         private readonly DataContext _context;
        private readonly IPackRepository _packRepo;

        public PackController(IPackRepository packRepo, DataContext context)
        {
            _packRepo = packRepo;

            _context =context;

        }

        [HttpPost]
        public async Task<IActionResult> AddPack(AddPackDto request)
        {
            ServiceResponds<int> responds = await _packRepo.AddPack(
                new Pack { Id = request.Id, Name = request.Name}
            );

            if(!responds.Success)
            {

                return BadRequest(responds);

            }

            return Ok(responds);

        }

        [HttpPut]

         public async Task<IActionResult> AddWolveToPack(int packId, int wolveId)
       {
         
           ServiceResponds<int> responds = await _packRepo.AddWolveToPack(packId, wolveId);
           return Ok(responds);          
            
       }

        
         [HttpGet("Get/{id}")]

        public async Task<IActionResult> GetWolveByPackId(int id)
       {
         return Ok(await _packRepo.GetWolveByPackId(id));               
            
       }

        [HttpGet("GetAll")]
       public async Task<IActionResult> Get()
       {
            return Ok(await _packRepo.GetAll());
       }


         public async Task<IActionResult> DeleteWolve(int packId, int id)
       {
          return Ok(await _packRepo.RemoveWolve(packId,id));
       }


    
    
        
    }
}