using System.Collections.Concurrent;
using Wishlist.Model.Entities;

namespace Wishlist.Repository.Mock
{
    internal sealed class DatabaseMock
    {
        //Users table
        internal static ConcurrentBag<User> users = new ConcurrentBag<User>();

        //Products table
        internal static ConcurrentBag<Product> products = new ConcurrentBag<Product>();

        //wishlist table
        internal static ConcurrentBag<Model.Entities.Wishlist> wishes = new ConcurrentBag<Model.Entities.Wishlist>();
    }
}
