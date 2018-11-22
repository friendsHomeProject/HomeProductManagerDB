using System;
using System.Collections.Generic;
using Data;
using System.Linq;
using Data.Entities;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductStockRepository : IProductStockRepository
    {
        #region Members

        private readonly HomeProductManagerContext _context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductStockRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ProductStockRepository(HomeProductManagerContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the product stock.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task CreateProductStock(ProductStockModel model)
        {
            await SaveProductStock(model);
        }

        /// <summary>
        /// Deletes the product stock.
        /// </summary>
        /// <param name="productStockId">The product stock identifier.</param>
        public async Task DeleteProductStock(int productStockId)
        {
            var product = await GetProductStockById(productStockId);

            _context.ProductsStock.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all products stock.
        /// </summary>
        /// <returns></returns>
        public IList<ProductStockModel> GetAllProductsStock()
        {
            var productsStock = new List<ProductStockModel>();

            foreach (var productStock in _context.ProductsStock)
            {
                var productModel = CreateProductStockModel(productStock);
                productsStock.Add(productModel);
            }

            return productsStock;
        }

        /// <summary>
        /// Gats the missing products for period.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IList<MissingProductModel>> GatMissingProductsForPeriod(int periodTypeId, int userId)
        {
            var products = await _context.ProductsStock.Where(product => product.UserId == userId)
                                                       .Include(product => product.Period)
                                                       .Include(product => product.Unit)
                                                       .Include(product => product.Product)
                                                       .ThenInclude(product => product.Category)
                                                       .ToListAsync();

            var productsStock = new List<MissingProductModel>();

            foreach (var productStock in products)
            {
                int missingAmount = productStock.CalculateMissingAmount(_context, periodTypeId);
                if (missingAmount > 0)
                {
                    var productModel = CreateMissingProductModel(productStock, missingAmount);
                    productsStock.Add(productModel);
                }
            }

            return productsStock;
        }

        private MissingProductModel CreateMissingProductModel(ProductStock productStock, int missingAmount)
        {
            return new MissingProductModel
            {
                ProductStockId = productStock.ProductStockId.Value,
                CategoryId = productStock.Product.ProductCategoryId,
                CategoryName = productStock.Product.Category.CategoryName,
                MissingAmount = missingAmount,
                ProductId = productStock.ProductId,
                ProductName = productStock.Product.ProductName,
                UnitTypeId = productStock.UnitId,
                UnitTypeName = productStock.Unit.UnitTypeName
            };
        }

        //private async Task<bool> IsStockMissing(ProductStock productStock, int periodTypeId)
        //{
        //    if (productStock.PeriodId == periodTypeId)
        //    {
        //        return productStock.UnitAmount < productStock.ProductAmountExist;
        //    }

        //    var period = await _context.PeriodTypes.FirstOrDefaultAsync(per => per.PeriodTypeId == periodTypeId);

        //    if (period == null)
        //    {
        //        throw new Exception("Period Not Found");
        //    }

        //    var periodDays = period.PeriodInDays;

        //    var productPeriod = await _context.PeriodTypes.FirstOrDefaultAsync(per => per.PeriodTypeId == productStock.PeriodId);

        //    var productPeriodDays = productPeriod.PeriodInDays;


        //}

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="productId">The product stock identifier.</param>
        /// <returns></returns>
        public async Task<ProductStockModel> GetProductStock(int productStockId)
        {
            var productStock = await GetProductStockById(productStockId);

            return CreateProductStockModel(productStock);
        }

        /// <summary>
        /// Updates the product stock.
        /// </summary>
        /// <param name="model">The model.</param>
        public async Task UpdateProductStock(ProductStockModel model)
        {
            await SaveProductStock(model);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the product stock model.
        /// </summary>
        /// <param name="productStock">The product stock.</param>
        /// <returns></returns>
        private ProductStockModel CreateProductStockModel(ProductStock productStock)
        {
            return new ProductStockModel
            {
                Id = productStock.ProductStockId,
                UserId = productStock.UserId,
                ProductId = productStock.ProductId,
                PeriodTypeId = productStock.ProductId,
                UnitTypeId = productStock.UnitId,
                UnitAmount = productStock.UnitAmount,
                ProductAmountExist = productStock.ProductAmountExist
            };
        }

        /// <summary>
        /// Saves the product stock.
        /// </summary>
        /// <param name="model">The model.</param>
        private async Task SaveProductStock(ProductStockModel model)
        {
            await ValidateProductStockModel(model);

            ProductStock productStock;

            if (model.Id.HasValue)
            {
                productStock = await GetProductStockById(model.Id.Value);
                productStock.ProductId = model.ProductId;
                productStock.UserId = model.UserId;
                productStock.PeriodId = model.PeriodTypeId;
                productStock.UnitId = model.UnitTypeId;
                productStock.UnitAmount = model.UnitAmount;
                productStock.ProductAmountExist = model.ProductAmountExist.HasValue ? model.ProductAmountExist.Value : productStock.ProductAmountExist; // TODO: check!!
            }
            else
            {
                productStock = new ProductStock
                {
                    UserId = model.UserId,
                    ProductId = model.ProductId,
                    PeriodId = model.PeriodTypeId,
                    UnitId = model.UnitTypeId,
                    UnitAmount = model.UnitAmount,
                    ProductAmountExist = model.ProductAmountExist
                };

                await _context.ProductsStock.AddAsync(productStock);
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Validates the product stock model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <exception cref="Exception">User Not Found</exception>
        private async Task ValidateProductStockModel(ProductStockModel model)
        {
            if (!await IsUserExists(model.UserId))
            {
                throw new Exception("User Not Found");
            }

            if (!await IsProductExists(model.ProductId))
            {
                throw new Exception("Product Not Found");
            }

            if (!await IsPeriodTypeExists(model.PeriodTypeId))
            {
                throw new Exception("Period Type Not Found");
            }

            if (!await IsUnitTypeExists(model.UnitTypeId))
            {
                throw new Exception("Unit Type Not Found");
            }

            if (await IsProductAlreadyExists(model))
            {
                throw new Exception("The product already exists");

            }
        }

        /// <summary>
        /// Gets the product stock by identifier.
        /// </summary>
        /// <param name="productStockId">The product stock identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">ProductStock not found</exception>
        private async Task<ProductStock> GetProductStockById(int productStockId)
        {
            ProductStock product = await _context.ProductsStock.FirstOrDefaultAsync(cat => cat.ProductStockId == productStockId);

            if (product == null)
            {
                throw new Exception("ProductStock not found");
            }

            return product;
        }

        /// <summary>
        /// Determines whether is period type exists the specified period type identifier.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <returns></returns>
        private Task<bool> IsPeriodTypeExists(int periodTypeId)
        {
            return _context.PeriodTypes.AsNoTracking().AnyAsync(period => period.PeriodTypeId == periodTypeId);

        }

        private Task<bool> IsProductAlreadyExists(ProductStockModel model)
        {
            return _context.ProductsStock.AsNoTracking()
                .AnyAsync(product => product.ProductId == model.ProductId && product.UserId == model.UserId);
        }

        /// <summary>
        /// Determines whether is product exists the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        private Task<bool> IsProductExists(int productId)
        {
            return _context.Products.AsNoTracking().AnyAsync(product => product.ProductId == productId);

        }

        /// <summary>
        /// Determines whether is unit type exists the specified unit type identifier.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        /// <returns></returns>
        private Task<bool> IsUnitTypeExists(int unitTypeId)
        {
            var u = _context.UnitTypes.AsNoTracking().AnyAsync(unit => unit.UnitTypeId == unitTypeId);
            return u;
        }

        /// <summary>
        /// Determines whether is user exists the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        ///   <c>true</c> if is user exists the specified user identifier; otherwise, <c>false</c>.
        /// </returns>
        private Task<bool> IsUserExists(int userId)
        {
            return _context.Users.AsNoTracking().AnyAsync(user => user.Id == userId);
        }

        #endregion
    }
}
