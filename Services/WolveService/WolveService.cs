using System.Collections.Generic;
using JosephCode.Models;
using System.Linq;
using System.Threading.Tasks;
using JosephCode.Dtos.WolvesDtos;
using AutoMapper;
using System;
using JosephCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JosephCode.Services.WolveService
{
    public class WolveService : IWolveService
    {

       
       private readonly IMapper _mapper;

       private readonly DataContext _context;

       

       public WolveService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
       {
            _context = context;
            _mapper = mapper;
           

       }

        public async Task<ServiceResponds<List<GetWolveDto>>> AddWolve(AddWolveDto newWolve)

        {
            ServiceResponds<List<GetWolveDto>> serviceResponds = new ServiceResponds<List<GetWolveDto>>();
            Wolve wolve = _mapper.Map<Wolve>(newWolve);
            await _context.Wolves.AddAsync(wolve);
            await _context.SaveChangesAsync();
            
            serviceResponds.Data = _context.Wolves.Select(c=> _mapper.Map<GetWolveDto>(c)).ToList();
            return serviceResponds;
        }

        public async Task<ServiceResponds<List<GetWolveDto>>> DeleteWolve(int id)
        {
            ServiceResponds<List<GetWolveDto>> serviceResponds = new ServiceResponds<List<GetWolveDto>>();

            try{

                     Wolve wolve = await _context.Wolves.FirstAsync(c => c.Id == id);
                     _context.Wolves.Remove(wolve);
                     await _context.SaveChangesAsync();

                      serviceResponds.Data = _context.Wolves.Select(c=> _mapper.Map<GetWolveDto>(c)).ToList();;

                  
                }

            catch(Exception ex)

            {

                serviceResponds.Success = false;
                serviceResponds.Message = ex.Message;

            }

            return serviceResponds;
        }

        public async Task<ServiceResponds<List<GetWolveDto>>> GetAllWolves()
        {

            ServiceResponds<List<GetWolveDto>> serviceResponds = new ServiceResponds<List<GetWolveDto>>();
            List<Wolve> dbWolves = await _context.Wolves.ToListAsync();

            serviceResponds.Data = dbWolves.Select(c=> _mapper.Map<GetWolveDto>(c)).ToList();;

            return serviceResponds;
        }

        public async Task<ServiceResponds<GetWolveDto>> GetWolveById(int id)
        {
           ServiceResponds<GetWolveDto> serviceResponds = new ServiceResponds<GetWolveDto>();
           Wolve dbWolve = await _context.Wolves.FirstOrDefaultAsync(c => c.Id == id);
           serviceResponds.Data = _mapper.Map<GetWolveDto>(dbWolve);
           return serviceResponds;
        }

        public async Task<ServiceResponds<GetWolveDto>> UpdateWolve(UpDateWolveDto updateWolve)
        {
            ServiceResponds<GetWolveDto> serviceResponds = new ServiceResponds<GetWolveDto>();
            try
            {
               Wolve wolve = await _context.Wolves.FirstOrDefaultAsync(c => c.Id == updateWolve.Id);
               wolve.Name = updateWolve.Name;
               wolve.Gender = updateWolve.Gender;
               wolve.Birthday = updateWolve.Birthday;
               wolve.Latitide = updateWolve.Latitide;
               wolve.Logitude = updateWolve.Logitude;

               _context.Wolves.Update(wolve);
               await _context.SaveChangesAsync();

               serviceResponds.Data = _mapper.Map<GetWolveDto>(wolve);

            }

            catch(Exception ex)
            {

                serviceResponds.Success = false;
                serviceResponds.Message = ex.Message;

            }

            return serviceResponds;
            
        }
    }
}