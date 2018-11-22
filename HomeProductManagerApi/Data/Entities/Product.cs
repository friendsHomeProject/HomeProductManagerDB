using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Products")]
    public class Product
    {
        public int? ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductCategoryId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public Category Category { get; set; }
    }
}
