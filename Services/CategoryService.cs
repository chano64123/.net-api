using Category = API.Models.Category;

namespace API.Services;

public class CategoryService : ICategoryService
{
    TasksContext _context;
    public CategoryService(TasksContext context)
    {
        _context = context;
    }
    public IEnumerable<Category> GetAll() {
        return _context.Categories;
    }

    public async Task<bool> Save(Category category){
        try {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        } catch (Exception) {
            return false;
        }
    }

    public async Task<bool> Update(Guid id, Category category){
        try {
            var currentCategory = _context.Categories.Find(id);

            if(currentCategory == null){
                return false;
            }

            currentCategory.Impact = category.Impact; 
            currentCategory.Name = category.Name; 
            currentCategory.Description = category.Description; 

            _context.Update(currentCategory);
            await _context.SaveChangesAsync();
            return true;
        } catch (Exception) {
            return false;
        }
    }

    public async Task<bool> Delete(Guid id){
        try {
            var currentCategory = _context.Categories.Find(id);

            if(currentCategory == null){
                return false;
            }

            _context.Remove(currentCategory);
            await _context.SaveChangesAsync();
            return true;
        } catch (Exception) {
            return false;
        }
    }
}

public interface ICategoryService {
    IEnumerable<Category> GetAll();
    Task<bool> Save(Category category);
    Task<bool> Update(Guid id, Category category);
    Task<bool> Delete(Guid id);
}