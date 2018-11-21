using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;

namespace HomeProductManagerApi.Controllers
{
    [Route("api/periodType")]
    public class PeriodTypeController : Controller
    {
        #region Members

        private readonly IPeriodTypeRepository _periodTypeRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodTypeController"/> class.
        /// </summary>
        /// <param name="periodTypeRepository">The period type repository.</param>
        public PeriodTypeController(IPeriodTypeRepository periodTypeRepository)
        {
            _periodTypeRepository = periodTypeRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gats all period types.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GatAllPeriodTypes()
        {
            try
            {
                IList<PeriodTypeModel> periodTypes = _periodTypeRepository.GetAllPeriodTypes();

                return Ok(periodTypes);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Gats the type of the period.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <returns></returns>
        [HttpGet("{periodTypeId}")]
        public IActionResult GatPeriodType(int periodTypeId)
        {
            try
            {
                PeriodTypeModel periodType = _periodTypeRepository.GetPeriodType(periodTypeId);

                return Ok(periodType);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Adds the new type of the period.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddNewPeriodType([FromBody]PeriodTypeModel model)
        {
            try
            {
                _periodTypeRepository.CreatePeriodType(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Updates the type of the period.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{periodTypeId}")]
        public IActionResult UpdatePeriodType(int periodTypeId, [FromBody]PeriodTypeModel model)
        {
            try
            {
                _periodTypeRepository.UpdatePeriodType(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Deletes the type of the period.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <returns></returns>
        [HttpDelete("{periodTypeId}")]
        public IActionResult DeletePeriodType(int periodTypeId)
        {
            try
            {
                _periodTypeRepository.DeletePeriodType(periodTypeId);

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