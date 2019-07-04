using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Model.Entities;
using Wishlist.Repository.Interfaces;
using Wishlist.Repository.Mock;

namespace Wishlist.Repository
{
    public sealed class ProductRepository : IProductRepository
    {
        public async Task Create(Product product)
        {
            product.Id = DatabaseMock.products.Any() ? DatabaseMock.products.Max(x => x.Id) + 1 : 1;
            await Task.Run(() => DatabaseMock.products.Add(product));
        }

        public async Task<IList<Product>> List(int pageSize, int page)
        {
            return await Task.Run(() => DatabaseMock.products.Skip(page - 1).Take(pageSize).ToList());
        }
    }
}
