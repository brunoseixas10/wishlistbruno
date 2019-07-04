using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wishlist.Repository.Interfaces
{
    public interface IWishlistRepository : IBaseRepository<Model.Entities.Wishlist>
    {
        Task<IList<Model.Entities.Wishlist>> List(int userId, int pageSize, int page);
        Task Remove(int userId, int productId);
    }
}
