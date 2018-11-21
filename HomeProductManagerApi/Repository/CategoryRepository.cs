using System;
using System.Collections.Generic;
using Data;
using System.Linq;
using Data.Entities;
using Common.Models;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Members

        private readonly HomeProductManagerContext _context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CategoryRepository(HomeProductManagerContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="model">The model.</param>
        public void CreateCategory(CategoryModel model)
        {
            SaveCategory(model);
        }

        public void DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public IList<CategoryModel> GetAllCategories()
        {
            var categories = new List<CategoryModel>();

            foreach (var category in _context.Categories)
            {
                categories.Add(new CategoryModel
                {
                    Id = category.CategoryId,
                    Name = category.CategoryName

                });
            }

            return categories;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        public CategoryModel GetCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);

            return new CategoryModel
            {
                Id = category.CategoryId,
                Name = category.CategoryName
            };
        }

        /// <summary>
        /// Updates the category.
        /// </summary>
        /// <param name="model">The model.</param>
        public void UpdateCategory(CategoryModel model)
        {
            SaveCategory(model);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Saves the category.
        /// </summary>
        /// <param name="model">The model.</param>
        private void SaveCategory(CategoryModel model)
        {
            Category category;

            if (model.Id.HasValue)
            {
                category = GetCategoryById(model.Id.Value);
                category.CategoryName = model.Name;
            }
            else
            {
                category = new Category { CategoryName = model.Name };
                _context.Categories.Add(category);
            }

            _context.SaveChanges();
        }

        private Category GetCategoryById(int categoryId)
        {
            Category category = _context.Categories.FirstOrDefault(cat => cat.CategoryId == categoryId);

            if (category == null)
            {
                throw new Exception("Category not found");
            }

            return category;
        }

        #endregion
    }
}
