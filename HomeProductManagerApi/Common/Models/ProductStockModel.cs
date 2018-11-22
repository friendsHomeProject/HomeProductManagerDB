using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ProductStockModel
    {
        public int? Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int UnitTypeId { get; set; }

        public int UnitAmount { get; set; }

        public int PeriodTypeId { get; set; }

        public int? ProductAmountExist { get; set; }
    }
}
