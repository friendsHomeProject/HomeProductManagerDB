using Common.Models;
using System.Collections.Generic;

namespace Repository
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="model">The model.</param>
        void CreateCategory(CategoryModel model);

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        void DeleteCategory(int categoryId);

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        IList<CategoryModel> GetAllCategories();

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        CategoryModel GetCategory(int categoryId);

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="model">The model.</param>
        void UpdateCategory(CategoryModel model);

    }
}
