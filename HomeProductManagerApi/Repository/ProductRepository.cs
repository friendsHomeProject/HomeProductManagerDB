using System;
using System.Collections.Generic;
using Data;
using System.Linq;
using Data.Entities;
using Common.Models;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Members

        private readonly HomeProductManagerContext _context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductRepository(HomeProductManagerContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="model">The model.</param>
        public void CreateProduct(ProductModel model)
        {
            SaveProduct(model);
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public IList<ProductModel> GetAllProducts()
        {
            var products = new List<ProductModel>();

            foreach (var product in _context.Products)
            {
                var productModel = CreateProductModel(product);
                products.Add(productModel);
            }

            return products;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public ProductModel GetProduct(int productId)
        {
            var product = GetProductById(productId);

            return CreateProductModel(product);
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="model">The model.</param>
        public void UpdateProduct(ProductModel model)
        {
            SaveProduct(model);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the product model.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        private ProductModel CreateProductModel(Product product)
        {
            return new ProductModel
            {
                Id = product.ProductId,
                Name = product.ProductName,
                CategoryId = product.ProductCategoryId,
                UserId = product.UserId

            };
        }

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="model">The model.</param>
        private void SaveProduct(ProductModel model)
        {
            ValidateProductModel(model);

            Product product;

            if (model.Id.HasValue)
            {
                product = GetProductById(model.Id.Value);
                product.ProductName = model.Name;
                product.ProductCategoryId = model.CategoryId;
                product.UserId = model.UserId;
            }
            else
            {
                product = new Product
                {
                    ProductName = model.Name,
                    ProductCategoryId = model.CategoryId,
                    UserId = model.UserId
                };
                _context.Products.Add(product);
            }

            _context.SaveChanges();
        }

        private void ValidateProductModel(ProductModel model)
        {
            if (!IsUserExists(model.UserId))
            {
                throw new Exception("User Not Found");
            }

            if (!IsCategoryExists(model.CategoryId))
            {
                throw new Exception("Category Not Found");
            }
        }

        private Product GetProductById(int productId)
        {
            Product product = _context.Products.FirstOrDefault(cat => cat.ProductId == productId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return product;
        }

        /// <summary>
        /// Determines whether is category exists the specified category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>
        ///   <c>true</c> if is category exists the specified category identifier; otherwise, <c>false</c>.
        /// </returns>
        private bool IsCategoryExists(int categoryId)
        {
            return _context.Categories.Any(category => category.CategoryId == categoryId);
        }

        /// <summary>
        /// Determines whether is user exists the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        ///   <c>true</c> if is user exists the specified user identifier; otherwise, <c>false</c>.
        /// </returns>
        private bool IsUserExists(int userId)
        {
            return _context.Users.Any(user => user.Id == userId);
        }

        #endregion
    }
}
