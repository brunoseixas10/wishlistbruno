using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wishlist.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T user);
        Task<IList<T>> List(int pageSize, int page);
    }
}
