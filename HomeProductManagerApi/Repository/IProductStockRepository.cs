using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductStockRepository
    {
        /// <summary>
        /// Creates the product stock.
        /// </summary>
        /// <param name="model">The model.</param>
        Task CreateProductStock(ProductStockModel model);

        /// <summary>
        /// Deletes the product stock.
        /// </summary>
        /// <param name="productStockId">The product stock identifier.</param>
        Task DeleteProductStock(int productStockId);

        /// <summary>
        /// Gets all products stock.
        /// </summary>
        /// <returns></returns>
        IList<ProductStockModel> GetAllProductsStock();

        /// <summary>
        /// Gets the product stock.
        /// </summary>
        /// <param name="productStockId">The product stock identifier.</param>
        /// <returns></returns>
        Task<ProductStockModel> GetProductStock(int productStockId);

        /// <summary>
        /// Updates the product stock.
        /// </summary>
        /// <param name="model">The model.</param>
        Task UpdateProductStock(ProductStockModel model);

        Task<IList<MissingProductModel>> GatMissingProductsForPeriod(int periodTypeId, int userId);

    }
}
