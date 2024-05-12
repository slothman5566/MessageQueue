﻿using MessageQueue.Cart.Model;
using MessageQueue.Core.Repository;

namespace MessageQueue.Cart.Repository.Interface
{
    public interface IBooksCartItemRepository : IGenericRepository<BooksCartItem, Guid>
    {
    }
}
