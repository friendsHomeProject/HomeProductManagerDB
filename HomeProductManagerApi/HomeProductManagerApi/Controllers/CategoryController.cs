using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;

namespace HomeProductManagerApi.Controllers
{
    //[Produces("application/json")]
    [Route("api/category")]
    public class CategoryController : Controller
    {
        #region Members

        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region Ctor

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult GatAllCategories()
        {
            try
            {
                IList<CategoryModel> categories = _categoryRepository.GetAllCategories();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("{categoryId}")]
        public IActionResult GatCategory(int categoryId)
        {
            try
            {
                CategoryModel category = _categoryRepository.GetCategory(categoryId);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost]
        public IActionResult AddNewCategory([FromBody]CategoryModel model)
        {
            try
            {
                _categoryRepository.CreateCategory(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(int categoryId, [FromBody]CategoryModel model)
        {
            try
            {
                _categoryRepository.UpdateCategory(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                _categoryRepository.DeleteCategory(categoryId);

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