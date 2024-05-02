using Mapster;
using MessageQueue.Book.CQRS.Command.CreateBook;
using MessageQueue.Book.CQRS.Command.UpdateBook;
using MessageQueue.Book.Model;

namespace MessageQueue.Book.Mapper
{
    public class BookMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BookId, BookId>().MapWith(src => BookId.Of(src.Value));
            config.NewConfig<Guid, BookId>().MapWith(src => BookId.Of(src));
            config.NewConfig<CreateBookCommand, Model.Book>().Map(dest => dest.Id, src => BookId.Of(Guid.NewGuid()));
            config.NewConfig<UpdateBookCommand, Model.Book>().IgnoreNullValues(true);
        }
    }
}
