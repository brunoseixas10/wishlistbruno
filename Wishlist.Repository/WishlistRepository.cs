using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Model.Entities;
using Wishlist.Repository.Interfaces;
using Wishlist.Repository.Mock;

namespace Wishlist.Repository
{
    public sealed class WishlistRepository : IWishlistRepository
    {
        public async Task Create(Model.Entities.Wishlist wishlist)
        {
            wishlist.User = DatabaseMock.users.FirstOrDefault(x => x.Id == wishlist.User.Id);
            var p = new List<Product>(wishlist.Products.Count);
            foreach (var i in wishlist.Products)
            {
                p.Add(DatabaseMock.products.FirstOrDefault(x => x.Id == i.Id));
            }
            wishlist.Products = p;
            await Task.Run(() => DatabaseMock.wishes.Add(wishlist));
        }

        public Task<IList<Model.Entities.Wishlist>> List(int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Model.Entities.Wishlist>> List(int userId, int pageSize, int page)
        {
            return await Task.Run(() => DatabaseMock.wishes.Where(x => x.User.Id == userId).Skip(page - 1).Take(pageSize).ToList());
        }

        public async Task Remove(int userId, int productId)
        {
            await Task.Run(() =>
            {
                var userWishlist = DatabaseMock.wishes.FirstOrDefault(x => x.User.Id == userId);
                if (userWishlist != null)
                {
                    var generalWishlist = DatabaseMock.wishes.ToArray().ToList();
                    generalWishlist.Remove(userWishlist);
                    DatabaseMock.wishes.Clear();

                    var newProductsList = new List<Product>(userWishlist.Products.Count);
                    foreach (var i in userWishlist.Products)
                    {
                        if (i.Id != productId)
                        {
                            newProductsList.Add(i);
                        }
                    }
                    userWishlist.Products = newProductsList;

                    generalWishlist.Add(userWishlist);
                    foreach (var i in generalWishlist)
                    {
                        DatabaseMock.wishes.Add(i);
                    }
                }
            });
        }
    }
}