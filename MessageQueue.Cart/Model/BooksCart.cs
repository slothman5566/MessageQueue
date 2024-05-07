using MessageQueue.Core.Model;
using System.Text.Json.Serialization;

namespace MessageQueue.Cart.Model
{

    public record BooksCartId : EntityId<Guid>
    {
        [JsonConstructor]
        protected BooksCartId(Guid value) : base(value)
        {

        }

        public static BooksCartId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new Exception("BooksCartId cannot be empty.");
            }
            return new BooksCartId(value);
        }
    }

    public class BooksCart:Entity<BooksCartId>
    {
        public List<BooksCartItem> Items { get; set; }
    }
}
