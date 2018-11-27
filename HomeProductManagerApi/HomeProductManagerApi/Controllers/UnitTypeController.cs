using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;

namespace HomeProductManagerApi.Controllers
{
    [Route("api/unitType")]
    public class UnitTypeController : Controller
    {
        #region Members

        private readonly IUnitTypeRepository _unitTypeRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTypeController"/> class.
        /// </summary>
        /// <param name="unitTypeRepository">The unit type repository.</param>
        public UnitTypeController(IUnitTypeRepository unitTypeRepository)
        {
            _unitTypeRepository = unitTypeRepository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gats all unit types.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GatAllUnitTypes()
        {
            try
            {
                IList<UnitTypeModel> unitTypes = _unitTypeRepository.GetAllUnitTypes();

                return Ok(unitTypes);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Gats the type of the unit.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        /// <returns></returns>
        [HttpGet("{unitTypeId}")]
        public IActionResult GatUnitType(int unitTypeId)
        {
            try
            {
                UnitTypeModel unitType = _unitTypeRepository.GetUnitType(unitTypeId);

                return Ok(unitType);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Adds the new type of the unit.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddNewUnitType([FromBody]UnitTypeModel model)
        {
            try
            {
                _unitTypeRepository.CreateUnitType(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Updates the type of the unit.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut("{unitTypeId}")]
        public IActionResult UpdateUnitType(int unitTypeId, [FromBody]UnitTypeModel model)
        {
            try
            {
                model.Id = unitTypeId;
                _unitTypeRepository.UpdateUnitType(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /// <summary>
        /// Deletes the type of the unit.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        /// <returns></returns>
        [HttpDelete("{unitTypeId}")]
        public IActionResult DeleteUnitType(int unitTypeId)
        {
            try
            {
                _unitTypeRepository.DeleteUnitType(unitTypeId);

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