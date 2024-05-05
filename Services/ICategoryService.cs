using pedals_ui.Models;

namespace pedals_ui.Services;

public interface ICategoryService
{
    Task<List<Category>?> GetCategories();
}
