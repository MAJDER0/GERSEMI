using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    internal class CategoryTranslationRepository : ICategoryTranslationRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryTranslationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryTranslation?> GetByIdAsync(int id)
        {
            return await _dbContext.CategoryTranslations
                .Include(ct => ct.Category)
                .FirstOrDefaultAsync(ct => ct.Id == id);
        }

        public async Task<List<CategoryTranslation>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _dbContext.CategoryTranslations
                .Where(ct => ct.Category.Id == categoryId)
                .Include(ct => ct.Category)
                .ToListAsync();
        }

        public async Task AddAsync(CategoryTranslation translation)
        {
            await _dbContext.CategoryTranslations.AddAsync(translation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryTranslation translation)
        {
            _dbContext.CategoryTranslations.Update(translation);
            await _dbContext.SaveChangesAsync();
        }
    }
}
