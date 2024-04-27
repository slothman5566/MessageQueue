using MessageQueue.Book.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageQueue.Book.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Model.Book>
    {
        public void Configure(EntityTypeBuilder<Model.Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(x => x.Value, y => BookId.Of(y));

        }
    }
}
