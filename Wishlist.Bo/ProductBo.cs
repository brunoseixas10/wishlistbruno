using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wishlist.Bo.Interfaces;
using Wishlist.Model.Entities;
using Wishlist.Model.Signature;
using Wishlist.Repository.Interfaces;

namespace Wishlist.Bo
{
    public sealed class ProductBo : IProductBo
    {
        private IProductRepository _productRepository;

        public ProductBo(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Create(ProductSignature obj)
        {
            if (!obj.IsValid()) throw new ArgumentException(nameof(obj));
            await _productRepository.Create(obj.Convert());
        }

        public Task<IList<Product>> List(int pageSize, int page)
        {
            if (pageSize <= 0) throw new ArgumentException("Invalid pageSize", nameof(pageSize));
            if (page <= 0) throw new ArgumentException("Invalid page", nameof(page));
            return _productRepository.List(pageSize, page);
        }
    }
}
