using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Common.Models;

namespace HomeProductManagerApi.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        #region Members

        private readonly IProductRepository _productRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gats all products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GatAllProducts()
        {
            try
            {
                IList<ProductModel> products = _productRepository.GetAllProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("{productId}")]
        public IActionResult GatProduct(int productId)
        {
            try
            {
                ProductModel product = _productRepository.GetProduct(productId);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult AddNewProduct([FromBody]ProductModel model)
        {
            try
            {
                _productRepository.CreateProduct(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody]ProductModel model)
        {
            try
            {
                _productRepository.UpdateProduct(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                _productRepository.DeleteProduct(productId);

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