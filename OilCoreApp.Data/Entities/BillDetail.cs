using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("BillDetails")]
    public class BillDetail : DomainEntity<int>
    {
        public int BillId { get; set; }
        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }

        public int ProducId { get; set; }
        [ForeignKey("ProducId")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
    }
}
