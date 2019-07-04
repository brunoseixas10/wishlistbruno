using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wishlist.Bo.Interfaces
{
    public interface IGenericCrud<T, Y>
        where T : class
        where Y : class
    {
        Task<IList<T>> List(int pageSize, int page);
        Task Create(Y obj);
    }
}
