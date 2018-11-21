using Common.Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IPeriodTypeRepository
    {
        /// <summary>
        /// Creates the period type.
        /// </summary>
        /// <param name="model">The model.</param>
        void CreatePeriodType(PeriodTypeModel model);

        /// <summary>
        /// Deletes the period type.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        void DeletePeriodType(int periodTypeId);

        /// <summary>
        /// Gets all period types.
        /// </summary>
        /// <returns></returns>
        IList<PeriodTypeModel> GetAllPeriodTypes();

        /// <summary>
        /// Gets the period type.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <returns></returns>
        PeriodTypeModel GetPeriodType(int periodTypeId);

        /// <summary>
        /// Updates the period type.
        /// </summary>
        /// <param name="model">The model.</param>
        void UpdatePeriodType(PeriodTypeModel model);

    }
}
