using JosephCode.Dtos.WolvesDtos;
using JosephCode.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JosephCode.Services.WolveService
{
    public interface IWolveService
    {
        Task<ServiceResponds<List<GetWolveDto>>> GetAllWolves();

        Task<ServiceResponds<GetWolveDto>> GetWolveById(int id);

        Task<ServiceResponds<List<GetWolveDto>>> AddWolve(AddWolveDto newWolve);

        Task<ServiceResponds<GetWolveDto>> UpdateWolve(UpDateWolveDto upDateWolve);

       Task<ServiceResponds<List<GetWolveDto>>> DeleteWolve(int id);

       
         
    }
}