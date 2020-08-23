using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JosephCode.Dtos.PackDto;
using JosephCode.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using JosephCode.Dtos.WolvesDtos;
using System;

namespace JosephCode.Data
{
    public class PackRepository : IPackRepository
    {

        private readonly DataContext _context;

         private readonly IMapper _mapper;

        public PackRepository(DataContext context, IMapper mapper)
        {

              _context = context;
              _mapper = mapper;
        }
        public async Task<ServiceResponds<int>> AddPack(Pack pack)
        {
            
            await _context.Packs.AddAsync(pack);
            await _context.SaveChangesAsync();
            ServiceResponds<int> responds = new ServiceResponds<int>();
            responds.Data = pack.Id;
            return responds;
        }

        public async Task<ServiceResponds<int>> AddWolveToPack(int packId, int wolveId)
        {
          
            Wolve dbWolve = await _context.Wolves.FirstOrDefaultAsync(c => c.Id == wolveId);
            Pack  dbpack = await _context.Packs.FirstOrDefaultAsync(c => c.Id == packId);
            dbWolve.Pack = dbpack;
            _context.Wolves.Add(dbWolve);
            _context.Entry(dbWolve).State =EntityState.Unchanged;
          //  dbWolve.Pack.Id = dbpack.Id;
            _context.Wolves.Update(dbWolve);
            await _context.SaveChangesAsync();
           
           ServiceResponds<int> responds = new ServiceResponds<int>();
            responds.Data = dbWolve.Id;
            return responds;
        }

        public async Task<ServiceResponds<List<GetWolvePack>>> GetWolveByPackId(int id)
        {
            var wov = _context.Wolves.Select(a => a.Pack.Id).FirstOrDefault();
            
            if (wov != id)
            {
                
            }

             ServiceResponds<List<GetWolvePack>> serviceResponds = new ServiceResponds<List<GetWolvePack>>();
             List<Pack> pack = await _context.Packs.Include(a=> a.Wolves).Where(r => r.Id == id).ToListAsync();
             serviceResponds.Data = pack.Select(c=> _mapper.Map<GetWolvePack>(c)).ToList();;

            return serviceResponds;
            

        }

         public async Task<ServiceResponds<List<GetWolvePack>>> GetAll()
        {

            ServiceResponds<List<GetWolvePack>> serviceResponds = new ServiceResponds<List<GetWolvePack>>();
            List<Pack> pack = await _context.Packs.Include(a=> a.Wolves).ToListAsync();
            

            serviceResponds.Data = pack.Select(c=> _mapper.Map<GetWolvePack>(c)).ToList();;

            return serviceResponds;
        }

        public async Task<ServiceResponds<GetWolveDto>> RemoveWolve(int  packId , int wolveId)
        {
             ServiceResponds<GetWolveDto> serviceResponds = new ServiceResponds<GetWolveDto>();

        try{       
            var packObj = await _context.Packs.Include(w => w.Wolves).Where(a => a.Id == packId).FirstOrDefaultAsync();
           var wolveObj = packObj.Wolves.Where(w => w.Id == wolveId).FirstOrDefault();
            
           if (wolveObj != null){

               packObj.Wolves.Remove(wolveObj);
           }

            await _context.SaveChangesAsync();
             serviceResponds.Data = _mapper.Map<GetWolveDto>(wolveObj);

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
