using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("PeriodType")]
    public class PeriodType
    {
        public int? PeriodTypeId { get; set; }

        public string PeriodTypeName { get; set; }

        public int PeriodInDays { get; set; }

    }
}
