using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("UnitType")]
    public class UnitType
    {
        public int? UnitTypeId { get; set; }

        public string UnitTypeName { get; set; }
    }
}
