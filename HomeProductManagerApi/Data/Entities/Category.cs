using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
