using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class MissingProductModel
    {
        public int ProductStockId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int UnitTypeId { get; set; }

        public string UnitTypeName { get; set; }

        public int MissingAmount { get; set; }
    }
}
