using System;
using System.Collections.Generic;
using Data;
using System.Linq;
using Data.Entities;
using Common.Models;

namespace Repository
{
    public class UnitTypeRepository : IUnitTypeRepository
    {
        #region Members

        private readonly HomeProductManagerContext _context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTypeRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitTypeRepository(HomeProductManagerContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the unit type.
        /// </summary>
        /// <param name="model">The model.</param>
        public void CreateUnitType(UnitTypeModel model)
        {
            SaveUnitType(model);
        }

        /// <summary>
        /// Deletes the unit type.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        public void DeleteUnitType(int unitTypeId)
        {
            var unitType = GetUnitTypeById(unitTypeId);

            _context.UnitTypes.Remove(unitType);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all Unit types.
        /// </summary>
        /// <returns></returns>
        public IList<UnitTypeModel> GetAllUnitTypes()
        {
            var unitTypes = new List<UnitTypeModel>();

            foreach (var unitType in _context.UnitTypes)
            {
                unitTypes.Add(new UnitTypeModel
                {
                    Id = unitType.UnitTypeId,
                    Name = unitType.UnitTypeName

                });
            }

            return unitTypes;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        /// <returns></returns>
        public UnitTypeModel GetUnitType(int unitTypeId)
        {
            var unitType = GetUnitTypeById(unitTypeId);

            return new UnitTypeModel
            {
                Id = unitType.UnitTypeId,
                Name = unitType.UnitTypeName
            };
        }

        /// <summary>
        /// Updates the unit type.
        /// </summary>
        /// <param name="model">The model.</param>
        public void UpdateUnitType(UnitTypeModel model)
        {
            SaveUnitType(model);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Saves the unit type.
        /// </summary>
        /// <param name="model">The model.</param>
        private void SaveUnitType(UnitTypeModel model)
        {
            UnitType unitType;

            if (model.Id.HasValue)
            {
                unitType = GetUnitTypeById(model.Id.Value);
                unitType.UnitTypeName = model.Name;
            }
            else
            {
                unitType = new UnitType { UnitTypeName = model.Name };
                _context.UnitTypes.Add(unitType);
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the unit type by identifier.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">UnitType not found</exception>
        private UnitType GetUnitTypeById(int unitTypeId)
        {
            UnitType unitType = _context.UnitTypes.FirstOrDefault(cat => cat.UnitTypeId == unitTypeId);

            if (unitType == null)
            {
                throw new Exception("UnitType not found");
            }

            return unitType;
        }

        #endregion
    }
}
