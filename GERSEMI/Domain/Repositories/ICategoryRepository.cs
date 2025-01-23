using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
    }
}
