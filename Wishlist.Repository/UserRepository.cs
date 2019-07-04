using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Model.Entities;
using Wishlist.Repository.Interfaces;
using Wishlist.Repository.Mock;
namespace Wishlist.Repository
{
    public sealed class UserRepository : IUserRepository
    {
        public async Task Create(User user)
        {
            user.Id = DatabaseMock.users.Any() ? DatabaseMock.users.Max(x => x.Id) + 1 : 1;
            await Task.Run(() => DatabaseMock.users.Add(user));
        }

        public async Task<IList<User>> List(int pageSize, int page)
        {
            return await Task.Run(() => DatabaseMock.users.Skip(page - 1).Take(pageSize).ToList());
        }
    }
}
