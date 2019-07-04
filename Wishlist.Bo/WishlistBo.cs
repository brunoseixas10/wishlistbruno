using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wishlist.Bo.Interfaces;
using Wishlist.Model.Signature;
using Wishlist.Repository.Interfaces;

namespace Wishlist.Bo
{
    public sealed class WishlistBo : IWishlistBo
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistBo(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        public async Task Create(WishlistSignature obj)
        {
            if (!obj.IsValid()) throw new ArgumentException(nameof(obj));
            await _wishlistRepository.Create(obj.Convert());
        }

        public Task<IList<Model.Entities.Wishlist>> List(int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Model.Entities.Wishlist>> List(int userId, int pageSize, int page)
        {
            if (userId <= 0) throw new ArgumentException("Invalid userId", nameof(userId));
            if (pageSize <= 0) throw new ArgumentException("Invalid pageSize", nameof(pageSize));
            if (page <= 0) throw new ArgumentException("Invalid page", nameof(page));
            return await _wishlistRepository.List(userId, pageSize, page);
        }

        public async Task Remove(int userId, int productId)
        {
            if (userId <= 0) throw new ArgumentException(nameof(userId));
            if (productId <= 0) throw new ArgumentException(nameof(productId));
            await _wishlistRepository.Remove(userId, productId);
        }
    }
}
