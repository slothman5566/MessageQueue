using MessageQueue.Cart.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageQueue.Cart.Data.Configuration
{
    public class BooksCartItemConfiguration : IEntityTypeConfiguration<Model.BooksCartItem>
    {
        public void Configure(EntityTypeBuilder<BooksCartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BooksCartId).HasConversion(x => x.Value, y => BooksCartId.Of(y));

        }
    }
}
