using MessageQueue.Cart.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageQueue.Cart.Data.Configuration
{
    public class BooksCartConfiguration : IEntityTypeConfiguration<Model.BooksCart>
    {
        public void Configure(EntityTypeBuilder<BooksCart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Value, y =>BooksCartId.Of(y)).ValueGeneratedOnAdd();
        }
    }
}
