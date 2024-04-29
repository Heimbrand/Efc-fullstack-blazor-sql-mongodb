namespace Labb2WebbTemplate.Common.Interfaces;

public interface ICategoryService<T> where T : class
{
    Task<IEnumerable<T>> GetAllCategories();
    Task<T?> GetCategoryByName(string name);
    Task AddCategory(T category);
    Task UpdateCategory(T category);
    Task DeleteCategory(int id);

}