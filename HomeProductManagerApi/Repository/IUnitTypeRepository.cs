using Common.Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IUnitTypeRepository
    {
        /// <summary>
        /// Creates the unit type.
        /// </summary>
        /// <param name="model">The model.</param>
        void CreateUnitType(UnitTypeModel model);

        /// <summary>
        /// Deletes the unit type.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        void DeleteUnitType(int unitTypeId);

        /// <summary>
        /// Gets all unit types.
        /// </summary>
        /// <returns></returns>
        IList<UnitTypeModel> GetAllUnitTypes();

        /// <summary>
        /// Gets the unit type.
        /// </summary>
        /// <param name="unitTypeId">The unit type identifier.</param>
        /// <returns></returns>
        UnitTypeModel GetUnitType(int unitTypeId);

        /// <summary>
        /// Updates the unit type.
        /// </summary>
        /// <param name="model">The model.</param>
        void UpdateUnitType(UnitTypeModel model);

    }
}
