using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories
                .Include(c => c.Children)
                .Include(c => c.Translations)
                //you can also include the paren't translations if needed
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories
                .Include(c => c.Children)
                .Include(c => c.Translations)
                .ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
