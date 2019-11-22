using OilCoreApp.Data.Enums;
using OilCoreApp.Data.Interfaces;
using OilCoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OilCoreApp.Data.Entities
{
    [Table("Bills")]
    public class Bill : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Bill() { }

        public Bill(string customerName, string customerAdress, string customerMobile, string customerMessage,
            BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId)
        {
            CustomerName = customerName;
            CustomerAddress = customerAdress;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;

        }

        public Bill(int id, string customerName, string customerAdress, string customerMobile, string customerMessage,
            BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid customerId)
        {
            Id = id;
            CustomerName = customerName;
            CustomerAddress = customerAdress;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;

        }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        [MaxLength(256)]
        [Required]
        public string CustomerMessage { get; set; }
        public BillStatus BillStatus { get; set; }
        
        public Guid CustomerId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Modified { get; set; }

        [ForeignKey("CustomerId")]
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
