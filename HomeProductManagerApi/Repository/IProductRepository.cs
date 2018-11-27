using Common.Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IProductRepository
    {
        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="model">The model.</param>
        void CreateProduct(ProductModel model);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        void DeleteProduct(int productId);

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        IList<ProductModel> GetAllProducts(int? categoryId = null);

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        ProductModel GetProduct(int productId);

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="model">The model.</param>
        void UpdateProduct(ProductModel model);

    }
}
