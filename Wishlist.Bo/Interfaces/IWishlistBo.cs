using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wishlist.Bo.Interfaces
{
    public interface IWishlistBo : IGenericCrud<Model.Entities.Wishlist, Model.Signature.WishlistSignature>
    {
        Task<IList<Model.Entities.Wishlist>> List(int userId, int pageSize, int page);
        Task Remove(int userId, int productId);
    }
}
