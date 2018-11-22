using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Data.Entities
{
    [Table("ProductStock")]
    public class ProductStock
    {
        #region Members

        public int? ProductStockId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int UnitId { get; set; }

        public int UnitAmount { get; set; }

        public int PeriodId { get; set; }

        public int? ProductAmountExist { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("UnitId")]
        public virtual UnitType Unit { get; set; }

        [ForeignKey("PeriodId")]
        public virtual PeriodType Period { get; set; }

        #endregion

        #region Public Methods

        public int CalculateMissingAmount(HomeProductManagerContext context, int periodTypeId)
        {
            if (Period.PeriodTypeId == periodTypeId)
            {
                return UnitAmount - (ProductAmountExist.HasValue ? ProductAmountExist.Value : 0);
            }

            PeriodType expectedPeriod = context.PeriodTypes.FirstOrDefault(pr => pr.PeriodTypeId == periodTypeId);

            decimal unitAmount = UnitAmount;
            decimal periodInDays = Period.PeriodInDays;
            decimal expectedPeriodInDays = expectedPeriod.PeriodInDays; ;

            decimal missingAmount = (unitAmount / periodInDays) * expectedPeriodInDays;

            return (int)Math.Ceiling(missingAmount);
        }

        #endregion
    }
}
