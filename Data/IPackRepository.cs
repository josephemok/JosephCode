using System.Collections.Generic;
using System.Threading.Tasks;
using JosephCode.Dtos.PackDto;
using JosephCode.Dtos.WolvesDtos;
using JosephCode.Models;

namespace JosephCode.Data
{
    public interface IPackRepository
    {

        Task<ServiceResponds<int>> AddPack(Pack pack);

        Task<ServiceResponds<List<GetWolvePack>>> GetWolveByPackId(int id);

        Task<ServiceResponds<int>> AddWolveToPack(int packId, int wolveId);

        Task<ServiceResponds<GetWolveDto>> RemoveWolve(int packId ,int wolveid);

        Task<ServiceResponds<List<GetWolvePack>>> GetAll();

        
        


         
    }
}