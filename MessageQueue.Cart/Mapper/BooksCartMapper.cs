using Mapster;
using MessageQueue.Cart.ViewModel;

namespace MessageQueue.Cart.Mapper
{
    public class BooksCartMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Model.BooksCart, BooksCartView>().Map(dest => dest.Id, src => src.Id.Value);
        
        }
    }
}
