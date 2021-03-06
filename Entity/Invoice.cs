using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entity
{
    public partial class Invoice
    {
        [Key]
        [Column(TypeName= "nvarchar(4)")]
        public string IdInvoice{ get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string PaymentMethod { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string SaleDate { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string DueDate { get; set; }
        [NotMapped]
        public string IdClient { get; set; }
        [Column(TypeName= "nvarchar(11)")]
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        
        
        [Column(TypeName = "nvarchar(4)")]
        [ForeignKey("IdInvoice")]
        public virtual IList<InvoiceDetail> InvoiceDetails { get; set; } 

        public Invoice()
        {
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public void AddInvoiceDetails(Product product, float quantity, float discount, decimal price)
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail(product, quantity, discount, price);
            invoiceDetail.IdInvoice = this.IdInvoice;
            InvoiceDetails.Add(invoiceDetail);
        }

        public void CalculateSubtotal()
        {
            Subtotal = InvoiceDetails.Sum(d => d.TolalDetail);
        }

        public void CalcularTotalIva()
        {
            TotalIva = InvoiceDetails.Sum(d => d.CalculateIva());
        }

        public void CalculateTotal()
        {
            CalculateSubtotal();
            CalcularTotalIva();
           
            Total = Subtotal + TotalIva ;
        }

    }
}