using System;
using System.Collections.Generic;
using Data;
using System.Linq;
using Data.Entities;
using Common.Models;

namespace Repository
{
    public class PeriodTypeRepository : IPeriodTypeRepository
    {
        #region Members

        private readonly HomeProductManagerContext _context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodTypeRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PeriodTypeRepository(HomeProductManagerContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates the period type.
        /// </summary>
        /// <param name="model">The model.</param>
        public void CreatePeriodType(PeriodTypeModel model)
        {
            SavePeriodType(model);
        }

        /// <summary>
        /// Deletes the period type.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        public void DeletePeriodType(int periodTypeId)
        {
            var periodType = GetPeriodTypeById(periodTypeId);

            _context.PeriodTypes.Remove(periodType);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all Period types.
        /// </summary>
        /// <returns></returns>
        public IList<PeriodTypeModel> GetAllPeriodTypes()
        {
            var periodTypes = new List<PeriodTypeModel>();

            foreach (var periodType in _context.PeriodTypes)
            {
                periodTypes.Add(new PeriodTypeModel
                {
                    Id = periodType.PeriodTypeId,
                    Name = periodType.PeriodTypeName,
                    PeriodInDays = periodType.PeriodInDays

                });
            }

            return periodTypes;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <returns></returns>
        public PeriodTypeModel GetPeriodType(int periodTypeId)
        {
            var periodType = GetPeriodTypeById(periodTypeId);

            return new PeriodTypeModel
            {
                Id = periodType.PeriodTypeId,
                Name = periodType.PeriodTypeName,
                PeriodInDays = periodType.PeriodInDays
            };
        }

        /// <summary>
        /// Updates the period type.
        /// </summary>
        /// <param name="model">The model.</param>
        public void UpdatePeriodType(PeriodTypeModel model)
        {
            SavePeriodType(model);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Saves the period type.
        /// </summary>
        /// <param name="model">The model.</param>
        private void SavePeriodType(PeriodTypeModel model)
        {
            PeriodType periodType;

            if (model.Id.HasValue)
            {
                periodType = GetPeriodTypeById(model.Id.Value);
                periodType.PeriodTypeName = model.Name;
                periodType.PeriodInDays = model.PeriodInDays;
            }
            else
            {
                periodType = new PeriodType
                {
                    PeriodTypeName = model.Name,
                    PeriodInDays = model.PeriodInDays
                };

                _context.PeriodTypes.Add(periodType);
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the period type by identifier.
        /// </summary>
        /// <param name="periodTypeId">The period type identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">PeriodType not found</exception>
        private PeriodType GetPeriodTypeById(int periodTypeId)
        {
            PeriodType periodType = _context.PeriodTypes.FirstOrDefault(cat => cat.PeriodTypeId == periodTypeId);

            if (periodType == null)
            {
                throw new Exception("PeriodType not found");
            }

            return periodType;
        }

        #endregion
    }
}
