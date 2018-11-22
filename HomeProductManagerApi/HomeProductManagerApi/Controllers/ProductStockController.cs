using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Common.Models;
using System.Threading.Tasks;

namespace HomeProductManagerApi.Controllers
{
    [Route("api/productstock")]
    public class ProductStockController : Controller
    {
        #region Members

        private readonly IProductStockRepository _productStockRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductStockController"/> class.
        /// </summary>
        /// <param name="productStockRepository">The product stock repository.</param>
        public ProductStockController(IProductStockRepository productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gats all products stock.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GatAllProductsStock()
        {
            try
            {
                IList<ProductStockModel> productsStock = _productStockRepository.GetAllProductsStock();

                return Ok(productsStock);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("missingProducts")]
        public async Task<IActionResult> GatMissingProductsForPeriod(int periodTypeId, int userId)
        {
            try
            {
                IList<MissingProductModel> productsStock = await _productStockRepository.GatMissingProductsForPeriod(periodTypeId, userId);

                return Ok(productsStock);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Gats the product stock.
        /// </summary>
        /// <param name="productStockId">The product stock identifier.</param>
        /// <returns></returns>
        [HttpGet("{productStockId}")]
        public async Task<IActionResult> GatProductStock(int productStockId)
        {
            try
            {
                ProductStockModel productStock = await _productStockRepository.GetProductStock(productStockId);

                return Ok(productStock);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductStock([FromBody]ProductStockModel model)
        {
            try
            {
                await _productStockRepository.CreateProductStock(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Updates the product stock.
        /// </summary>
        /// <param name="productStockId">The product stock identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{productStockId}")]
        public async Task<IActionResult> UpdateProductStock(int productStockId, [FromBody]ProductStockModel model)
        {
            try
            {
                await _productStockRepository.UpdateProductStock(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Deletes the product stock.
        /// </summary>
        /// <param name="productStockId">The product stock identifier.</param>
        /// <returns></returns>
        [HttpDelete("{productStockId}")]
        public async Task<IActionResult> DeleteProductStock(int productStockId)
        {
            try
            {
                await _productStockRepository.DeleteProductStock(productStockId);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        #endregion
    }
}