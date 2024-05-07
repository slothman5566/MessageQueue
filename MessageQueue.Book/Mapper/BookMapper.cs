using Mapster;
using MessageQueue.Book.CQRS.Command.CreateBook;
using MessageQueue.Book.CQRS.Command.UpdateBook;
using MessageQueue.Book.Model;
using MessageQueue.Book.ViewModel;

namespace MessageQueue.Book.Mapper
{
    public class BookMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Model.Book, BookView>().Map(dest => dest.Id, src => src.Id.Value);
            config.NewConfig<CreateBookCommand, Model.Book>().Map(dest => dest.Id, src => BookId.Of(Guid.NewGuid()));
            config.NewConfig<UpdateBookCommand, Model.Book>().IgnoreNullValues(true);
        }
    }
}
