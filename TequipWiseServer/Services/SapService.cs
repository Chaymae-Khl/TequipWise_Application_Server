using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequipWiseServer.Data;
using TequipWiseServer.DTO;
using TequipWiseServer.Interfaces;
using TequipWiseServer.Models;

namespace TequipWiseServer.Services
{
    public class SapService : ISapNum
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SapService(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SapNumberDto>> GetSapNums()
        {
            var sapNumbers = await _context.SapNumbers.Include(s=>s.Controller).ToListAsync();
            return _mapper.Map<IEnumerable<SapNumberDto>>(sapNumbers);
        }

        public async Task<IActionResult> AddSuplier(SapNumber sapnum)
        {
            if (sapnum == null)
            {
                return new BadRequestResult();
            }

            await _context.SapNumbers.AddAsync(sapnum);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> DeleteSapNum(string id)
        {
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out var sapNumId))
            {
                return new BadRequestResult();
            }

            var sapnum = await _context.SapNumbers.FindAsync(sapNumId);

            if (sapnum == null)
            {
                return new NotFoundResult();
            }

            _context.SapNumbers.Remove(sapnum);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> UpdateSapNum(string sapId, SapNumber sapnum)
        {
            if (string.IsNullOrEmpty(sapId) || sapnum == null || !int.TryParse(sapId, out var sapNumId))
            {
                return new BadRequestResult();
            }

            var existingSapNum = await _context.SapNumbers.FindAsync(sapNumId);
            if (existingSapNum == null)
            {
                return new NotFoundResult();
            }

            // Update properties
            existingSapNum.SapNum = sapnum.SapNum;
            existingSapNum.Idcontroller = sapnum.Idcontroller;
            
            // Update other properties as needed

            await _context.SaveChangesAsync();

            return new OkResult();
        }
    }
}
