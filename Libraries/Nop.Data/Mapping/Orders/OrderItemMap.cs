using System.Data.Entity.ModelConfiguration;
using Nop.Core.Domain.Orders;

namespace Nop.Data.Mapping.Orders
{
    public partial class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            this.ToTable("OrderItem");
            this.HasKey(orderItem => orderItem.Id);
            this.Property(orderItem => orderItem.AttributeDescription);
            this.Property(orderItem => orderItem.AttributesXml);

            this.Property(orderItem => orderItem.UnitPriceInclTax).HasPrecision(18, 4);
            this.Property(orderItem => orderItem.UnitPriceExclTax).HasPrecision(18, 4);
            this.Property(orderItem => orderItem.PriceInclTax).HasPrecision(18, 4);
            this.Property(orderItem => orderItem.PriceExclTax).HasPrecision(18, 4);
            this.Property(orderItem => orderItem.DiscountAmountInclTax).HasPrecision(18, 4);
            this.Property(orderItem => orderItem.DiscountAmountExclTax).HasPrecision(18, 4);
            this.Property(orderItem => orderItem.OriginalProductCost).HasPrecision(18, 4);
            this.Property(orderItem => orderItem.ItemWeight).HasPrecision(18, 4);


            this.HasRequired(orderItem => orderItem.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId);

            this.HasRequired(orderItem => orderItem.Product)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.ProductId);
        }
    }
}