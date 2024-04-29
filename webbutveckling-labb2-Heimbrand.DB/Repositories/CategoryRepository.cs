using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webbutveckling_labb2_Heimbrand.DB.Repositories;

public class CategoryRepository : ICategoryService<Category>
{
    private readonly WebbHandelDbContext _context;
    public CategoryRepository(WebbHandelDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category?> GetCategoryByName(string name)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
    }
    public async Task AddCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is null)
        {
            return;
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}