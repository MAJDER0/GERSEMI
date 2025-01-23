using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryTranslationRepository
    {
        Task<CategoryTranslation?> GetByIdAsync(int id);
        Task<List<CategoryTranslation>> GetAllByCategoryIdAsync(int categoryId);
        Task AddAsync(CategoryTranslation translation);
        Task UpdateAsync(CategoryTranslation translation);
    }
}
