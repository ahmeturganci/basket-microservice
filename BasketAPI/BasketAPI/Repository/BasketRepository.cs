using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasketAPI.Data;
using BasketAPI.Data.Entities;
using BasketAPI.Repository.Implementations;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _context;

        public BasketRepository(BasketDbContext context)
        {
            _context = context;
        }


        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<BasketItem>> GetBasketsAsync()
        {
            return await _context.BasketItems.ToListAsync();
        }

        public async Task<bool> AddBasketsAsync(BasketItem entity)
        {
            await _context.BasketItems.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<BasketItem> GetBasketsByUserNameAsync(string userName)
        {
            return await _context.BasketItems.FindAsync(userName);
        }

        
    }
}
